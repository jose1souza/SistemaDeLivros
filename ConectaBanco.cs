using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace SistemaCadastro
{
    public class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=;database=banco_siscadastro");
        public string mensagem;

        public bool insereLivro(Livros novoLivro)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("sp_insereLivro", conexao);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("titulo", novoLivro.titulo);
                cmd.Parameters.AddWithValue("editora", novoLivro.editora);
                cmd.Parameters.AddWithValue("edicao", novoLivro.edicao);
                cmd.Parameters.AddWithValue("anoPublicacao", novoLivro.anoPublicacao);
                cmd.Parameters.AddWithValue("numeroPaginas", novoLivro.numeroPaginas);
                cmd.Parameters.AddWithValue("fk_idAutor", novoLivro.autor);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                mensagem = erro.Message;
                return false;
            }
        } // fim do insereLivro
        public DataTable listaAutor()
        {
            // comentario
            MySqlCommand cmd = new MySqlCommand("sp_listaAutor", conexao);
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

        }// fim listaAutor
        public DataTable listaLivro()
        {
            MySqlCommand cmd = new MySqlCommand("sp_listaLivros", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                da.Fill(tabela);
                return tabela;
            }
            catch (MySqlException e)
            {
                mensagem = "Erro:" + e.Message;
                return null;
            }
            finally
            {
                conexao.Close();
            }
    } // fim da classe

    /* public bool deletaLivro(int idRemoveLivro)
        {
            MySqlCommand cmd = new MySqlCommand("sp_removeLivro", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id_livro", idRemoveLivro);
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
        }// fim deletaBanda */

    }
}
