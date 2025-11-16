using Conciliacao_Plamev.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conciliacao_Plamev.Scripts.Conversao
{
    internal class ConverterRazaoSenior
    {
        public static void Conversao()
        {
            try
            {

                string path = Form1.razaoPath;
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                string[] lines = File.ReadAllLines(path, Encoding.GetEncoding("Windows-1252"));

                foreach(string line in lines.Skip(1))
                {
                    string[] col = line.Split(";");

                    string dataLançamento = col[0];
                    string nomeFornecedor = col[1];
                    string codigoFornecedor = col[3];
                    double valorDebito = double.Parse(col[4]) * (-1);
                    double valorCredito = double.Parse(col[5]);
                    string historicoLancamento = col[7];

                    Debug.WriteLine($"{dataLançamento} || {nomeFornecedor} || {codigoFornecedor} || {valorDebito} || {valorCredito} || {historicoLancamento}");

                    BancoDeDados.AddConta(new CodigoContas()
                    {
                        codigoForn = codigoFornecedor,
                        contaAnalitica = "",
                        nomeForn = nomeFornecedor
                    });
                    BancoDeDados.AddMovimento(new Movimento()
                    {
                        codigoForn = codigoFornecedor,
                        dataMov = dataLançamento,
                        historico = historicoLancamento,
                        debito = valorDebito,
                        credito = valorCredito,
                        notaRef = ConverterRazao.BuscarNfRef(historicoLancamento)
                    });
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} || {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
