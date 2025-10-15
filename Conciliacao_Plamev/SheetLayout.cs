using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Conciliacao_Plamev
{
    public class SheetLayout
    {

        string path = @"C:\Users\secun\Downloads\emcasa\Fornecedores.xlsx";
        Form1 form = new();
        public void CreateSheet()
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Fornecedores");

            //layout fixo;
            const int alturaFixa = 5;
            int linhasUsadas = 1;

            ws.Cell("A1").Value = "Data";
            ws.Cell("E1").Value = "Débito";
            ws.Cell("F1").Value = "Crédito";
            ws.Column("A").Width = 11.14;
            ws.Column("B").Width = 25.71;
            ws.Column("C").Width = 50;
            ws.Column("D").Width = 44.29;
            ws.Column("E").Width = 15;
            ws.Column("F").Width = 14;
            ws.Column("G").Width = 15;
            ws.Column("H").Width = 24.71;


            


            foreach (var contas in Program.contasCadastradas)
            {
                ws.Cell(1 + linhasUsadas, "A").Value = "Conta:";


                ws.Cell(2 + linhasUsadas, "C").Value = "SALDO ANTERIOR";
                ws.Cell(1 + linhasUsadas, "C").Value = contas.codigo;
                ws.Cell(1 + linhasUsadas, "B").Value = contas.contaAnalitica;
                ws.Cell(1 + linhasUsadas, "D").Value = contas.nomeFornecedor;
                ws.Cell(2 + linhasUsadas, "F").Value = contas.saldo;

                //soma
                ws.Cell(alturaFixa - 1 + linhasUsadas, "H").FormulaA1 = $"=SUM(E{linhasUsadas + 2}:F{linhasUsadas + alturaFixa - 1})";
                //personalização
                ws.Cell(1 + linhasUsadas, "C").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                ws.Cell(1 + linhasUsadas, "C").Style.Font.Bold = true;
                ws.Cell(1 + linhasUsadas, "D").Style.Font.Bold = true;
                ws.Row(1 + linhasUsadas).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Row(linhasUsadas).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                ws.Cell(alturaFixa - 1 + linhasUsadas, "H").Style.Fill.BackgroundColor = XLColor.Yellow;
                ws.Cell(alturaFixa - 1 + linhasUsadas, "H").Style.Font.Bold = true;

                linhasUsadas += alturaFixa;

                var saldos = Program.saldosEmAberto.Where(x => x.codigoForn == contas.codigo);
                foreach(var s in saldos)
                {
                    var row = ws.Row(2 + linhasUsadas - alturaFixa).InsertRowsBelow(1);
                    linhasUsadas++;
                    foreach (var cells in row)
                    {
                        cells.Cell("A").Value = s.dataMov;
                        cells.Cell("C").Value = s.historico;
                        cells.Cell("F").Value = s.credito;
                        cells.Cell("A").Style.Font.FontColor = XLColor.Red;
                        cells.Cell("C").Style.Font.FontColor = XLColor.Red;
                        cells.Cell("F").Style.Font.FontColor = XLColor.Red;
                    }
                }
                List<Movimentacao> mov = Program.movimentacoes.Where(x => x.codigoForn == contas.codigo).ToList();

                var numRepetido = mov.GroupBy(n => n.notaRef).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                var valDebtRepetido = mov.GroupBy(n => n.debito).Where(g => g.Count() > 1).Select(g => g.Key).ToList();
                var valCredRepetido = mov.GroupBy(n => n.credito).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

                mov.RemoveAll(x => numRepetido.Contains(x.notaRef) && valDebtRepetido.Contains(x.debito) || valCredRepetido.Contains(x.credito));
                Program.movimentacoes.RemoveAll(x => numRepetido.Contains(x.notaRef) && valDebtRepetido.Contains(x.debito) || valCredRepetido.Contains(x.credito));

                foreach (var movimento in mov)
                {
                    var row = ws.Row(linhasUsadas - alturaFixa + 3).InsertRowsBelow(1);
                    linhasUsadas++;

                    if(!Program.saldosEmAberto.Any(x => x.notaRef == movimento.notaRef && x.dataMov == movimento.dataLancamento))
                    {
                        Program.CadastrarSaldo(
                        movimento.codigoForn ?? "",
                        movimento.dataLancamento ?? "",
                        movimento.notaRef ?? "",
                        movimento.historico ?? "",
                        movimento.credito
                        );
                    }

                    foreach (var cells in row)
                    {
                        cells.Cell("A").Value = movimento.dataLancamento;
                        cells.Cell("C").Value = movimento.historico;
                        cells.Cell("E").Value = movimento.debito;
                        cells.Cell("F").Value = movimento.credito;
                    }

                }
            }



            //totalizadors
            /*ws.Cell(linhasUsadas + 2, "G").Style.Font.Bold = true;
            ws.Cell(linhasUsadas + 2, "H").Style.Font.Bold = true;
            ws.Cell(linhasUsadas + 2, "G").Value = "Total:";
            ws.Cell(linhasUsadas + 2, "H").FormulaA1 = $"=SUM(H2:H{linhasUsadas})";*/
            wb.SaveAs(path);
        }
    }
}
