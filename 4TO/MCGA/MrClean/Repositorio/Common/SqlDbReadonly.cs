using Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Repositorio
{
    public abstract class SqlDbReadonly<TEntity>
    {
        protected readonly SqlDatabase<SqlConnection> _database;

        protected SqlDbReadonly()
        {
            _database = new SqlDatabase<SqlConnection>();
        }

        protected IEnumerable<TEntity> GetAll()
        {
            return _database.Query(SelectAllQuery).Select(NewRow);
        }

        protected abstract string SelectAllQuery { get; }

        protected abstract Func<DatabaseRow, TEntity> NewRow { get; }
    }
}