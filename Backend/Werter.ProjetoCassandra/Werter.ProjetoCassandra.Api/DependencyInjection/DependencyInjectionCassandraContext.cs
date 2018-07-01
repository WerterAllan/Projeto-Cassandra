using Cassandra;
using Cassandra.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Werter.ProjetoCassandra.Domain.Contracts;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Infra.Cassandra.Mapping;
using Werter.ProjetoCassandra.Infra.Cassandra.Repository;

namespace Werter.ProjetoCassandra.Api.DependencyInjection
{
    public static class DependencyInjectionCassandraContext
    {
        public static void AddDependency(IServiceCollection services)
        {

            var cluster = Cluster.Builder()
                .AddContactPoints("127.0.0.1")
                .WithDefaultKeyspace("werterstore")
                .Build();

            services.AddSingleton(cluster.Connect("werterstore"));

            MappingConfiguration.Global.Define<Maps>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWorkCassandra>();

        }
    }
}
