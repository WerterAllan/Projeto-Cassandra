using System;
using System.Diagnostics;

namespace Werter.ProjetoCassandra.SqlLocalDatabase
{
    public class DatabaseHelper
    {
        private readonly string _nomeDaInstanciaDoBancoDeDados;
        public DatabaseHelper(string nomeDaInstancia)
        {
            _nomeDaInstanciaDoBancoDeDados = nomeDaInstancia;            
        }


        /// <summary>
        /// Obtem a string de conexão de um banco local para a realização de testes
        /// </summary>
        /// <returns></returns>
        public string ObterAStringDeConexaoLocalDb()
        {
            var stringDeConexao = $"Server=(localdb)\\{_nomeDaInstanciaDoBancoDeDados};Database=WerterDb;Trusted_Connection=True;MultipleActiveResultSets=true";
            return stringDeConexao;
        }

        public void CriarInstanciaDoBancoLocal(bool recriarCasoJaExista = true)
        {
            var comandoQueDeleta = $"SqlLocalDB.exe delete {_nomeDaInstanciaDoBancoDeDados}";
            if (recriarCasoJaExista)
                ExecutaComandoCmd(comandoQueDeleta);

            var comando = $"SqlLocalDB.exe create {_nomeDaInstanciaDoBancoDeDados} -s";
            ExecutaComandoCmd(comando);

        }

        private void ExecutaComandoCmd(string comando)
        {
            Console.WriteLine("Criando banco local: {0}", _nomeDaInstanciaDoBancoDeDados);
            var process = new Process
            {
                StartInfo = CriarStartInfo(),
                
            };
            process.Start();
            process.StandardInput.WriteLine(comando);
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());

        }

        private static ProcessStartInfo CriarStartInfo()
        {
            return new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
            };
        }
    }
}
