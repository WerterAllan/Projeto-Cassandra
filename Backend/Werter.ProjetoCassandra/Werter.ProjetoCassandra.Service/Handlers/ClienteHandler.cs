using Flunt.Notifications;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Shared.Contracts;
using Werter.ProjetoCassandra.Shared.Handlers;

namespace Werter.ProjetoCassandra.Service.Handlers
{
    public sealed class ClienteHandler : Notifiable, 
        IHandler<CreateClienteCommand>
    {

        #region [ Create ]

        

        public IDtoResult Handler(CreateClienteCommand command)
        {
            //// Fail Fast Validation
            //if (CommandCreateEValido(command))
            //    return new CommandResult(false, "Não foi possivel registrar esse cliente");

            return null;
        }

        private bool CommandCreateEValido(CreateClienteCommand command)
        {            
            if (command.EValido())
                return true;

            AddNotifications(command);
            return false;

        }

        #endregion
    }
}
