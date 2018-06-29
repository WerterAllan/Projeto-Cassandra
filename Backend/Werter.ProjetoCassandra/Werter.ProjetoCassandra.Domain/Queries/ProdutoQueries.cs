using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;

namespace Werter.ProjetoCassandra.Domain.Queries
{
    public static class ProdutoQueries
    {
        public static Expression<Func<Produto, bool>> Listar(IEnumerable<Guid> ids)
        {
            return x => ids.Contains(x.Id);
        }
    }
}
