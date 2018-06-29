using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using Werter.ProjetoCassandra.Shared.Contracts;

namespace Werter.ProjetoCassandra.Domain.Commands
{
    public sealed class CreatePedidoCommand : Notifiable, ICommand
    {

        public Guid Cliente { get; set; }        
        public List<CreatePedidoItemCommand> ItensDoPedido { get; set; }

        public CreatePedidoCommand()
        {
            this.ItensDoPedido = new List<CreatePedidoItemCommand>();
        }
        


        public bool EValido()
        {
            AddNotifications(new Contract()
              .HasLen(Cliente.ToString(), 36, "Cliente", "Indentificador do cliente é inválido")
              .IsGreaterThan(ItensDoPedido.Count, 0, "ItensDoPedido", "Nenhum item do pedido foi encontrado")
              );

            return Valid;
        }
    }
}
