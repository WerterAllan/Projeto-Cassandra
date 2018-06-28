using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Shared.Handlers;
using Werter.ProjetoCassandra.Domain.Converts;


namespace Werter.ProjetoCassandra.Service.Handlers
{
    public sealed class PedidoHandler : Notifiable,
        IHandler<CreatePedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly PedidoItemHandler _pedidoItemHandler;

        public PedidoHandler(IPedidoRepository pedidoRepository, PedidoItemHandler pedidoItemHandler)
        {
            _pedidoRepository = pedidoRepository;
            _pedidoItemHandler = pedidoItemHandler;
        }
        public ICommandResult Handler(CreatePedidoCommand command)
        {
            // Fail Fast Validation
            if (CommandEstaInvalido(command))
                return new CommandResult(false, "Não foi possível registrar esse pedido");

            var pedido = command.ParaEntidadePedidoSemItens();


            return new CommandResult(true, "Pedido realizado com sucesso!");

        }


        private bool CommandEstaInvalido(CreatePedidoCommand command)
        {
            if (!command.EValido())
                return true;

            AddNotifications(command);
            return false;

        }
    }
}
