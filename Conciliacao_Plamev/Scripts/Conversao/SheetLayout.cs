using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
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

namespace Conciliacao_Plamev.Scripts.Conversao
{
    public class SheetLayout
    {

        static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"Downloads");
        public static void CreateSheet()
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Fornecedores");

            //Setta os parametros fixos do layout da Conciliação
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

            List<CodigoContas> contasCadastradas = BancoDeDados.GetContas().ToList();
            Form1.Instance.SetMaxProgressBar(BancoDeDados.GetContas().Count());
            foreach (var conta in contasCadastradas.OrderBy(x => String.IsNullOrEmpty(x.contaAnalitica) ? int.Parse(x.codigoForn) : int.Parse(x.contaAnalitica.Replace(".", ""))))
            {
                Form1.Instance.StepProgressBar();
                List<Movimento> movEncerrar = BancoDeDados.GetMovimentos().Where(x => x.codigoForn == conta.codigoForn && String.IsNullOrEmpty(x.dataEncerramento)).ToList();

                //Passa pelos movimentos que contém débito e crédito no periodo (baseado no número da nota e valor), e encerra ele no banco de dados
                //Atribuíndo a data de movimentação do débito na data de encerramento do crédito. Vice-versa
                foreach (var grupo in movEncerrar.GroupBy(x => x.notaRef))
                {
                    var creditos = grupo.Where(x => x.credito > 0).ToList();
                    var debitos = grupo.Where(x => x.debito < 0).ToList();

                    if(Program.ClienteFornecedor() == "Fornecedor")
                    {
                        double somaDeb = 0;
                        List<Movimento> movDebAtual = new();
                        foreach (var d in debitos)
                        {
                            somaDeb += d.debito;
                            movDebAtual.Add(d);
                        }
                        foreach (var c in creditos)
                        {
                            if(movDebAtual.Count > 0)
                            {
                                if (Math.Abs(c.credito + somaDeb) < 0.1 && c.notaRef == movDebAtual[0].notaRef)
                                {
                                    Form1.Instance.AtualizarLog($"Credito na conta {c.codigoForn} da nota {c.notaRef} encerrado com {movDebAtual.Count} débitos.");
                                    BancoDeDados.EncerrarMovimento(c.codigoForn, c.historico, movDebAtual[0].dataMov);
                                    foreach(var mov in movDebAtual)
                                        BancoDeDados.EncerrarMovimento(mov.codigoForn, mov.historico, c.dataMov);
                                }
                            }
                        }
                    }
                    else if (Program.ClienteFornecedor() == "Cliente")
                    {
                        double somaCred = 0;
                        List<Movimento> movCredAtual = new();
                        foreach (var c in creditos)
                        {
                            somaCred += c.credito;
                            movCredAtual.Add(c);
                        }
                        foreach (var d in debitos)
                        {
                            if (movCredAtual.Count > 0)
                            {
                                if (Math.Abs(d.debito + somaCred) < 0.1 && d.notaRef == movCredAtual[0].notaRef)
                                {
                                    Form1.Instance.AtualizarLog($"Débito na conta {d.codigoForn} da nota {d.notaRef} encerrado com {movCredAtual.Count} creditos.");
                                    BancoDeDados.EncerrarMovimento(d.codigoForn, d.historico, d.dataMov);
                                    foreach (var mov in movCredAtual)
                                        BancoDeDados.EncerrarMovimento(mov.codigoForn, mov.historico, d.dataMov);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nome do Banco de Dados inválido.");
                        return;
                    }
                }
                //Gera o registro da conta somente se pelo menos um movimento ainda esteja sem encerrar.
                List<Movimento> movPorConta= BancoDeDados.GetMovimentos().Where(x => (DateTime.Parse(x.dataMov).Year < Form1.competencia.Year ||
                                                                                    (DateTime.Parse(x.dataMov).Year == Form1.competencia.Year && DateTime.Parse(x.dataMov).Month <= Form1.competencia.Month)) && 
                                                                                    x.codigoForn == conta.codigoForn && 
                                                                                    String.IsNullOrEmpty(x.dataEncerramento)).ToList();
                if (movPorConta.Any(x => x.codigoForn == conta.codigoForn))
                {
                    ws.Cell(1 + linhasUsadas, "A").Value = "Conta:";
                    ws.Cell(1 + linhasUsadas, "C").Value = conta.codigoForn;
                    ws.Cell(1 + linhasUsadas, "B").Value = conta.contaAnalitica;
                    ws.Cell(1 + linhasUsadas, "D").Value = conta.nomeForn;

                    //personalização
                    ws.Cell(1 + linhasUsadas, "C").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    ws.Cell(1 + linhasUsadas, "C").Style.Font.Bold = true;
                    ws.Cell(1 + linhasUsadas, "D").Style.Font.Bold = true;
                    ws.Row(1 + linhasUsadas).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    ws.Row(linhasUsadas).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(alturaFixa - 1 + linhasUsadas, "G").Style.Fill.BackgroundColor = XLColor.Yellow; // SOMA SALDO
                    ws.Cell(alturaFixa - 1 + linhasUsadas, "G").Style.Font.Bold = true; // SOMA SALDO
                    //Aplica formula no saldo para somar.
                    ws.Cell(alturaFixa - 1 + linhasUsadas, "G").FormulaA1 = $"=SUM(E{linhasUsadas + 2}:F{linhasUsadas + alturaFixa})";
                    linhasUsadas += alturaFixa;
                }
                //Começa a escrever cada movimento do periodo/conta
                foreach (var movPorNota in movPorConta.GroupBy(x => x.notaRef))
                {
                    foreach(var s in movPorNota)
                    {
                        //Condição: Se no movimento ainda não houver data de encerramento, ele será gerado.
                        //Se o mês da movimentação for o mesmo que a da competencia, ele será gerado no campo de saldos do período.
                        //Se o mês da movimentação for menor do que a data da competencia, ele será gerado no campo de saldos anteriores em aberto
                        //Debug.WriteLine(DateTime.Parse(s.dataMov) + " " + Form1.competencia);
                        DateTime parsedDate = DateTime.Parse(s.dataMov);
                        DateTime dataToleravel = Form1.competencia.AddDays(-1);
                        if (parsedDate <= dataToleravel)
                        {
                            linhasUsadas++;
                            var row = ws.Row(linhasUsadas - alturaFixa + 2).InsertRowsAbove(1);
                            foreach (var cells in row)
                            {
                                cells.Cell("A").Value = s.dataMov;
                                if (s.historico.Contains("IDXLanc"))
                                {
                                    int stringIndex = s.historico.IndexOf("IDXLanc");
                                    cells.Cell("C").Value = s.historico.Substring(0, stringIndex);
                                }
                                else
                                {
                                    cells.Cell("C").Value = s.historico;
                                }
                                cells.Cell("E").Value = s.debito;
                                cells.Cell("F").Value = s.credito;
                                cells.Cell("A").Style.Font.FontColor = XLColor.Red;
                                cells.Cell("C").Style.Font.FontColor = XLColor.Red;
                                cells.Cell("E").Style.Font.FontColor = XLColor.Red;
                                cells.Cell("F").Style.Font.FontColor = XLColor.Red;
                            }
                        }
                        else if(parsedDate.Month == Form1.competencia.Month && parsedDate.Year == Form1.competencia.Year)
                        {
                            linhasUsadas++;
                            var row = ws.Row(linhasUsadas - alturaFixa + 1).InsertRowsBelow(1);
                            foreach (var cells in row)
                            {
                                cells.Cell("A").Value = s.dataMov;
                                if (s.historico.Contains("IDXLanc"))
                                {
                                    int stringIndex = s.historico.IndexOf("IDXLanc");
                                    cells.Cell("C").Value = s.historico.Substring(0, stringIndex);
                                }
                                else
                                {
                                    cells.Cell("C").Value = s.historico;
                                }
                                cells.Cell("E").Value = s.debito;
                                cells.Cell("F").Value = s.credito;

                                cells.Cell("A").Style.Font.FontColor = XLColor.Black;
                                cells.Cell("C").Style.Font.FontColor = XLColor.Black;
                                cells.Cell("E").Style.Font.FontColor = XLColor.Black;
                                cells.Cell("F").Style.Font.FontColor = XLColor.Black;
                            }
                        }
                    }

                }
                

            }
            //totalizadors
            ws.Cell(linhasUsadas + 2, "F").Style.Font.Bold = true;
            ws.Cell(linhasUsadas + 2, "G").Style.Font.Bold = true;
            ws.Cell(linhasUsadas + 2, "F").Value = "Total:";
            ws.Cell(linhasUsadas + 2, "G").FormulaA1 = $"=SUM(G2:G{linhasUsadas})";
            wb.SaveAs(Path.Combine(path, $"Fornecedores-{DateTime.Now.ToString("dd-MM-yy_HH-mm-ss")}.xlsx"));

            Form1.Instance.SetProgressBarValue(0);
        }
    }
}
