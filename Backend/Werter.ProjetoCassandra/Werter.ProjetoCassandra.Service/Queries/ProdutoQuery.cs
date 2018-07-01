using Flunt.Notifications;
using System;
using System.Collections.Generic;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Shared.Contracts;
using Werter.ProjetoCassandra.Domain.Converts;
using Werter.ProjetoCassandra.Domain.Dtos;
using System.Linq;

namespace Werter.ProjetoCassandra.Service.Queries
{
    public sealed class ProdutoQuery : Notifiable, IReadQuery<Produto, Guid>, IQuery
    {
        private readonly IProdutoRepository _produtoRespository;
        public ProdutoQuery(IProdutoRepository produtoRespository)
        {
            _produtoRespository = produtoRespository;
        }

        public IDtoResult Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public IDtoResult ListarTodos()
        {
            var produtosDto = _produtoRespository
                .Listar()
                .ParaDto()
                .ToList();

            return new GenericListDto<ProdutoDto>(produtosDto);
        }

        public IDtoResult Buscar(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}
