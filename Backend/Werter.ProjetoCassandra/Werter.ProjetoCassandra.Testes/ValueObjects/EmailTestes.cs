using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;

namespace Werter.ProjetoCassandra.Testes.ValueObjects
{
    [TestClass]
    [TestCategory("Value Objects")]
    public class EmailTestes : TesteBase
    {
        [TestMethod]
        public void EmailDeveSerValido()
        {
            var email = new Email(Fake.Person.Email);

            email.Valid
                .Should().BeTrue(ExtrairAsNotificacoes(email));
        }

        [TestMethod]
        public void EmailInvalido()
        {
            var email = new Email("werter.bonfim@");

            email.Valid
                .Should().BeFalse(ExtrairAsNotificacoes(email));
        }
    }
}
