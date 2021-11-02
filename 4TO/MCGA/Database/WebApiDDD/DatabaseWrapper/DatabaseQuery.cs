using System;
using System.Collections.Generic;
using System.Data;

namespace Database
{
    public class DatabaseQuery<TConnection> : DatabaseCommand<TConnection> where TConnection : IDbConnection, new()
    {
        public DatabaseQuery(string connectionString, string commandText) : base(connectionString, commandText)
        {
        }

        public DatabaseQuery<TConnection> WithParam(string name, object value)
        {
            AddParam(name, value);
            return this;
        }

        public IEnumerable<T> Select<T>(Func<DatabaseRow, T> functionReader)
        {
            using var reader = ConfiguredToExecute.ExecuteReader();
            var result = new List<T>();
            while (reader.Read())
            {
                result.Add(functionReader(new DatabaseRow(reader)));
            }
            return result;
        }
    }
}