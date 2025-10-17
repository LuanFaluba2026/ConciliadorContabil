using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Conciliacao_Plamev
{
    internal class ConverterRazao
    {
        Form1 form = new();
        string razaoPath = Form1.razaoPath;
        public void Conversao()
        {
            try
            {
                Program.movimentacoes.Clear();
                Dictionary<string, List<(string, string, string, string, string, string)>> linhas = new();
                using (var wb = new XLWorkbook(razaoPath))
                {
                    var ws = wb.Worksheet(1);

                    for (int i = 2; i <= 1000 /*ws.RowsUsed().Count()*/; i++)
                    {

                        var row = ws.Row(i);
                        string codigoFornecedor = row.Cell("D").Value.ToString();
                        string classificacaoFornecedor = row.Cell("B").Value.ToString();
                        string nomeFornecedor = row.Cell("C").Value.ToString();
                        string dataLançamento = row.Cell("F").Value.ToString();
                        string historicoLancamento = row.Cell("R").Value.ToString();
                        string saldoAnterior = row.Cell("H").Value.ToString();
                        string valorDebito = row.Cell("L").Value.ToString();
                        string valorCredito = row.Cell("M").Value.ToString();


                        if (nomeFornecedor != "FORNECEDORES DIVERSOS" && !linhas.ContainsKey(nomeFornecedor))
                        {
                            linhas[nomeFornecedor] = new List<(string, string, string, string, string, string)> {

                            (codigoFornecedor, classificacaoFornecedor, nomeFornecedor, dataLançamento, historicoLancamento, saldoAnterior)
                        };

                            Program.CadastrarConta(
                                codigoFornecedor,
                                $"{classificacaoFornecedor[0]}.{classificacaoFornecedor[1]}.{classificacaoFornecedor[2]}.{classificacaoFornecedor.Substring(3, 2)}.{classificacaoFornecedor.Substring(5, 4)}",
                                nomeFornecedor,
                                double.Parse(saldoAnterior) * (-1)
                                );

                            BancoDeDados.AddConta(new CodigoContas()
                            {
                                codigo = codigoFornecedor,
                                contaAnalitica = $"{classificacaoFornecedor[0]}.{classificacaoFornecedor[1]}.{classificacaoFornecedor[2]}.{classificacaoFornecedor.Substring(3, 2)}.{classificacaoFornecedor.Substring(5, 4)}",
                                nomeFornecedor = nomeFornecedor,
                                saldo = 0
                            });
                        }
                        else if (linhas.ContainsKey(nomeFornecedor))
                        {
                            linhas[$"{nomeFornecedor}{i}"] = new List<(string, string, string, string, string, string)>
                        {
                            ("val", dataLançamento, historicoLancamento, valorCredito, valorDebito, "0")
                        };

                            Program.CadastrarMovimentacao(
                                codigoFornecedor,
                                dataLançamento,
                                historicoLancamento,
                                double.Parse(valorDebito) * (-1),
                                double.Parse(valorCredito),
                                BuscarNfRef(historicoLancamento)
                            );

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} || {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private string BuscarNfRef(string historico)
        {
            string[] words = historico.Split(' ');
            string[] possiveisCombinacoes =
            {
                "NFS",
                "NF",
                "REF.",
                "VR.NF"
            };
            foreach(var c in possiveisCombinacoes)
            {
                int numeroNota = Array.IndexOf(words, c);
                if(numeroNota >= 0)
                {
                    string word = words[numeroNota + 1];
                    string n = word.StartsWith("250") ? word.Substring(2) : word;
                    n = n.StartsWith("2025/") ? n.Substring(5) : n;
                    n = n.StartsWith("2025") ? n.Substring(4) : n;
                    n = n.EndsWith("/2025") ? n.Replace("/2025", "") : n;
                    n = n.TrimStart('0');
                    Debug.WriteLine($"{n} || {historico}");
                    return n;
                }
            }
            return "";
        }
    }
}
