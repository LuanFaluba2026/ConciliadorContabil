using DocumentFormat.OpenXml.ExtendedProperties;
using System.Diagnostics;
using System.Windows.Forms;

namespace Conciliacao_Plamev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private async void ProcessButton_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new();
            ConverterRazao conv = new();
            SheetLayout sheetL = new();
            Form1 form = new();

            logBox.AppendText("\r\nIniciando Processamento...\r\n");
            sw.Start();
            await Task.Run(() =>
            {
                conv.Conversao();
                sheetL.CreateSheet();
                Program.movimentacoes.Clear();


                Invoke(new Action(() =>
                {
                    foreach (var contas in Program.contasCadastradas)
                    {
                        string log = $"{contas.codigo} / {contas.contaAnalitica} / {contas.nomeFornecedor} / {contas.saldo}";
                        logBox.AppendText($"{log}\r\n");
                    }
                }));

            });
            sw.Stop();
            logBox.AppendText($"\r\n Processamento Concluído ! ({sw.Elapsed.ToString(@"hh\:mm\:ss")})");
        }

        private void ListarContas_Click(object sender, EventArgs e)
        {
            foreach (var contas in Program.contasCadastradas)
            {
                Debug.WriteLine($"{contas.codigo} / {contas.contaAnalitica} / {contas.nomeFornecedor} / {contas.saldo}");
            }
        }

        private void ListarMovimentacao_Click(object sender, EventArgs e)
        {
            foreach (var contas in Program.movimentacoes)
            {
                Debug.WriteLine($"{contas.codigoForn} / {contas.dataLancamento} / {contas.historico} / {contas.debito} / {contas.credito} / {contas.notaRef}");
            }
        }
    }
}
