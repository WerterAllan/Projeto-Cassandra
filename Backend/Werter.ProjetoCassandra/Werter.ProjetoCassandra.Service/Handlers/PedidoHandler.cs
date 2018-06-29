using Flunt.Notifications;
using System.Linq;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.Queries;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Shared.Handlers;

namespace Werter.ProjetoCassandra.Service.Handlers
{
    public sealed class PedidoHandler : Notifiable,
        IHandler<CreatePedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IProdutoRespository _produtoRepository;        

        public PedidoHandler(
            IPedidoRepository pedidoRepository,             
            IClienteRepository clienteRepository,
            IProdutoRespository produtoRespository
            )
        {
            _pedidoRepository = pedidoRepository;            
            _clienteRepository = clienteRepository;
            _produtoRepository = produtoRespository;
        }
        public ICommandResult Handler(CreatePedidoCommand command)
        {
            // Fail Fast Validation
            if (CommandEstaInvalido(command))
                return new CommandResult(false, "Não foi possível registrar esse pedido");

            var pedido = MontarOPedido(command);
            pedido.GerarPedido();

            AddNotifications(pedido.Notifications);

            if (Invalid)
                return new CommandResult(false, "Não foi possivel registrar esse pedido");

            _pedidoRepository.Inserir(pedido);

            return new CommandResult(true, "Pedido realizado com sucesso!");

        }

        private Pedido MontarOPedido(CreatePedidoCommand command)
        {
            var cliente = _clienteRepository.BuscarPorId(command.Cliente);
            var pedido = new Pedido(cliente);

            var idsProduto = command.ItensDoPedido.Select(x => x.Produto);
            var queryProdutos = ProdutoQueries.Listar(idsProduto);
            var produtos = _produtoRepository.Buscar(queryProdutos);

            foreach (var produto in produtos)
            {
                var quantidade = command.ItensDoPedido
                    .Find(x => x.Produto == produto.Id)
                    .Quantidade;

                pedido.AdicionarItem(produto, quantidade);
            }

            
            return pedido;
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
