using System.Data;

namespace Database
{
    public class DatabaseNonQuery<TConnection> : DatabaseCommand<TConnection> where TConnection : IDbConnection, new()
    {
        public DatabaseNonQuery(string connectionString, string commandText) : base(connectionString, commandText)
        {
        }

        public DatabaseNonQuery<TConnection> WithParam(string name, object value)
        {
            AddParam(name, value);
            return this;
        }

        public bool Execute()
        {
            var modified = ConfiguredToExecute.ExecuteNonQuery() >= 1;
            ConfiguredToExecute.Connection.Close();
            return modified;
        }
    }
}