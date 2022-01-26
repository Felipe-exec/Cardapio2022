using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Cardápio_Hamburgueria_Online
{
    class ConectaBanco
    {
        MySqlConnection conexao = new MySqlConnection("server=localhost;user id=root;password=;database=cardapio2022");
        public string mensagem;

        public DataTable listaCardapio()
        {
            MySqlCommand cmd = new MySqlCommand("lista_cardapio", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexao.Open();
                MySqlDataAdapter co = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();
                co.Fill(tabela);
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
        }
        public bool insereLanche(Cardapio L)
        {
            MySqlCommand cmd = new MySqlCommand("insere_lanche", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("nomeproduto", L.Nome);
            cmd.Parameters.AddWithValue("acompanhamento", L.Acompanhamento);
            cmd.Parameters.AddWithValue("valor", L.Valor);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
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
        }
        public bool deletaLanche(int idprodutos)
        {
            MySqlCommand cmd = new MySqlCommand("deleta_lanche", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idprodutos", idprodutos);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
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
        }
        public bool alteraLanche(Cardapio L, int id)
        {
            MySqlCommand cmd = new MySqlCommand("altera_lanche", conexao);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            cmd.Parameters.AddWithValue("nomeproduto", L.Nome);
            cmd.Parameters.AddWithValue("acompanhamento", L.Acompanhamento);
            cmd.Parameters.AddWithValue("valor", L.Valor);
            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
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
        }
    }
}
