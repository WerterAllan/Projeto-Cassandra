using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.SqlClient;
using Werter.ProjetoCassandra.Infra.Context;
using Werter.ProjetoCassandra.SqlLocalDatabase;

namespace Werter.ProjetoCassandra.Testes.BancoDeDados
{
    [TestClass]
    public sealed class BancoTestes : TesteBase
    {

        private string _stringDeConexao;

        [TestInitialize]
        public void SetUp()
        {            
            var dbHelper = new DatabaseHelper("WerterStoreDb");
            dbHelper.CriarInstanciaDoBancoLocal();
            _stringDeConexao = dbHelper.ObterAStringDeConexaoLocalDb();

        }

        //[TestMethod]
        public void DeveFazerUmaSimplesConexao()
        {            
            using (var conexao = new SqlConnection(_stringDeConexao))
            {
                conexao.Open();
            }

        }

        [TestMethod]        
        public void DeveInicializarOBancoDeDadosComSucesso()
        {
            using (var context = new StoreContext(_stringDeConexao))
            {
                //context.Database.EnsureDeleted();                                
                //context.Database.Migrate();

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
