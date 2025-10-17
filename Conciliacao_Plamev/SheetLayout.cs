using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
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

        string path = Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Downloads", "Fornecedores.xlsx"));
        Form1 form = new();
        public void CreateSheet()
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Fornecedores");

            //layout fixo;
            const int alturaFixa = 6;
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

            List<MovimentosAbertos> saldos = BancoDeDados.GetSaldos().Where(s => Form1.competencia > DateTime.Parse(s.dataMov)).ToList();
            foreach (var contas in Program.contasCadastradas)
            {
                List<Movimentacao> mov = Program.movimentacoes.Where(x => x.codigoForn == contas.codigo).ToList();
                List<MovimentosAbertos> saldosPorConta = saldos.Where(x => x.codigoForn == contas.codigo).ToList();

                var remover = new HashSet<Movimentacao>();
                var removerSaldos = new HashSet<MovimentosAbertos>();

                foreach (var grupo in mov.GroupBy(x => x.notaRef))
                {
                    var creditos = grupo.Where(x => x.credito > 0).ToList();
                    var debitos = grupo.Where(x => x.debito < 0).ToList();

                    foreach (var c in creditos)
                    {
                        var d = debitos.FirstOrDefault(x => x.notaRef == c.notaRef && Math.Abs(x.debito + c.credito) < 0.01); ;
                        if (d != null)
                        {
                            remover.Add(c);
                            remover.Add(d);
                            debitos.Remove(d);
                        }
                    }
                    foreach (var grupoSaldos in saldosPorConta.GroupBy(x => x.notaRef))
                    {
                        var creditosS = grupoSaldos.Where(x => x.credito > 0).ToList();
                        foreach(var cred in creditosS)
                        {
                            var deb = debitos.FirstOrDefault(x => x.notaRef == cred.notaRef && Math.Abs(x.debito + cred.credito) < 0.01);
                            if (deb != null)
                            {
                                removerSaldos.Add(cred);
                                remover.Add(deb);
                                debitos.Remove(deb);
                            }
                        }
                    }
                }
                foreach(var s in removerSaldos)
                {
                    Debug.WriteLine($"{s.notaRef} || {s.historico} || {mov.FirstOrDefault(x => x.codigoForn == s.codigoForn).dataLancamento}");
                    BancoDeDados.EncerrarSaldo(s.codigoForn, s.historico, mov.FirstOrDefault(x => x.codigoForn == s.codigoForn).dataLancamento);
                }
                mov.RemoveAll(x => remover.Contains(x));

                if(mov.Count != 0 || saldosPorConta.Count != 0)
                {
                    ws.Cell(1 + linhasUsadas, "A").Value = "Conta:";
                    ws.Cell(3 + linhasUsadas, "C").Value = "SALDO ANTERIOR";
                    ws.Cell(1 + linhasUsadas, "C").Value = contas.codigo;
                    ws.Cell(1 + linhasUsadas, "B").Value = contas.contaAnalitica;
                    ws.Cell(1 + linhasUsadas, "D").Value = contas.nomeFornecedor;

                    //soma
                    ws.Cell(alturaFixa - 1 + linhasUsadas, "H").FormulaA1 = $"=SUM(E{linhasUsadas + 3}:F{linhasUsadas + alturaFixa - 1})";
                    //personalização
                    ws.Cell(1 + linhasUsadas, "C").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(1 + linhasUsadas, "C").Style.Font.Bold = true;
                    ws.Cell(1 + linhasUsadas, "D").Style.Font.Bold = true;
                    ws.Row(1 + linhasUsadas).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    ws.Row(linhasUsadas).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(alturaFixa - 1 + linhasUsadas, "H").Style.Fill.BackgroundColor = XLColor.Yellow;
                    ws.Cell(alturaFixa - 1 + linhasUsadas, "H").Style.Font.Bold = true;
                    BancoDeDados.UpdateSaldo(contas.codigo, 0);
                    linhasUsadas += alturaFixa;
                }


                foreach(var s in saldosPorConta)
                {
                    Debug.WriteLine(s.dataEncerramento);
                    if(String.IsNullOrEmpty(s.dataEncerramento))
                    {
                        var row = ws.Row(3 + linhasUsadas - alturaFixa).InsertRowsAbove(1);
                        linhasUsadas++;
                        ws.Cell(3 + linhasUsadas - alturaFixa, "F").FormulaA1 = $"=SUM(f{2 + linhasUsadas - alturaFixa}:F{1 + linhasUsadas - alturaFixa})";
                        foreach (var cells in row)
                        {
                            cells.Cell("A").Value = s.dataMov;
                            cells.Cell("C").Value = s.historico;
                            cells.Cell("F").Value = s.credito;
                            cells.Cell("A").Style.Font.FontColor = XLColor.Red;
                            cells.Cell("C").Style.Font.FontColor = XLColor.Red;
                            cells.Cell("F").Style.Font.FontColor = XLColor.Red;
                        }
                        BancoDeDados.SomaSaldo(contas.codigo, s.credito);
                    }
                    else
                    {
                        DateTime encerramento = DateTime.Parse(s.dataEncerramento);
                        if (encerramento < Form1.competencia)
                        {
                            var row = ws.Row(3 + linhasUsadas - alturaFixa).InsertRowsAbove(1);
                            linhasUsadas++;
                            ws.Cell(3 + linhasUsadas - alturaFixa, "F").FormulaA1 = $"=SUM(f{2 + linhasUsadas - alturaFixa}:F{1 + linhasUsadas - alturaFixa})";
                            foreach (var cells in row)
                            {
                                cells.Cell("A").Value = s.dataMov;
                                cells.Cell("C").Value = s.historico;
                                cells.Cell("F").Value = s.credito;
                                cells.Cell("A").Style.Font.FontColor = XLColor.Red;
                                cells.Cell("C").Style.Font.FontColor = XLColor.Red;
                                cells.Cell("F").Style.Font.FontColor = XLColor.Red;
                            }
                            BancoDeDados.SomaSaldo(contas.codigo, s.credito);
                        }
                    }
                }

                double acumulado = 0;
                foreach (var movimento in mov)
                {
                    var row = ws.Row(linhasUsadas - alturaFixa + 4).InsertRowsBelow(1);
                    linhasUsadas++;

                        BancoDeDados.AddSaldo(new MovimentosAbertos()
                        {
                            codigoForn = movimento.codigoForn ?? "",
                            dataMov = movimento.dataLancamento ?? "",
                            notaRef = movimento.notaRef ?? "",
                            historico = movimento.historico ?? "",
                            credito = movimento.credito
                        });

                    foreach (var cells in row)
                    {
                        cells.Cell("A").Value = movimento.dataLancamento;
                        cells.Cell("C").Value = movimento.historico;
                        cells.Cell("E").Value = movimento.debito;
                        cells.Cell("F").Value = movimento.credito;
                        acumulado += movimento.credito;
                    }
                BancoDeDados.SomaSaldo(contas.codigo, acumulado);
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
