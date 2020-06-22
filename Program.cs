using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using teste_aula_13.Controller;
using teste_aula_13.Repositorio;

namespace teste_aula_13
{
    static class Program
    {
        private static DbConnection ObterConexao()
        {
            var stringDeConexao = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=Empresa";

            //Criando conexão com base na string de conexão, no usuário e a senha do banco de dados
            return new NpgsqlConnection(stringDeConexao);
        }


        [STAThread]
        static void Main()
        {
            var conexao = ObterConexao();
            var repositorio = new EmpregadoRepositorio(conexao);
            var controller = new EmpregadoController(repositorio);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain(controller));
        }
    }
}
