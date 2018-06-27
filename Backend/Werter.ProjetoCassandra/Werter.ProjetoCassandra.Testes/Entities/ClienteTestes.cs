using Microsoft.VisualStudio.TestTools.UnitTesting;
using Werter.ProjetoCassandra.Domain.StoreContext.FluentBuilder;
using Bogus.Extensions.Brazil;
using FluentAssertions;

namespace Werter.ProjetoCassandra.Testes.Entities
{
    [TestClass]
    [TestCategory("Entities")]
    public sealed class ClienteTestes : TesteBase
    {
        [TestMethod]
        public void ClienteValido()
        {
            var cliente = new ClienteBuilder()
                .Nome(Fake.Person.FirstName, Fake.Person.LastName)
                .Email(Fake.Person.Email)
                .Documento(Fake.Person.Cpf())
                .Build();

            cliente.Valid
                .Should().BeTrue(ExtrairAsNotificacoes(cliente));
        }

    }
}
