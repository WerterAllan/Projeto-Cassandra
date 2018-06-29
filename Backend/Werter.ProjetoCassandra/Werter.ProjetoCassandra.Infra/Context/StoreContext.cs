using Microsoft.EntityFrameworkCore;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Infra.Mapping;
using Werter.ProjetoCassandra.SqlLocalDatabase;

namespace Werter.ProjetoCassandra.Infra.Context
{
    public class StoreContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringDeConexao = DatabaseHelper.GetLocalDbStringConnection();
            optionsBuilder.UseSqlServer(stringDeConexao);   
            
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            
        }





    }
}
