using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste_aula_13.Model;

namespace teste_aula_13.Repositorio
{
    public class EmpregadoRepositorio
    {
        private DbConnection Conexao;

        public EmpregadoRepositorio(DbConnection conexao)
        {
            Conexao = conexao;
        }

        //Salvar um empregado no banco de dados
        public void Salvar(Model.Empregado empregado)
        {

            //Criando comando de inserção
            String textoDoComando = "INSERT INTO empregado(matricula, nome, endereco, salario, coddep, cargo) " +
                "VALUES (@matricula, @nome, @endereco, @salario, @coddep, @cargo);";

            //Abrindo a conexão
            if(Conexao.State != System.Data.ConnectionState.Open)
                Conexao.Open();

            //Criando comando
            var comando = new NpgsqlCommand();
            comando.Connection = (NpgsqlConnection) Conexao;
            comando.CommandText = textoDoComando;

            //Preenchendo parâmetros do comando com os dados do objeto empregado
            comando.Parameters.AddWithValue("matricula", empregado.Matricula);
            comando.Parameters.AddWithValue("nome", empregado.Nome);
            comando.Parameters.AddWithValue("endereco", empregado.Endereco);
            comando.Parameters.AddWithValue("salario", empregado.Salario);
            comando.Parameters.AddWithValue("coddep", empregado.Coddep);
            comando.Parameters.AddWithValue("cargo", empregado.Cargo);

            //Executando comando
            comando.ExecuteNonQuery();

            //Fechando a conexão
            Conexao.Close();
        }

        //Retornar lista de empregados salvos no banco
        public List<Empregado> RecuperarEmpregados()
        {
            //Criando lista de retorno
            var empregados = new List<Empregado>();

            //Criando comando SELECT
            String textoDoComando = "SELECT matricula, nome, endereco, salario, coddep, cargo " +
                    " FROM public.empregado;";

            //Abrindo conexão
            if (Conexao.State != System.Data.ConnectionState.Open)
                Conexao.Open();

            var comando = Conexao.CreateCommand();
            comando.CommandText = textoDoComando;

            //Executando comando e obtendo um um reader para leituraa dos dados
            var reader = comando.ExecuteReader();

            //Verificando se existem linhas
            if (reader.HasRows)
            {
                //Iterando por todas as tuplas retornadas pelo comando
                while (reader.Read())
                {
                    //Criando novo empregado
                    Empregado empregado = new Empregado
                    {
                        //Prenchendo objeto
                        Matricula = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Endereco = reader.GetString(2),
                        Salario = reader.GetFloat(3),
                        Coddep = reader.GetInt32(4),
                        Cargo = reader.GetString(5)
                    };

                    //Adicionando novo empregado à lista
                    empregados.Add(empregado);
                }
            }

            //Fechando conexão
            Conexao.Close();

            //Retornando lista de empregados
            return empregados;
        }
    }
}
