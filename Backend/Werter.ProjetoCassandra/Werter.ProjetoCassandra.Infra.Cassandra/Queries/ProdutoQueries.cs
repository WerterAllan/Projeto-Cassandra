using Cassandra.Mapping;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;

namespace Werter.ProjetoCassandra.Infra.Cassandra.Queries
{
    public class ProdutoQueries
    {
        public static Cql Update(Produto produto)
        {
            var query =
                "UPDATE Produto SET Titulo = ?, " +
                "Descricao = ?, " +
                "Preco = ? " +
                "WHERE Id = ?";
            var cql = new Cql(query,
                produto.Titulo,
                produto.Descricao,
                produto.Preco,
                produto.Id
                );

            return cql;
        }
        
    }
}
