using Microsoft.VisualStudio.TestTools.UnitTesting;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using FluentAssertions;

namespace Werter.ProjetoCassandra.Testes.Entities
{
    [TestClass]
    [TestCategory("Entities")]
    public sealed class PedidoItemTeste : TesteBase
    {
        [TestMethod]
        public void UmItemDePedidoValido()
        {
            var item = new PedidoItem(UmProduto(), 5);
            item.Valid
                .Should().BeTrue(ExtrairAsNotificacoes(item));
        }

        /// <summary>
        /// Deve ser inválido
        /// </summary>
        [TestMethod]
        public void UmItemDePedidoCom0Itens()
        {
            var item = new PedidoItem(UmProduto(), 0);

            item.Invalid
                .Should().BeTrue(ExtrairAsNotificacoes(item));
        }

        /// <summary>
        /// Deve ser valido
        /// </summary>
        [TestMethod]
        public void SubtotalDesteItemDeveSer200ReaisParaUmProdutoComDoisItens()
        {
            var produto = new Produto("Game FIFA 18 - PS4", "Melhor jogo de futebol do PS4", 100);
            var itemPedido = new PedidoItem(produto, 2);
            itemPedido.CalcularSubtotal();

            itemPedido.Subtotal
                .Should().Be(200, ExtrairAsNotificacoes(itemPedido));

        }
        
    }
}
