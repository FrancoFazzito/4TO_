using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Database
{
    public class DatabaseTransaction<TConnection> where TConnection : IDbConnection, new()
    {
        private readonly ICollection<DatabaseNonQuery<TConnection>> _commands;
        private readonly string _connectionString;

        public DatabaseTransaction(string connectionString)
        {
            _commands = new List<DatabaseNonQuery<TConnection>>();
            _connectionString = connectionString;
        }

        public DatabaseTransaction<TConnection> AddCommand(DatabaseNonQuery<TConnection> command)
        {
            _commands.Add(command);
            return this;
        }

        public void Execute()
        {
            using var connection = OpenTransactionConnection();
            using var transaction = connection.BeginTransaction();
            try
            {
                ExecuteCommands(connection, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        private TConnection OpenTransactionConnection()
        {
            var connection = new TConnection()
            {
                ConnectionString = _connectionString
            };
            connection.Open();
            return connection;
        }

        private void ExecuteCommands(TConnection connection, IDbTransaction transaction)
        {
            foreach (var command in CommandsConfigured)
            {
                command.Connection = connection;
                command.Transaction = transaction;
                command.ExecuteNonQuery();
            }
        }

        private IEnumerable<IDbCommand> CommandsConfigured => from command in _commands
                                                              let commandToExecute = command.ConfiguredToExecute
                                                              select commandToExecute;
    }
}