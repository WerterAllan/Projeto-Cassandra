using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Werter.ProjetoCassandra.Infra.Repository;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Infra.Context;

namespace Werter.ProjetoCassandra.Api.DependencyInjection
{
    public static class DependencyInjectionEFContext
    {
        public static void AddDependency(IServiceCollection services)
        {
            // repositories
            services.AddTransient<IProdutoRepository, ProdutoRepository>();

            // dbContext
            // aqui eu posso implementar outra estrategia para obter a string de conexão
            services.AddScoped(x => new StoreContext("Server=(localdb)\\WerterStoreDb;Database=WerterDb;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }
    }
}
