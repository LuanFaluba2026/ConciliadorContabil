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

        string path = @"C:\Users\luan\Downloads\Fornecedores.xlsx";
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

            foreach(var contas in Program.contasCadastradas)
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

                List<Movimentacao> mov = Program.movimentacoes.Where(x => x.codigoForn == contas.codigo).ToList();
                //FAZER LOOP POR CADA HISTORICO E BATER O NUMERO DAS NOTAS COM FOREACH MOV.HISTORICO.WHERE TAL TAL TAL
                foreach (var movimento in mov)
                {

                    var row = ws.Row(linhasUsadas - alturaFixa + 3).InsertRowsBelow(1);
                    linhasUsadas++;
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
            ws.Cell(linhasUsadas + 2, "G").Style.Font.Bold = true;
            ws.Cell(linhasUsadas + 2, "H").Style.Font.Bold = true;
            ws.Cell(linhasUsadas + 2, "G").Value = "Total:";
            ws.Cell(linhasUsadas + 2, "H").FormulaA1 = $"=SUM(H2:H{linhasUsadas})";
            wb.SaveAs(path);
        }
    }
}
