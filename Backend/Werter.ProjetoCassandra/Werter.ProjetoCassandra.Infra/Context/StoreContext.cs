using Microsoft.EntityFrameworkCore;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Infra.Mapping;

namespace Werter.ProjetoCassandra.Infra.Context
{
    public class StoreContext : DbContext
    {
        private readonly string _stringDeConexao;
        public StoreContext(string stringDeConexao)
        {
            _stringDeConexao = stringDeConexao;
        }


        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer(_stringDeConexao, config => config.EnableRetryOnFailure());
            optionsBuilder.UseSqlServer(_stringDeConexao);
            


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());

        }





    }
}
