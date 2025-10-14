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
        public void CreateSheet(Dictionary<string, List<(string, string, string, string, string, string)>> dic)
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Fornecedores");

            //layout fixo;
            const int alturaFixa = 5;


            int linhasUsadas = 1;
            foreach (var kvp in dic)
            {
                foreach(var item in kvp.Value)
                {

                    //layout fixo
                    ws.Cell("A1").Value = "Data";
                    ws.Cell("E1").Value = "Débito";
                    ws.Cell("F1").Value = "Crédito";

                    ws.Row(1 + linhasUsadas).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    ws.Row(linhasUsadas).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

                    ws.Cell(2 + linhasUsadas, "H").Style.Fill.BackgroundColor = XLColor.Yellow;
                    ws.Cell(2 + linhasUsadas, "H").Style.Font.Bold = true;

                    ws.Column("A").Width = 11.14;
                    ws.Column("B").Width = 25.71;
                    ws.Column("C").Width = 50;
                    ws.Cell(1 + linhasUsadas, "C").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(1 + linhasUsadas, "C").Style.Font.Bold = true;
                    ws.Column("D").Width = 44.29;
                    ws.Cell(1 + linhasUsadas, "D").Style.Font.Bold = true;
                    ws.Column("E").Width = 15;
                    ws.Column("F").Width = 14;
                    ws.Column("G").Width = 15;
                    ws.Column("H").Width = 24.71;

                    if (item.Item1 != "val")
                    {
                        var (codigoF, classF, nomeF, dataF, histF, saldoAntF) = item;

                        ws.Cell(1 + linhasUsadas, "A").Value = "Conta:";
                        ws.Cell(2 + linhasUsadas, "C").Value = "SALDO ANTERIOR";
                        ws.Cell(1 + linhasUsadas, "C").Value = codigoF;
                        ws.Cell(1 + linhasUsadas, "B").Value = $"{classF[0]}.{classF[1]}.{classF[2]}.{classF.Substring(3, 2)}.{classF.Substring(5, 4)}";
                        ws.Cell(1 + linhasUsadas, "D").Value = nomeF;
                        //ws.Cell(3 + linhasUsadas, "C").Value = histF;
                        double saldoAnterior = double.Parse(saldoAntF) * (-1);
                        ws.Cell(2 + linhasUsadas, "F").Value = saldoAnterior;
                    }
                    else
                    {
                        var (id, data, historico, cred, debt, nulo) = item;
                        var row = ws.Row(linhasUsadas - alturaFixa + 3).InsertRowsBelow(1);
                        linhasUsadas++;
                        foreach(var cells in row)
                        {
                            cells.Cell("A").Value = data;
                            cells.Cell("C").Value = historico;
                            cells.Cell("E").Value = double.Parse(debt) * (-1);
                            cells.Cell("F").Value = double.Parse(cred);
                        }
                        break;
                    }

                    ws.Cell(2 + linhasUsadas, "H").FormulaA1 = $"=SUM(E{linhasUsadas+2}:F{linhasUsadas + alturaFixa - 1})";

                    linhasUsadas += alturaFixa;
                }
            }
            ws.Cell(linhasUsadas + 2, "G").Style.Font.Bold = true;
            ws.Cell(linhasUsadas + 2, "H").Style.Font.Bold = true;
            ws.Cell(linhasUsadas + 2, "G").Value = "Total:";
            ws.Cell(linhasUsadas + 2, "H").FormulaA1 = $"=SUM(H2:H{linhasUsadas})";
            wb.SaveAs(path);
        }
    }
}
