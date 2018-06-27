using Flunt.Validations;
using System;
using Werter.ProjetoCassandra.Shared.Entities;

namespace Werter.ProjetoCassandra.Domain.StoreContext.Entities
{
    public class PedidoItem : EntityBase
    {

        public PedidoItem(Produto produto, int quantidade)
        {
            Produto = produto;
            Quantidade = quantidade;

            AddNotifications(new Contract()
                .IsLowerThan(0, quantidade, "PedidoItem", "Quantidade de produto informada é inválida"));
        }

        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal Subtotal { get; private set; }

        public decimal CalcularSubtotal()
        {
            Subtotal = Produto.Preco * Quantidade;
            return Subtotal;
        }
    }
}
