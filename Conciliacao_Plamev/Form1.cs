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

            if (!Directory.Exists(@"c:\Data"))
                Directory.CreateDirectory(@"c:\Data");
        }
        private async void ProcessButton_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new();
            ConverterRazao conv = new();
            SheetLayout sheetL = new();
            Form1 form = new();

            /*BancoDeDados.CriarBancoSQlite();
            BancoDeDados.CriarTabelaSQLite();*/

            if(!String.IsNullOrEmpty(competenciaTextBox.Text))
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
                MessageBox.Show("Insira a competência", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public static DateTime competencia = new();
        private void OnCompetenciaChange(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(competenciaTextBox.Text))
            {
                string[] comp = competenciaTextBox.Text.Split("/");
                competencia = new DateTime(Int32.Parse(comp[1]), Int32.Parse(comp[0]), 1);
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
        private void GerenciarSaldos_Click(object sender, EventArgs e)
        {
            Form2 newWindow = new Form2();
            newWindow.ShowDialog();
        }

    }
}
