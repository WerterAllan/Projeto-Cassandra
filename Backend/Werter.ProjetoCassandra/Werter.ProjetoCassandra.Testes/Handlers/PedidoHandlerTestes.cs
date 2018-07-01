using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Service.Handlers;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.Queries;
using Werter.ProjetoCassandra.Domain.Converts;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using System.Linq.Expressions;

namespace Werter.ProjetoCassandra.Testes.Handlers
{
    [TestClass]
    [TestCategory("Handlers")]
    public class PedidoHandlerTestes : TesteBase
    {
        private IPedidoRepository _pedidoRepository;
        private IProdutoRepository _produtoRepository;
        private IClienteRepository _clienteRepository;
        private Cliente _clienteFake;
        private Produto _produto;
        private List<Produto> _produtos;
        


        [TestInitialize]
        public void SetUp()
        {
            _pedidoRepository = Substitute.For<IPedidoRepository>();
            _produtoRepository = Substitute.For<IProdutoRepository>();
            _clienteRepository = Substitute.For<IClienteRepository>();
            _clienteFake = GerarClienteFake();
            _produto = UmProduto();

            // Gera 5 produtos fake
            _produtos = Enumerable.Range(0, 5)
                .Select(x => UmProduto())
                .ToList();



        }

        private PedidoHandler _pedidoHandler => new PedidoHandler(_pedidoRepository, _clienteRepository, _produtoRepository);


        [TestMethod]
        public void HanderValido()
        {
            var command = GerarPedidoCommand();
            
            _clienteRepository.BuscarPorId(_clienteFake.Id).Returns(_clienteFake);

            var queryFake = Arg.Any<Expression<Func<Produto, bool>>>();
            _produtoRepository.Buscar(queryFake).Returns(_produtos);

            var retorno = _pedidoHandler.Handler(command);

            command.Valid
                .Should().BeTrue(ExtrairAsNotificacoes(command));

            retorno.Sucesso
                .Should().BeTrue();

        }

        private CreatePedidoCommand GerarPedidoCommand()
        {

            var itens = _produtos
                .Select(x => new CreatePedidoItemCommand
                {
                    Produto = x.Id,
                    Quantidade = GerarValor(1, 10)
                    
                })
                .ToList();

            

            return new CreatePedidoCommand
            {
                Cliente = _clienteFake.Id,
                ItensDoPedido = itens
            };
        }
    }
}
