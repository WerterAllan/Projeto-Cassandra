using System;
using System.IO;

namespace Werter.ProjetoCassandra.SqlLocalDatabase
{
    public class DatabaseHelper
    {
        /// <summary>
        /// Obtem a string de conexão de um banco local para a realização de testes
        /// </summary>
        /// <returns></returns>
        public static string GetLocalDbStringConnection()
        {
            var caminhoAssembly = new DirectoryInfo(Environment.CurrentDirectory)
                .Parent.Parent.Parent.Parent.FullName;

            var caminhoBanco = Path.Combine(caminhoAssembly, "Werter.ProjetoCassandra.SqlLocalDatabase", "StoreDb.mdf");
            var stringDeConexao = string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0};Integrated Security=True", caminhoBanco);
            //Console.WriteLine(stringDeConexao);
            return stringDeConexao;
        }
    }
}
