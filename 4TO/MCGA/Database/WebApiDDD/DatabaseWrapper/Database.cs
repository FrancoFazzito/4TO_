using System.Data;

namespace Database
{
    public class Database<TConnection> where TConnection : IDbConnection, new()
    {
        private readonly string _connectionString;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DatabaseNonQuery<TConnection> NonQuery(string commandText)
        {
            return new DatabaseNonQuery<TConnection>(_connectionString, commandText);
        }

        public DatabaseQuery<TConnection> Query(string commandText)
        {
            return new DatabaseQuery<TConnection>(_connectionString, commandText);
        }

        public DatabaseTransaction<TConnection> Transaction()
        {
            return new DatabaseTransaction<TConnection>(_connectionString);
        }
    }
}