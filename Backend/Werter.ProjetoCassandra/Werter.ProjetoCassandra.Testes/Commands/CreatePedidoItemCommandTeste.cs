using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Werter.ProjetoCassandra.Domain.Commands;

namespace Werter.ProjetoCassandra.Testes.Commands
{
    [TestClass]
    [TestCategory("Commands")]
    public sealed class CreatePedidoItemCommandTeste : TesteBase
    {

        [TestMethod]
        public void PedidoItemValido()
        {
            var command = new CreatePedidoItemCommand
            {
                Produto = Guid.NewGuid(),                
                Quantidade = 1
            };

            command.EValido()
                .Should().BeTrue(ExtrairAsNotificacoes(command));

        }
    }
}
