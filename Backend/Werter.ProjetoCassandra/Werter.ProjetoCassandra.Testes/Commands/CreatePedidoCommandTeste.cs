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
            var command = new CreatePedidoCommand
            {
                Cpf = Fake.Person.Cpf(),
                DataPedido = DateTime.Now,
                Email = Fake.Person.Email,
                NomeCliente = $"{ Fake.Person.FirstName } { Fake.Person.LastName }",
                ValorTotal = Fake.Random.Decimal(100, 10000)
            };

            command.EValido()
                .Should().BeTrue(ExtrairAsNotificacoes(command));

        }
    }
}
