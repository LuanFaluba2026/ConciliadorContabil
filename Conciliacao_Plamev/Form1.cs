using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Conciliacao_Plamev
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Data");
        public Form1()
        {
            InitializeComponent();
            Instance = this;

            ListagemEmpresas form = new();
            form.ShowDialog(this);

            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }
            progressBar1.Step = 1;

        }
        public void MudarEmpresa()
        {
            displayEmpresa.Text = BancoDeDados._empresa;
        }
        public void SetProgressBarValue(int value)
        {
            progressBar1.Invoke((Action)(() => progressBar1.Maximum = value));
        }
        public void SetMaxProgressBar(int maxValue)
        {
            progressBar1.Invoke((Action)(() => progressBar1.Maximum = maxValue));
        }
        public void StepProgressBar()
        {
            progressBar1.Invoke((Action)(() => progressBar1.PerformStep()));
        }


        public static string razaoPath;
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Title = "Selecione uma planilha";
            ofd.Filter = "Planilhas Excel (*.csv;*.xlsx)|*.csv;*xlsx|Todos os Arquivos (*.*)|*.*";
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
            SheetLayout sheetL = new();
            BancoDeDados.CriarTabelaSQLite();

            try
            {
                if (ImportarMovimentoCheck.Checked)
                {
                    if (!String.IsNullOrEmpty(competenciaTextBox.Text) && !String.IsNullOrEmpty(razaoPath))
                    {
                        sw.Start();
                        logBox.AppendText("\r\nIniciando Processamento...\r\n");
                        if (SubstituirButton.Checked)
                        {
                            var dlg = MessageBox.Show("Ao processar, todos os lançamentos dessa competência serão substituídos, deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dlg == DialogResult.Yes)
                            {
                                Directory.CreateDirectory(dbPath);
                                Directory.CreateDirectory(dbPath + @"\Backup");

                                File.Copy($@"{dbPath}\{BancoDeDados._empresa}.sqlite", $@"{dbPath}\Backup\{BancoDeDados._empresa}_BACKUP_{DateTime.Now.ToString("dd-MM-yyyy-HH.mm.ss")}.sqlite");

                                ConverterRazao.IniciarSubstituicao();

                            }
                            else
                            {
                                throw new Exception("Processamento cancelado");
                            }
                        }

                        await Task.Run(() =>
                        {
                            if (Path.GetExtension(razaoPath) == ".csv")
                            {
                                ConverterRazaoSenior.Conversao();
                                SheetLayout.CreateSheet();
                            }
                            else
                            {
                                ConverterRazao.Conversao();
                                SheetLayout.CreateSheet();
                            }
                        });
                        sw.Stop();
                        if (SubstituirButton.Checked)
                            MessageBox.Show("Foi gerado um BackUp do banco de dados anterior em \"C:\\Data\\BancoDeDados_Movimentação_BACKUP.sqlite\"", "Confirmação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        logBox.AppendText($"\r\n Processamento Concluído! ({sw.Elapsed.ToString(@"hh\:mm\:ss")})");
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        ProcessButton.Enabled = true;
                        throw new Exception("Informações Inválidas");
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(competenciaTextBox.Text))
                    {
                        sw.Start();
                        logBox.AppendText("\r\nIniciando Processamento...\r\n");
                        await Task.Run(() =>
                        {
                            SheetLayout.CreateSheet();
                        });
                        sw.Stop();
                        logBox.AppendText($"\r\n Processamento Concluído ! ({sw.Elapsed.ToString(@"hh\:mm\:ss")})");
                    }
                    else
                    {
                        this.Cursor = Cursors.Default;
                        ProcessButton.Enabled = true;
                        throw new Exception("Informe a competência.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} || {ex.StackTrace}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                ProcessButton.Enabled = true;
                return;
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
            ImportarMovimentacao newWindow = new ImportarMovimentacao();
            newWindow.ShowDialog();
        }

        private void ImportarMovimentoCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!ImportarMovimentoCheck.Checked)
            {
                OpenFileButton.Enabled = false;
                pathTextBox.Enabled = false;
                SubstituirButton.Enabled = false;
            }
            else
            {
                OpenFileButton.Enabled = true;
                pathTextBox.Enabled = true;
                SubstituirButton.Enabled = true;
            }
        }

        private void SelecionarEmpresaButton_Click(object sender, EventArgs e)
        {
            ListagemEmpresas form = new();
            var posBotao = SelecionarEmpresaButton.PointToScreen(Point.Empty);

            form.StartPosition = FormStartPosition.Manual; // posição manual
            form.Location = new System.Drawing.Point(posBotao.X, posBotao.Y);
            form.ShowDialog();
        }

        private void gerenciamentoContasCadastradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenciamentoContasCadastradas form = new();
            form.ShowDialog();
        }
    }
}
