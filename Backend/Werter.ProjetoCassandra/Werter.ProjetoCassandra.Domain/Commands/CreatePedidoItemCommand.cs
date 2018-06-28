using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Werter.ProjetoCassandra.Shared.Contracts;

namespace Werter.ProjetoCassandra.Domain.Commands
{
    public sealed class CreatePedidoItemCommand : Notifiable, ICommand
    {
        public Guid ProdutoId { get; set; }
        public Guid PedidoId { get; set; }
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
