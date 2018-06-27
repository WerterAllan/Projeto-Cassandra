using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Werter.ProjetoCassandra.Testes.Entities
{
    [TestClass]
    [TestCategory("Entities")]
    public class PedidoTestes : TesteBase
    {
        [TestMethod]
        public void CriarUmNovoPedido()
        {
            var pedido = MontarPedidoBasico()
                .Build();

            pedido.Valid
                .Should().BeTrue(ExtrairAsNotificacoes(pedido));
        }

        [TestMethod]
        public void DeveConterAMesmaQuantidadeDeItens()
        {
            var pedido = MontarPedidoBasico()
                .AdicionarProduto(UmProduto(), 5)
                .AdicionarProduto(UmProduto(), 5)
                .Build();

            pedido.Items.Count.Should().Be(2, ExtrairAsNotificacoes(pedido));
        }

        [TestMethod]
        public void DeveGerarUmNumeroDePedidoQuandoEleForConfirmado()
        {
            var pedido = MontarUmPedidoSimples();

            pedido.GerarPedido();
            pedido.NumeroPedido.Should().NotBeNullOrEmpty();
        }

    }
}
