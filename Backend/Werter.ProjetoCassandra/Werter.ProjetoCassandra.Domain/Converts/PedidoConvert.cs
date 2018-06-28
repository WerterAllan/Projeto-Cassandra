using Werter.ProjetoCassandra.Domain.Commands;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Domain.StoreContext.FluentBuilder;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;

namespace Werter.ProjetoCassandra.Domain.Converts
{
    public static class PedidoConvert
    {
        public static Pedido ParaEntidadePedidoSemItens(this CreatePedidoCommand command)
        {
            var nome = ExtrairNome(command.NomeCliente);
            var pedido = new PedidoBuilder()
                .Nome(nome)
                .Documento(command.Cpf)
                .Email(command.Email)
                .Build();

            return pedido;
        }

        private static Nome ExtrairNome(string nome)
        {
            var nomesSeparados = nome.Split(new char[] { ' ' }, 2);
            return new Nome(nomesSeparados[0], nomesSeparados[1]);
        }
    }
}
