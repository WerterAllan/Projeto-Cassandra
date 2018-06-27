using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bogus.Extensions.Brazil;
using Werter.ProjetoCassandra.Domain.Commands;
using FluentAssertions;

namespace Werter.ProjetoCassandra.Testes.Commands
{
    [TestClass]
    public sealed class CreateClienteCommandTeste : TesteBase
    {
        [TestMethod]
        public void CommandValido()
        {
            var command = new CreateClienteCommand
            {
                PrimeiroNome = Fake.Person.FirstName,
                UltimoNome = Fake.Person.LastName,
                Email = Fake.Person.Email,
                Cpf = Fake.Person.Cpf()
            };

            command.EValido()
                .Should().BeTrue(ExtrairAsNotificacoes(command));
        }

    }
}
