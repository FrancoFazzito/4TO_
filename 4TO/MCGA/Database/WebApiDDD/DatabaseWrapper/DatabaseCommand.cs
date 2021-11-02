using System.Collections.Generic;
using System.Data;

namespace Database
{
    public class DatabaseCommand<TConnection> where TConnection : IDbConnection, new() //change to connection string
    {
        private readonly IDbConnection _connection;
        private readonly IDbCommand _command;
        protected readonly IDictionary<string, object> _parameters;

        protected DatabaseCommand(string connectionString, string commandText)
        {
            _connection = new TConnection()
            {
                ConnectionString = connectionString
            };
            _command = _connection.CreateCommand();
            _command.CommandText = commandText;
            _parameters = new Dictionary<string, object>();
        }

        protected void AddParam(string name, object value)
        {
            _parameters.Add(name, value);
        }

        public IDbCommand ConfiguredToExecute
        {
            get
            {
                AddParams();
                OpenConnection();
                return _command;
            }
        }

        private void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            _command.Connection = _connection;
        }

        private void AddParams()
        {
            foreach (var param in _parameters)
            {
                var parameter = _command.CreateParameter();
                parameter.ParameterName = param.Key;
                parameter.Value = param.Value;
                _command.Parameters.Add(parameter);
            }
        }
    }
}