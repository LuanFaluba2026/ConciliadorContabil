using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Wordprocessing;
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

            if (!Directory.Exists(@"c:\Data"))
            {
                Directory.CreateDirectory(@"c:\Data");
                BancoDeDados.CriarBancoSQlite();
            }
        }
        public static string razaoPath;
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Title = "Selecione uma planilha";
            ofd.Filter = "Planilhas Excel (*.xls;*.xlsx)|*.xls;*xlsx|Todos os Arquivos (*.*)|*.*";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                razaoPath = ofd.FileName;
                pathTextBox.Text = razaoPath;
            }
        }
        private async void ProcessButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.AppStarting;
            ProcessButton.Enabled = false;

            Stopwatch sw = new();
            ConverterRazao conv = new();
            SheetLayout sheetL = new();
            Form1 form = new();

            BancoDeDados.CriarTabelaSQLite();
            try
            {
                if (!String.IsNullOrEmpty(competenciaTextBox.Text) && !String.IsNullOrEmpty(razaoPath))
                {
                    sw.Start();
                    logBox.AppendText("\r\nIniciando Processamento...\r\n");
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
                else
                {
                    throw new Exception("Informações Inválidas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} || {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Cursor = Cursors.Default;
            ProcessButton.Enabled = true;
        }

        public static DateTime competencia = new();
        private void OnCompetenciaChange(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(competenciaTextBox.Text))
            {
                string[] comp = competenciaTextBox.Text.Split("/");
                competencia = new DateTime(Int32.Parse(comp[1]), Int32.Parse(comp[0]), 1 /*DateTime.DaysInMonth(Int32.Parse(comp[1]), Int32.Parse(comp[0]))*/);
                Debug.WriteLine(competencia.ToString());
            }
        }
        private void competenciaTextBox_TextChanged(object sender, EventArgs e)
        {

            competenciaTextBox.TextChanged -= competenciaTextBox_TextChanged;

            string texto = competenciaTextBox.Text;
            texto = new string(texto.Where(c => char.IsDigit(c) || c == '/').ToArray());
            if (texto.Length > 2 && !texto.Contains("/"))
            {
                texto = texto.Insert(2, "/");
            }

            if (texto.Length > 7)
                texto = texto.Substring(0, 7);

            competenciaTextBox.Text = texto;

            competenciaTextBox.SelectionStart = competenciaTextBox.Text.Length;

            competenciaTextBox.TextChanged += competenciaTextBox_TextChanged;
        }
        private void gerenciamentoSaldosAnterioresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newWindow = new Form2();
            newWindow.ShowDialog();
        }

        private void importarSaldosAnterioresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImpSaldosAnteriores.ImportarSaldo(@"C:\Users\secun\Downloads\MOVIMENTACOES EM ABERTO.csv");
        }
    }
}
