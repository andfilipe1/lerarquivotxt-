using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    public class Atividade
    {
        public void importarDados()

        {
            var sql = new Sql();

            var dadosCadastrais = new List<dadosDoEmail>();
            string NOME, REMETENTE, DESTINATARIO, DATAEMAIL, CONTEUDO;

            string[] linha = Directory.GetFiles(@"C:\fiotec\Mensagens v02\Nova pasta");

            //ABRE E LÊ O ARQUIVO TXT

            for (int i = 0; i < linha.Length; i++)
            {
                string[] text = File.ReadAllLines(linha[i]);

                NOME = text[3].Substring(0, 11);
                REMETENTE = text[0].Substring(0, 11);
                DESTINATARIO = text[2].Substring(0, 11);
                DATAEMAIL = text[1].Substring(0, 11);
                CONTEUDO = text.ToString();

                var email = new dadosDoEmail();
                email.NOME = NOME;
                email.REMETENTE = REMETENTE;
                email.DESTINATARIO = DESTINATARIO;
                email.DATAEMAIL = DATAEMAIL;
                email.CONTEUDO = CONTEUDO;

                dadosCadastrais.Add(email);
                Console.WriteLine(dadosCadastrais);
            }

            foreach (var dados in dadosCadastrais)
            {
                Console.WriteLine(dados);
                //sql.inserirDados(dados);
            }



        }
    }
}
