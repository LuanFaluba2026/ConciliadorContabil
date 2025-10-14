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
        string razaoPath = @"C:\Users\secun\Downloads\emcasa\teste.xlsx";
        public Dictionary<string, List<(string, string, string, string, string, string)>> Conversao()
        {
            Dictionary<string, List<(string, string, string, string, string, string)>> linhas = new();

                
            using (var wb = new XLWorkbook(razaoPath))
            {
                var ws = wb.Worksheet(1);

                for(int i = 2; i <= ws.RowsUsed().Count(); i++)
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
                    }
                    else if(linhas.ContainsKey(nomeFornecedor))
                    {
                        linhas[$"{nomeFornecedor}{i}"] = new List<(string, string, string, string, string, string)>
                        {
                            ("val", dataLançamento, historicoLancamento, valorCredito, valorDebito, "0")
                        };
                    }
                }
            }
            return linhas;
        }
    }
}
