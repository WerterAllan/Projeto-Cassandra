using Microsoft.AspNetCore.Mvc;
using System;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.Contracts;
using Werter.ProjetoCassandra.Domain.Dtos;
using Werter.ProjetoCassandra.Service.Handlers;
using Werter.ProjetoCassandra.Service.Queries;
using Werter.ProjetoCassandra.Shared.Contracts;

namespace Werter.ProjetoCassandra.Api.Controllers
{
    [Route("api/v1/produtos/")]
    public class ProdutoController : BaseController
    {
        private readonly ProdutoHandler _produtoHandler;
        private readonly ProdutoQuery _query;
        public ProdutoController(IUnitOfWork unitOfWork, ProdutoHandler produtoHandler, ProdutoQuery query) : base(unitOfWork)
        {
            _produtoHandler = produtoHandler;
            _query = query;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var generico = _query.ListarTodos() as GenericListDto<ProdutoDto>;
                return Response(generico?.ListaDeObjetos, _query.Notifications);
            }
            catch (Exception erro)
            {
                return TratarErro(erro);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateProdutoCommand command)
        {
            try
            {
                var resultado = _produtoHandler.Handler(command);
                return Response(resultado, _produtoHandler.Notifications);
            }
            catch (Exception erro)
            {
                return TratarErro(erro);
            }
        }


        [HttpGet]
        [Route("Teste")]
        public IActionResult Teste()
        {
            try
            {
                var command = new CreateProdutoCommand
                {
                    Id = Guid.NewGuid(),
                    Descricao = "teste",
                    Preco = 10,
                    Titulo = "Teste produto"
                };
                var resultado = _produtoHandler.Handler(command);
                return Response(resultado, _produtoHandler.Notifications);
            }
            catch (Exception erro)
            {
                return TratarErro(erro);
            }
        }


    }
}
