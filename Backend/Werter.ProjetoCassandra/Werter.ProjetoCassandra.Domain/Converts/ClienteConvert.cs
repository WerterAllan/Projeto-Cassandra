using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Domain.StoreContext.FluentBuilder;

namespace Werter.ProjetoCassandra.Domain.Converts
{
    public static class ClienteConvert
    {
        public static Cliente ParaEntidadeCliente(this CreateClienteCommand command)
        {
            var cliente = new ClienteBuilder()
                .Nome(command.PrimeiroNome, command.UltimoNome)
                .Documento(command.Cpf)
                .Email(command.Email)
                .Build();

            return cliente;
        }
    }
}
