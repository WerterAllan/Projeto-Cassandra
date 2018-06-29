using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;

namespace Werter.ProjetoCassandra.Infra.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("TB_Produtos");

            builder
                .HasKey(x => x.Id);

            builder.Property(x => x.Descricao).HasMaxLength(80);
            builder.Property(x => x.Titulo).HasMaxLength(80);
            builder.Property(x => x.Preco);

            builder.Ignore(x => x.Notifications);
            
                
        }
    }
}
