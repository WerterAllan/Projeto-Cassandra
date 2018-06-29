using Bogus.Extensions.Brazil;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Werter.ProjetoCassandra.Domain.Commands;

namespace Werter.ProjetoCassandra.Testes.Commands
{
    [TestClass]
    public sealed class CreatePedidoCommandTeste : TesteBase
    {
        [TestMethod]
        public void PedidoValido()
        {
            var command = new CreatePedidoCommand { Cliente = Guid.NewGuid() };
            var item = new CreatePedidoItemCommand
            {
                Produto = Guid.NewGuid(),
                Quantidade = 2
            };

            command.ItensDoPedido.Add(item);
            

            command.EValido()
                .Should().BeTrue(ExtrairAsNotificacoes(command));

        }
    }
}
