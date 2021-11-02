using Application;
using Database;
using Domain;
using Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace WebApi
{
    public static partial class RegisterDependencies
    {
        private const string CONNECTION = "ClientConnection";

        public static IServiceCollection RegisterRepositoryDependencies<T>(this IServiceCollection services, IConfiguration configuration) where T : IDbConnection, new()
        {
            services.AddScoped(c => new Database<T>(configuration.GetConnectionString(CONNECTION)));
            services.AddTransient<IRepository<Client>, RepositoryClient<T>>();
            return services;
        }

        public static IServiceCollection RegisterClientServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IHandler<ClientCreated>, ClientCreatedHandler>();
            return services;
        }
    }
}