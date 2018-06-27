using Microsoft.VisualStudio.TestTools.UnitTesting;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;
using FluentAssertions;

namespace Werter.ProjetoCassandra.Testes.ValueObjects
{
    [TestClass]
    [TestCategory("Value Objects")]
    public class NomeTeste : TesteBase
    {
        [TestMethod]
        public void DeveTerUmNomeESobreNomeValido()
        {
            var nome = new Nome("Werter", "Bonfim");

            nome.Valid
                .Should().BeTrue(ExtrairAsNotificacoes(nome));

        }

        [TestMethod]
        public void NomeInvalido()
        {
            var nome = new Nome("a", "b");

            nome.Invalid
                .Should().BeTrue(ExtrairAsNotificacoes(nome));
        }
    }
}
