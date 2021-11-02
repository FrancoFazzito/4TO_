using Database;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Infra.Common
{
    public abstract class DbReadonlyRepository<TEntity, TConnection> where TEntity : IEntity where TConnection : IDbConnection, new()
    {
        protected readonly Database<TConnection> _database;
        private readonly IMemoryCache _cache;

        protected DbReadonlyRepository(Database<TConnection> database, IMemoryCache cache)
        {
            _database = database;
            _cache = cache;
        }

        public IEnumerable<TEntity> GetAll()
        {
            if (!_cache.TryGetValue<IEnumerable<TEntity>>(CacheKey, out var values))
            {
                UpdateCache();
                return SelectAll();
            }
            return values;
        }

        public TEntity GetById(int id)
        {
            _cache.TryGetValue<IEnumerable<TEntity>>(CacheKey, out var values);
            var value = values.FirstOrDefault(c => c.Id == id);
            if (value == null)
            {
                UpdateCache();
                return SelectAll().FirstOrDefault(c => c.Id == id);
            }
            return value;
        }

        public void UpdateCache()
        {
            _cache.Set(CacheKey, SelectAll());
        }

        private IEnumerable<TEntity> SelectAll()
        {
            return _database.Query(SelectAllQuery).Select(NewRow);
        }

        protected abstract string SelectAllQuery { get; }

        protected abstract string SelectWhereIdQuery { get; }

        protected abstract Func<DatabaseRow, TEntity> NewRow { get; }

        protected virtual string IdParamName => "id";

        protected virtual string CacheKey => typeof(TEntity).ToString();
    }
}