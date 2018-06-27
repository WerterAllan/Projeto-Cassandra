using Flunt.Notifications;
using Flunt.Validations;

namespace Werter.ProjetoCassandra.Domain.StoreContext.ValueObject
{
    public class Nome : Notifiable
    {
        public Nome(string primeiroNome, string ultimoSobreNome)
        {
            this.PrimeiroNome = primeiroNome;
            this.UltimoNome = ultimoSobreNome;

            if (string.IsNullOrEmpty(PrimeiroNome))
                AddNotification("PrimeiroNome", "Nome é um campo obrigatório");

            if (string.IsNullOrEmpty(ultimoSobreNome))
                AddNotification("UltimoNome", "Sobrenome é um campo obrigatório");

            var camposNaoForamPreenchidos =
                string.IsNullOrEmpty(PrimeiroNome) &&
                string.IsNullOrEmpty(UltimoNome);

            if (camposNaoForamPreenchidos)
                return;

            AddNotifications(new Contract()
               .HasMinLen(PrimeiroNome, 3, "PrimeiroNome", "O nome deve ter mais de 3 caracteres")
               .HasMaxLen(PrimeiroNome, 30, "PrimeiroNome", "O nome tem mais de 30 caracteres")
               .HasMinLen(UltimoNome, 0, "UltimoNome", "O sobre nome deve conter mais de 1 caractere ")
               .HasMaxLen(UltimoNome, 30, "UltimoNome", "O sobre nome não pode ter mais de 30 caracteres"));
        }

        public string PrimeiroNome { get; }
        public string UltimoNome { get; }

        public override string ToString()
        {
            return $"{ PrimeiroNome } { UltimoNome }";
        }
    }
}
