using System;
using System.Data;

namespace Database
{
    public class DatabaseRow
    {
        private readonly IDataReader _reader;

        public DatabaseRow(IDataReader reader)
        {
            _reader = reader;
        }

        public T GetValue<T>(string name)
        {
            var value = _reader[name];
            return DBNull.Value == value ? default : (T)value;
        }
    }
}