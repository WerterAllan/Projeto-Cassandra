using System;
using System.Collections.Generic;
using System.Linq;
using Werter.ProjetoCassandra.Domain.Commands;

namespace Werter.ProjetoCassandra.Domain.Converts
{
    public static class ProdutoConvert
    {
        public static IEnumerable<Guid> ExtrairProdutosIds(this CreatePedidoCommand command)
        {
            return command.ItensDoPedido
                .Select(x => x.Produto)
                .ToList();
                
        }
    }
}
