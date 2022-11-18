using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    public class Sql
    {
        private readonly SqlConnection _conexao;
        public Sql()
        {
            //string lertexto = System.IO.File.ReadAllText(@"C:\fiotec\Mensagens v02\servidorSql.txt");
            this._conexao = new SqlConnection();
        }

        public void inserirDados(dadosDoEmail email)
        {
            _conexao.Open();
            SqlTransaction tran = _conexao.BeginTransaction();
            try
            {
     

                string sql = @"INSERT INTO Cliente
                             (NOME,REMETENTE,DESTINATARIO,DATAEMAIL,CONTEUDO)
                             VALUES
                             (@NOME,@REMETENTE,@DESTINATARIO,@DATAEMAIL,@CONTEUDO);";

                using (SqlCommand cmd = new SqlCommand(sql, _conexao))
                {
                    cmd.Parameters.AddWithValue("NOME", email.NOME);
                    cmd.Parameters.AddWithValue("REMETENTE", email.REMETENTE); 
                    cmd.Parameters.AddWithValue("DESTINATARIO", email.DESTINATARIO);
                    cmd.Parameters.AddWithValue("DATAEMAIL", email.DATAEMAIL);
                    cmd.Parameters.AddWithValue("CONTEUDO", email.CONTEUDO);
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
              
            }
            catch (Exception ex)
            {
                tran.Rollback();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _conexao.Close();
            }
        }
    }
}
