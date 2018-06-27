using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bogus;
using Bogus.Extensions.Brazil;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;
using FluentAssertions;

namespace Werter.ProjetoCassandra.Testes.ValueObjects
{
    [TestClass]
    [TestCategory("Value Objects")]
    public class DocumentoTeste : TesteBase
    {
        /// <summary>
        /// Deve retornar uma notificação para um documento 
        /// inválido
        /// </summary>
        [TestMethod]        
        public void DocumentoInvalido()
        {
            var documento = new Documento("12345678900");
            documento.Invalid.Should().BeTrue(ExtrairAsNotificacoes(documento));
        }

        /// <summary>
        /// Não deve retonar nenhuma notificação para um
        /// documento valido
        /// </summary>
        [TestMethod]
        public void DocumentoValido()
        {
            var documento = new Documento(Fake.Person.Cpf());
            documento.Valid.Should().BeTrue(ExtrairAsNotificacoes(documento));
        }
    }
}
