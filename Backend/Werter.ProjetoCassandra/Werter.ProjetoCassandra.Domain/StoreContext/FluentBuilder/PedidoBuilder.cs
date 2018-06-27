using System;
using System.Collections.Generic;
using Werter.ProjetoCassandra.Domain.StoreContext.Entities;
using Werter.ProjetoCassandra.Domain.StoreContext.ValueObject;

namespace Werter.ProjetoCassandra.Domain.StoreContext.FluentBuilder
{
    public sealed class PedidoBuilder : FluentBuilderBase<Pedido>
    {
        private string _primeiroNome;
        private string _ultimoNome;
        private string _numeroDocumento;
        private string _enderecoDeEmail;
        private List<Tuple<Produto, int>> _itensDoPedido;

        public PedidoBuilder()
        {
            _itensDoPedido = new List<Tuple<Produto, int>>();
        }

        public PedidoBuilder Nome(string primeiroNome, string ultimoNome)
        {
            this._primeiroNome = primeiroNome;
            this._ultimoNome = ultimoNome;
            return this;
        }

        public PedidoBuilder Documento(string numeroDoDocumento)
        {
            _numeroDocumento = numeroDoDocumento;
            return this;    
        }

        public PedidoBuilder Email(string enderecoDeEmail)
        {
            this._enderecoDeEmail = enderecoDeEmail;
            return this;
        }

        public PedidoBuilder AdicionarProduto(string titulo, string descricao, decimal preco, int quantidade)
        {
            var produto = new Produto(titulo, descricao, preco);
            _itensDoPedido.Add(new Tuple<Produto, int>(produto, quantidade));
            return this;
        }

        public PedidoBuilder AdicionarProduto(Produto produto, int quantidade)
        {            
            _itensDoPedido.Add(new Tuple<Produto, int>(produto, quantidade));
            return this;
        }


        public override Pedido Build()
        {
            var nome = new Nome(_primeiroNome, _ultimoNome);
            var documento = new Documento(_numeroDocumento);
            var email = new Email(_enderecoDeEmail);
            var cliente = new Cliente(nome, email, documento);
            var pedido = new Pedido(cliente);

            foreach (var item in _itensDoPedido)
                pedido.AdicionarItem(item.Item1, item.Item2);
            

            return pedido;

        }
    }
}
