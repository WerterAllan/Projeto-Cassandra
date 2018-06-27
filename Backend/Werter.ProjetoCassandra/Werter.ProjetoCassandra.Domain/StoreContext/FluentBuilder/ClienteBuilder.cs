using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;

namespace Werter.ProjetoCassandra.Domain.StoreContext.FluentBuilder
{
    public class ClienteBuilder : FluentBuilderBase<Cliente>
    {
        private string _primeiroNome;
        private string _ultimoNome;
        private string _enderecoDeEmail;
        private string _numeroDoDocumento;

        public ClienteBuilder Nome(string primeiroNome, string ultimoNome)
        {
            this._primeiroNome = primeiroNome;
            this._ultimoNome = ultimoNome;
            return this;
        }

        public ClienteBuilder Email(string enderecoDeEmail)
        {
            this._enderecoDeEmail = enderecoDeEmail;
            return this;
        }

        public ClienteBuilder Documento(string numeroDocumento)
        {
            this._numeroDoDocumento = numeroDocumento;
            return this;
        }

        public override Cliente Build()
        {
            var nome = new Nome(_primeiroNome, _ultimoNome);
            var email = new Email(_enderecoDeEmail);
            var documento = new Documento(_numeroDoDocumento);

            var cliente = new Cliente(nome, email, documento);

            return cliente;

        }
    }
}
