using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DALTransacao
    {
        private DALConexao conexao;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

        public DALTransacao(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void Incluir(ModelTransacao modelo)
        {
            MySqlCommand cmd = new MySqlCommand();
            
            cmd.CommandText = "INSERT INTO transacao(data_trans, desc_trans, valor_trans, nota_trans) VALUES(@data, @desc, @valor, @nota); SELECT @@IDENTITY;";
            cmd.Parameters.AddWithValue("@data", modelo.DataTrans);
            cmd.Parameters.AddWithValue("@desc", modelo.DataTrans);
            cmd.Parameters.AddWithValue("@valor", modelo.DataTrans);
            cmd.Parameters.AddWithValue("@nota", modelo.DataTrans);

            conexao.Connect();
            modelo.IdTrans = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Disconnect();


/*            // Abre a conexão
            mConn.Open();

            //Query SQL
            MySqlCommand command = new MySqlCommand("INSERT INTO tabela_dados (titulo,descricao)" +
            "VALUES('" + tb_titulo.Text + "','" + tb_descricao.Text + "')", mConn);

            //Executa a Query SQL
            command.ExecuteNonQuery();

            // Fecha a conexão
            mConn.Close();

            //Mensagem de Sucesso
            MessageBox.Show("Gravado com Sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Método criado para que quando o registo é gravado, automaticamente a dataGridView efectue um "Refresh"
            mostraResultados();
        }*/


        /*
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "INSERT INTO categoria(cat_nome) VALUES (@nome); SELECT @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", modelo.CatNome);
            conexao.Conectar();
            // executescalar: poucas informações do banco
            modelo.CatCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        */
        }



        /*
        public void Alterar(ModeloCategoria modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "UPDATE categoria SET cat_nome = @nome WHERE cat_cod = @codigo";
            cmd.Parameters.AddWithValue("@nome", modelo.CatNome);
            cmd.Parameters.AddWithValue("@codigo", modelo.CatCod);
            conexao.Conectar();
            // executenonquery: nenhuma informação do banco
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "DELETE FROM categoria WHERE cat_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM categoria WHERE cat_nome LIKE '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }  */

        public ModelTransacao CarregaModeloTransacao(int codigo)
        {
            ModelTransacao modelo = new ModelTransacao();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "SELECT * FROM transacao WHERE id_trans = @codigo";
            cmd.Parameters.AddWithValue("@codigo", codigo);

            conexao.Connect();
            MySqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.DataTrans = Convert.ToDateTime(registro["data_trans"]);
                modelo.DescTrans = Convert.ToString(registro["desc_trans"]);
                modelo.NotaTrans = Convert.ToString(registro["nota_trans"]);
                modelo.ValorTrans = Convert.ToDouble(registro["valor_trans"]);
            }

            conexao.Disconnect();

            return modelo;
        }
    }
}