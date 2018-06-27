using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using Werter.ProjetoCassandra.Shared.Entities;

namespace Werter.ProjetoCassandra.Domain.StoreContext.Entities
{
    public class Pedido : EntityBase
    {
        public Pedido(Cliente cliente)
        {
            Cliente = cliente;
            DataDoPedido = DateTime.Now;
            _itens = new List<PedidoItem>();
        }

        private List<PedidoItem> _itens;

        /// <summary>
        /// Numero do pedido que sera apresentado para o usuario
        /// </summary>
        public string NumeroPedido { get; set; }

        public Cliente Cliente { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataDoPedido { get; private set; }

        public IReadOnlyCollection<PedidoItem> Items => _itens.ToList();

        public void AdicionarItem(Produto produto, int quantidade)
        {
            this._itens.Add(new PedidoItem(produto, quantidade));
        }

        public void GerarPedido()
        {
            NumeroPedido = Guid.NewGuid()
               .ToString()
               .Replace("-", "")
               .Substring(0, 8)
               .ToUpper();

            ValorTotal = _itens.Sum(x => x.CalcularSubtotal());

            AddNotifications(new Contract()
               .IsGreaterThan(_itens.Count, 0, "Pedido", "Este pedido não possui itens"));
        }

    }
}
