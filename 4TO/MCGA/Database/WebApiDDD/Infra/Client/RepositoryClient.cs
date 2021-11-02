using Application;
using Database;
using Domain;
using Infra.Common;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Data;

namespace Infra
{
    public class RepositoryClient<TConnection> : DbReadonlyRepository<Client, TConnection>, IRepository<Client> where TConnection : IDbConnection, new()
    {
        private const string DATE_PARAM = "date";
        private const string NAME_PARAM = "name";
        private const string ID_PARAM = "id";

        public RepositoryClient(Database<TConnection> database, IMemoryCache cache) : base(database, cache)
        {
        }

        public bool Create(Client client)
        {
            var modified = _database.NonQuery($"INSERT INTO Client VALUES (@{NAME_PARAM},@{DATE_PARAM})")
                                    .WithParam(NAME_PARAM, client.Name)
                                    .WithParam(DATE_PARAM, client.CreatedDate)
                                    .Execute();
            return modified;
        }

        public bool Delete(int id)
        {
            var modified = _database.NonQuery($"DELETE FROM Client WHERE Id = @{ID_PARAM}")
                                     .WithParam(ID_PARAM, id)
                                     .Execute();
            return modified;
        }

        public bool Update(Client client)
        {
            var modified = _database.NonQuery($"UPDATE Client SET Name = @{NAME_PARAM}, Date = @{DATE_PARAM} WHERE Id = @{ID_PARAM}")
                                    .WithParam(ID_PARAM, client.Id)
                                    .WithParam(NAME_PARAM, client.Name)
                                    .WithParam(DATE_PARAM, client.CreatedDate)
                                    .Execute();
            return modified;
        }

        protected override string SelectAllQuery => "SELECT * FROM Client";

        protected override string SelectWhereIdQuery => "SELECT * FROM Client WHERE Id = @id";

        protected override Func<DatabaseRow, Client> NewRow => row => new Client()
        {
            Id = row.GetValue<int>(ID_PARAM),
            Name = row.GetValue<string>(NAME_PARAM)
            CreatedDate = row.GetValue<DateTime>(DATE_PARAM)
        };
    }
}