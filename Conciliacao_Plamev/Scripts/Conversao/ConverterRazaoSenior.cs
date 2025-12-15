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
                    double valorDebito = double.Parse(col[4]);
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
                        debito = Program.ClienteFornecedor() == "Fornecedor" ? valorDebito * (-1) : valorDebito,
                        credito = Program.ClienteFornecedor() == "Fornecedor" ? valorCredito : valorCredito * (-1),
                        notaRef = BuscarNfRef(historicoLancamento)
                    });
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} || {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static string BuscarNfRef(string historico)
        {
            string[] words = historico.Split(' ');
            string[] possiveisCombinacoes =
            {
                "NFS",
                "NF",
                "REF.",
                "VR.NF",
                "Vlr.NF",
                "NF/Titulo",
                "Titulo"
            };
            foreach (var c in possiveisCombinacoes)
            {
                int numeroNota = Array.IndexOf(words, c);
                if (numeroNota >= 0)
                {
                    string word = words[numeroNota + 1];
                    string n = word.StartsWith("250") ? word.Substring(2) : word;
                    n = n.StartsWith("2025/") ? n.Substring(5) : n;
                    n = n.StartsWith("2025") ? n.Substring(4) : n;
                    n = n.EndsWith("/2025") ? n.Replace("/2025", "") : n;
                    n = n.Replace(".", "");
                    n = n.TrimStart('0');

                    if(n.Contains('/'))
                    {
                        int slashIndex = n.IndexOf('/');
                        n = n.Substring(0, slashIndex);
                    }

                    //Debug.WriteLine($"{n} || {historico}");
                    return n;
                }
            }
            return "";
        }
    }
}
