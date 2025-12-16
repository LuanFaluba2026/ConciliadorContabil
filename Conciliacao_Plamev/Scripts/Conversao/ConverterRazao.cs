using ClosedXML.Excel;
using Conciliacao_Plamev.Forms;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Conciliacao_Plamev.Scripts.Conversao
{
    internal class ConverterRazao
    {
        //Função usada para pegar as informações no razão do Domínio e realizar o Parsing
        public static void Conversao()
        {
            try
            {
                string razaoPath = Form1.razaoPath;
                using (var wb = new XLWorkbook(razaoPath))
                {
                    var ws = wb.Worksheet(1);

                    Form1.Instance.SetMaxProgressBar(ws.RowsUsed().Count());
                    int indexLanc = 0;
                    for (int i = 2; i <= ws.RowsUsed().Count(); i++)
                    {
                        Form1.Instance.StepProgressBar();

                        //Atribuindo todos registros à variáveis.
                        var row = ws.Row(i);
                        string codigoFornecedor = row.Cell("D").Value.ToString();
                        string classificacaoFornecedor = row.Cell("B").Value.ToString();
                        string nomeFornecedor = row.Cell("C").Value.ToString();
                        string dataLançamento = row.Cell("F").Value.ToString();
                        string historicoLancamento = row.Cell("R").Value.ToString();
                        string saldoAnterior = row.Cell("H").Value.ToString();
                        string valorDebito = row.Cell("L").Value.ToString();
                        string valorCredito = row.Cell("M").Value.ToString();

                        if(nomeFornecedor != "FORNECEDORES DIVERSOS")
                        {
                            indexLanc++;
                            if (valorCredito == "0" && valorDebito == "0") //Verifica se a conta não é de fornecedores diversos e se a conta já existe no banco de dados.
                            {
                                BancoDeDados.AddConta(new CodigoContas()
                                {
                                    codigoForn = codigoFornecedor,
                                    contaAnalitica = $"{classificacaoFornecedor[0]}.{classificacaoFornecedor[1]}.{classificacaoFornecedor[2]}.{classificacaoFornecedor.Substring(3, 2)}.{classificacaoFornecedor.Substring(5, 4)}",
                                    nomeForn = nomeFornecedor,
                                });
                            }
                            else //Se a conta não existir no banco de dados, considera a conta como movimentação.
                            {
                                BancoDeDados.AddMovimento(new Movimento()
                                {
                                    codigoForn = codigoFornecedor,
                                    dataMov = dataLançamento,
                                    historico = historicoLancamento + $"IDXLanc - {indexLanc}",
                                    debito = Program.ClienteFornecedor() == "Fornecedor" ? double.Parse(valorDebito) * (-1) : double.Parse(valorDebito),
                                    credito = Program.ClienteFornecedor() == "Fornecedor" ? double.Parse(valorCredito) : double.Parse(valorCredito) * (-1),
                                    notaRef = BuscarNfRef(historicoLancamento)
                                });

                            }
                        }
                    }
                }

                Form1.Instance.SetProgressBarValue(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} || {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public static string BuscarNfRef(string historico)
        {
            string[] words = historico.Split(' ');
            List<Prefixos> possiveisCombinacoes = BancoDeDados.GetPrefixos();
            foreach(var c in possiveisCombinacoes)
            {
                int numeroNota = Array.IndexOf(words, c.prefx);
                if(numeroNota >= 0)
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
                    n = n.Replace("/", "");
                    return n;
                }
            }
            return "";
        }

        public static void IniciarSubstituicao()
        {
            List<Movimento> mov = BancoDeDados.GetMovimentos().Where(x => (DateTime.Parse(x.dataMov).Year == Form1.competencia.Year && DateTime.Parse(x.dataMov).Month == Form1.competencia.Month)).ToList();
            List<Movimento> movEncerrados = BancoDeDados.GetMovimentos().Where(x => !String.IsNullOrEmpty(x.dataEncerramento) && (DateTime.Parse(x.dataEncerramento).Year == Form1.competencia.Year && DateTime.Parse(x.dataEncerramento).Month == Form1.competencia.Month)).ToList();

            foreach(Movimento m in mov)
            {
                BancoDeDados.ExcluirMovimento(m.idx);
            }
            foreach(Movimento m in movEncerrados)
            {
                BancoDeDados.UpdateMovimento(new Movimento()
                {
                    dataMov = m.dataMov,
                    historico = m.historico,
                    debito = m.debito,
                    credito = m.credito,
                    notaRef = m.notaRef,
                    dataEncerramento = null
                }, m.idx);
            }

        }
    }
}
