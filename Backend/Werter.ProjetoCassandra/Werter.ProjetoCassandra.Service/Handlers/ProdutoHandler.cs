using Flunt.Notifications;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.Converts;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Shared.Handlers;

namespace Werter.ProjetoCassandra.Service.Handlers
{
    public class ProdutoHandler : Notifiable,
        IHandler<CreateProdutoCommand>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoHandler(IProdutoRepository produtoRespository)
        {
            _produtoRepository = produtoRespository;
        }

        public ICommandResult Handler(CreateProdutoCommand command)
        {
            // Fail Fast Validation
            if (CommandEstaInvalido(command))
                return new CommandResult(false, "Não foi possível registrar esse pedido");

            var produto = command.ParaEntidade();

            AddNotifications(produto.Notifications);

            if (Invalid)
                return new CommandResult(false, "Não foi possivel registrar esse pedido");

            _produtoRepository.Inserir(produto);

            return new CommandResult(true, "Produto registrado com sucesso");

        }

        private bool CommandEstaInvalido(CreateProdutoCommand command)
        {
            if (!command.EValido())
                return true;

            AddNotifications(command);
            return false;

        }
    }
}
