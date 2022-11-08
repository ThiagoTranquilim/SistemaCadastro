using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace SistemaCadastro
{
    internal class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=;database=banco_cadastro");
        public String mensagem;
        public DataTable listaGeneros()
        {
            // comentario
            MySqlCommand cmd = new MySqlCommand("proc_listaGeneros", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }// fim try
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }// fim lista_generos

        public bool insereBanda(Banda b)
        {
            MySqlCommand cmd = new MySqlCommand("proc_insereBandas", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nome", b.Nome);
            cmd.Parameters.AddWithValue("fk_genero", b.Genero);
            cmd.Parameters.AddWithValue("integrantes", b.Integrantes);
            cmd.Parameters.AddWithValue("ranking", b.Ranking);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery(); // executa o comando
                return true;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }// fim insereBanda



    }
}
