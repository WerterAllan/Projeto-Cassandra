using Flunt.Notifications;
using Flunt.Validations;

namespace Werter.ProjetoCassandra.Domain.StoreContext.ValueObject
{
    public sealed class Email : Notifiable
    {
        public Email(string enderecoDeEmail)
        {
            EnderecoDeEmail = enderecoDeEmail;

            AddNotifications(new Contract()
                .IsEmail(enderecoDeEmail, "Email", "O E-Mail é inválido"));
        }

        public string EnderecoDeEmail { get; private set; }

        public override string ToString()
        {
            return EnderecoDeEmail;
        }
    }
}
