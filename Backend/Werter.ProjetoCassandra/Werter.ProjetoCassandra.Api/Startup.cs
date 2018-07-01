using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Werter.ProjetoCassandra.Api.DependencyInjection;
using Werter.ProjetoCassandra.Domain.Contracts;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Infra.Context;
using Werter.ProjetoCassandra.Infra.Repository;
using Werter.ProjetoCassandra.Service.Handlers;
using Werter.ProjetoCassandra.Service.Queries;

namespace Werter.ProjetoCassandra.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // queries
            services.AddTransient<ProdutoQuery, ProdutoQuery>();

            // handlers
            services.AddTransient<ProdutoHandler, ProdutoHandler>();

            
            // Contexto EF Core
            //DependencyInjectionEFContext.AddDependency(services);

            // Contexto cassandra
            DependencyInjectionCassandraContext.AddDependency(services);

        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
