using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.Repositories;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Service.Handlers;
using Werter.ProjetoCassandra.Testes.Helpers;
using System.Linq.Expressions;

namespace Werter.ProjetoCassandra.Testes.Handlers
{
    [TestClass]
    [TestCategory("Handlers - Cliente")]
    public class ClienteHandlerTeste : TesteBase
    {

        private IClienteRepository _clienteRepository;
        private Cliente _clienteFake;

        [TestInitialize]
        public void SetUp()
        {
            this._clienteRepository = Substitute.For<IClienteRepository>();
            this._clienteFake = GerarClienteFake();
        }

        #region [ Create ]


        [TestMethod]
        public void HandlerValido()
        {
            _clienteRepository.CpfExiste(_clienteFake.Documento.Numero).Returns(false);
            _clienteRepository.EmailExiste(_clienteFake.Email.EnderecoDeEmail).Returns(false);

            var command = GerarCreateCommand();

            var clienteHandler = new ClienteHandler(_clienteRepository);
            clienteHandler.Handler(command);

            var resultado = clienteHandler.Handler(command);

            resultado.Sucesso
                .Should().BeTrue("Porque o Email e Cpf não foram registrados na base");

            clienteHandler.Valid
                .Should().BeTrue(ExtrairAsNotificacoes(clienteHandler));
        }



        [TestMethod]
        public void HandlerInvalidoParaEmailECpfJaCadastrados()
        {

            _clienteRepository.CpfExiste(_clienteFake.Documento.Numero).Returns(true);
            _clienteRepository.EmailExiste(_clienteFake.Email.EnderecoDeEmail).Returns(true);

            var command = GerarCreateCommand();

            var clienteHandler = new ClienteHandler(_clienteRepository);
            var resultado = clienteHandler.Handler(command);

            resultado.Sucesso
                .Should().BeFalse("Porque o Email e Cpf já foram registrados na base");


            clienteHandler.Invalid
                .Should().BeTrue(ExtrairAsNotificacoes(clienteHandler));
        }

        #endregion


        #region [ Update ]



        [TestMethod]
        public void DeveAtualizar()
        {
            var queryClientes = new List<Cliente>() { _clienteFake };
            //_clienteRepository.Buscar(x => x.Id == _clienteFake.Id).Returns(queryClientes);

            _clienteRepository.Buscar(Arg.Any<Expression<Func<Cliente, bool>>>())
                .Returns( x => queryClientes );

            var updateCommand = GerarUpdateCommand();

            var retorno = _clienteHandler.Handler(updateCommand);

            retorno.Sucesso
                .Should().BeTrue();

            updateCommand.Valid
                .Should().BeTrue(ExtrairAsNotificacoes(updateCommand));

        }

        #endregion


        private ClienteHandler _clienteHandler => new ClienteHandler(_clienteRepository);

        private CreateClienteCommand GerarCreateCommand()
        {
            return new CreateClienteCommand
            {
                PrimeiroNome = Fake.Name.FirstName(),
                UltimoNome = Fake.Name.LastName(),
                Cpf = _clienteFake.Documento.Numero,
                Email = _clienteFake.Email.EnderecoDeEmail
            };
        }
        private UpdateClienteCommand GerarUpdateCommand()
        {
            return new UpdateClienteCommand
            {
                Id = _clienteFake.Id,
                Cpf = Fake.Person.Cpf(),
                Email = Fake.Person.Email.ToLower(),
                PrimeiroNome = Fake.Person.FirstName,
                UltimoNome = Fake.Person.LastName
            };
        }
    }
}
