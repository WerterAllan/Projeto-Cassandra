using Flunt.Notifications;
using Flunt.Validations;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;
using Werter.ProjetoCassandra.Shared.Contracts;

namespace Werter.ProjetoCassandra.Domain.Commands
{
    public sealed class CreateClienteCommand : Notifiable, ICommand
    {
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        public bool EValido()
        {
            AddNotifications(new Contract()
               .HasMinLen(PrimeiroNome, 3, "PrimeiroNome", "O nome deve ter mais de 3 caracteres")
               .HasMaxLen(PrimeiroNome, 30, "PrimeiroNome", "O nome tem mais de 30 caracteres")
               .HasMinLen(UltimoNome, 0, "UltimoNome", "O sobre nome deve conter mais de 1 caractere ")
               .HasMaxLen(UltimoNome, 30, "UltimoNome", "O sobre nome não pode ter mais de 30 caracteres")
               .IsEmail(Email, "Email", "Email inválido")
               .IsTrue(Documento.CpfValido(Cpf), "Cpf", "Cpf inválido")
               );

            return Valid;
        }

    }
}
