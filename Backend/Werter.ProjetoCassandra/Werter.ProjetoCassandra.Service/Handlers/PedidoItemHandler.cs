using Flunt.Notifications;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Shared.Handlers;

namespace Werter.ProjetoCassandra.Service.Handlers
{
    public class PedidoItemHandler : Notifiable, IHandler<CreatePedidoItemCommand>
    {
        public ICommandResult Handler(CreatePedidoItemCommand command)
        {
            // Fail Fast Validation
            if (CommandEstaInvalido(command))
                return new CommandResult(false, "Não foi possível registrar o item deste pedido");

            return new CommandResult(true, "Item do pedido inserido com sucesso");
        }

        private bool CommandEstaInvalido(CreatePedidoItemCommand command)
        {
            if (!command.EValido())
                return true;

            AddNotifications(command);
            return false;

        }
    }
}
