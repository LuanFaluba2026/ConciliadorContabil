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
        string razaoPath = @"C:\Users\luan\Downloads\razao atualizado.xlsx";
        public void Conversao()
        {
            Dictionary<string, List<(string, string, string, string, string, string)>> linhas = new();

                
            using (var wb = new XLWorkbook(razaoPath))
            {
                var ws = wb.Worksheet(1);

                for(int i = 2; i <= 1000 /*ws.RowsUsed().Count()*/; i++)
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
                            $"{ classificacaoFornecedor[0]}.{ classificacaoFornecedor[1]}.{ classificacaoFornecedor[2]}.{ classificacaoFornecedor.Substring(3, 2)}.{ classificacaoFornecedor.Substring(5, 4)}", 
                            nomeFornecedor, 
                            double.Parse(saldoAnterior) * (-1)
                            );
                    }
                    else if(linhas.ContainsKey(nomeFornecedor))
                    {
                        linhas[$"{nomeFornecedor}{i}"] = new List<(string, string, string, string, string, string)>
                        {
                            ("val", dataLançamento, historicoLancamento, valorCredito, valorDebito, "0")
                        };

                        Program.cadastrarMovimentacao(
                            codigoFornecedor,
                            dataLançamento,
                            historicoLancamento,
                            double.Parse(valorDebito) * (-1),
                            double.Parse(valorCredito)
                            );
                    }
                }
            }
        }
    }
}
