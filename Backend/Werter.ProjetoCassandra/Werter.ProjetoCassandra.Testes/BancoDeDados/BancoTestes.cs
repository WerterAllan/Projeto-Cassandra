using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Werter.ProjetoCassandra.Infra.Context;
using Werter.ProjetoCassandra.SqlLocalDatabase;

namespace Werter.ProjetoCassandra.Testes.BancoDeDados
{
    [TestClass]
    public sealed class BancoTestes : TesteBase
    {
        [TestMethod]
        public void DeveFazerUmaSimplesConexao()
        {

            var stringDeConexao = DatabaseHelper.GetLocalDbStringConnection();
            using (var conexao = new SqlConnection(stringDeConexao))
            {
                conexao.Open();
            }

        }

        [TestMethod]
        public void DeveInicializarOBancoDeDadosComSucesso()
        {
            using (var context = new StoreContext())
            {
                
                var produto = UmProduto();

                context.Produtos.Add(produto);
                context.SaveChanges();

                foreach (var item in context.Produtos)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
