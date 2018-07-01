using Cassandra.Mapping;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;

namespace Werter.ProjetoCassandra.Infra.Cassandra.Mapping
{
    public class Maps : Mappings
    {
        public Maps()
        {
            For<Produto>()
                .TableName("produto");
                

        }
    }
}
