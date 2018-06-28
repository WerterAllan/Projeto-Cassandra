using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;
using Werter.ProjetoCassandra.Shared.Entities;

namespace Werter.ProjetoCassandra.Domain.StoreContext.Entities
{
    public class Cliente : EntityBase
    {
        public Cliente(Nome nome, Email email, Documento documento)
        {
            this.Nome = nome;
            this.Email = email;
            this.Documento = documento;
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public Documento Documento { get; private set; }

        public void Update(UpdateClienteCommand command)
        {
            this.Nome = new Nome(command.PrimeiroNome, command.UltimoNome);
            this.Email = new Email(command.Email);
            this.Documento = new Documento(command.Cpf);

        }

    }
}
