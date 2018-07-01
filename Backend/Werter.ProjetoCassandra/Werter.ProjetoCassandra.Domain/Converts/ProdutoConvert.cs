using System;
using System.Collections.Generic;
using System.Linq;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.Dtos;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;

namespace Werter.ProjetoCassandra.Domain.Converts
{
    public static class ProdutoConvert
    {
        public static Produto ParaEntidade(this CreateProdutoCommand command)
        {
            return new Produto(command.Titulo, command.Descricao, command.Preco);
        }
        public static IEnumerable<Guid> ExtrairProdutosIds(this CreatePedidoCommand command)
        {
            return command.ItensDoPedido
                .Select(x => x.Produto)
                .ToList();

        }

        public static IEnumerable<ProdutoDto> ParaDto(this IList<Produto> produtoEntity)
        {
            return produtoEntity.Select(x => new ProdutoDto
            {
                Id = x.Id,
                Descricao = x.Descricao,
                Preco = x.Preco,
                QuantidadeEmEstoque = x.QuantidadeEmEstoque,
                Titulo = x.Titulo
            });
        }
    }
}
