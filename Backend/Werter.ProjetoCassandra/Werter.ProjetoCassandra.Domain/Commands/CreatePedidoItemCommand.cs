using Flunt.Notifications;
using Flunt.Validations;
using System;
using Werter.ProjetoCassandra.Shared.Contracts;

namespace Werter.ProjetoCassandra.Domain.Commands
{
    public sealed class CreatePedidoItemCommand : Notifiable, ICommand
    {
        public Guid Produto { get; set; }
        public int Quantidade { get; set; }

        public bool EValido()
        {
            AddNotifications(new Contract()
              .IsGreaterThan(0, Quantidade, "Quantidade", "Quantide de produto inválida")
              );

            return Valid;
        }
    }
}
