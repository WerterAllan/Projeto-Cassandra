using Flunt.Notifications;
using System.Linq;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.Converts;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Shared.Handlers;

namespace Werter.ProjetoCassandra.Service.Handlers
{
    public sealed class ClienteHandler : Notifiable,
        IHandler<CreateClienteCommand>,
        IHandler<UpdateClienteCommand>
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteHandler(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        #region [ Create ]



        public ICommandResult Handler(CreateClienteCommand command)
        {
            // Fail Fast Validation
            if (CommandEstaInvalido(command))
                return new CommandResult(false, "Não foi possível registrar esse cliente");

            VerificaSeCpfJaFoiRegistrado(command.Cpf);
            VerificaSeEmaiJaFoiRegistrado(command.Email);


            var cliente = command.ParaEntidadeCliente();
            AdicionarNotificacoes(cliente);

            if (Invalid)
                return new CommandResult(false, "Não foi cadastrar o cliente");

            PersistirCliente(cliente);


            return new CommandResult(true, "Cliente cadastrado com sucesso!");
        }

        private void PersistirCliente(Cliente cliente)
        {
            _clienteRepository.Registrar(cliente);
        }


        #region [ Validações ]        

        /// <summary>
        /// Aplica a validação da entidade e dos VOs
        /// </summary>
        /// <param name="cliente"></param>
        private void AdicionarNotificacoes(Cliente cliente)
        {
            AddNotifications(cliente.Nome.Notifications);
            AddNotifications(cliente.Email.Notifications);
            AddNotifications(cliente.Documento.Notifications);
            AddNotifications(cliente.Notifications);

        }

        private void VerificaSeEmaiJaFoiRegistrado(string email)
        {
            var jaFoiRegistrado = _clienteRepository.EmailExiste(email);
            if (jaFoiRegistrado)
                AddNotification("Email", "Email já está em uso");
        }

        private void VerificaSeCpfJaFoiRegistrado(string cpf)
        {
            var jaFoiRegistrado = _clienteRepository.CpfExiste(cpf);
            if (jaFoiRegistrado)
                AddNotification("Cpf", "Este CPF já está em uso");
        }

        private bool CommandEstaInvalido(CreateClienteCommand command)
        {
            if (!command.EValido())
                return true;

            AddNotifications(command);
            return false;

        }



        #endregion

        #endregion

        #region [ Update ]

        public ICommandResult Handler(UpdateClienteCommand command)
        {
            if (CommandEstaInvalido(command))
                return new CommandResult(false, "Não foi possivel atualizar o cliente");

            var cliente = _clienteRepository.Buscar(x => x.Id == command.Id).FirstOrDefault();
            cliente.Update(command);
            AddNotifications(cliente.Notifications);

            _clienteRepository.Atualizar(cliente);

            return new CommandResult(true, "Cliente atualizado com sucesso");

        }


        #region [ Validações ]

        private bool CommandEstaInvalido(UpdateClienteCommand command)
        {
            if (!command.EValido())
                return true;

            AddNotifications(command);
            return false;

        }
        #endregion


        #endregion
    }
}
