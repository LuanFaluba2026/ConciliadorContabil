using Conciliacao_Plamev.Scripts;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conciliacao_Plamev
{
    public partial class Form2 : Form
    {
        public static Form2 form2;
        public Form2()
        {
            InitializeComponent();
            this.ActiveControl = selecionarConta;
            form2 = this;
        }

        private void MostrarMovimento()
        {
            CodigoContas conta = BancoDeDados.GetContas().FirstOrDefault(x => x.codigoForn == textBox1.Text);
            if (conta != null)
            {
                //Display fornecedor
                consultaFornecedor.Text = $"Fornecedor: {conta.nomeForn}";

                List<Movimento> movConta = mostrarEncerrados.Checked ?
                                                   BancoDeDados.GetMovimentos().Where(x => x.codigoForn == textBox1.Text).ToList() :
                                                   BancoDeDados.GetMovimentos().Where(x => x.codigoForn == textBox1.Text && String.IsNullOrEmpty(x.dataEncerramento)).ToList();
                double saldo = 0;
                foreach (var s in movConta.Where(x => String.IsNullOrEmpty(x.dataEncerramento)))
                {
                    saldo += s.credito;
                    saldo += s.debito;
                }
                consultaSaldo.Text = $"Saldo em aberto: R${saldo.ToString("F2")}";
                dataGridView1.DataSource = movConta.OrderByDescending(x => x.dataEncerramento).ToList();
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns["historico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                //formatação
                dataGridView1.Columns["dataMov"].DefaultCellStyle.Format = "dd/MM/yyy";
                dataGridView1.Columns["dataEncerramento"].DefaultCellStyle.Format = "dd/MM/yyy";

                dataGridView1.Columns["debito"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["debito"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("pt-BR");
                dataGridView1.Columns["credito"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["credito"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.GetCultureInfo("pt-BR");


                for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }
            }
            else
            {
                MessageBox.Show("Conta não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Altera elementos baseado na boolean
        private void Editar()
        {
            if (isEditing)
            {

                textBox1.Enabled = false;
                mostrarEncerrados.Enabled = false;

                EditarButton.Enabled = false;

                BotaoExcluir.Enabled = true;
                BotaoAdicionar.Enabled = true;
                DuplicarButton.Enabled = true;

                dataGridView1.ForeColor = Color.Black;

                for (int i = 1; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = false;
                }
            }
            else
            {
                consultaFornecedor.Text = $"Fornecedor:";
                consultaSaldo.Text = $"Saldo em aberto: R$0,00";
                textBox1.Enabled = true;
                mostrarEncerrados.Enabled = true;

                EditarButton.Enabled = true;

                BotaoExcluir.Enabled = false;
                BotaoAdicionar.Enabled = false;
                DuplicarButton.Enabled = false;

                dataGridView1.ForeColor = Color.Gray;

                for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = true;
                }
                dataGridView1.DataSource = null;
            }
        }

        //Chama função ao alterar valor da boolean.
        private bool _editando;
        public bool isEditing
        {
            get { return _editando; }
            set
            {
                if (_editando != value)
                {
                    _editando = value;
                    Editar();
                }
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            MostrarMovimento();
        }
        private void EditarButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
        }
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            isEditing = true;
            isEditing = false;
        }
        private void mostrarEncerrados_CheckedChanged(object sender, EventArgs e)
        {
            MostrarMovimento();
        }

        private void BotaoExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    throw new Exception("Nenhuma linhas selecionada.");

                var confirmacao = MessageBox.Show("Certeza que deseja excluir o movimento selecionado? Não será possível reverter a alteração.", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (confirmacao == DialogResult.Yes)
                {
                    BancoDeDados.ExcluirMovimento((long)dataGridView1.SelectedRows[0].Cells["idx"].Value);
                }
                MostrarMovimento();
                for (int i = 1; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BotaoAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                BancoDeDados.AddMovimento(new Movimento()
                {
                    codigoForn = textBox1.Text,
                    dataMov = DateTime.Now.ToString("dd/MM/yyyy"),
                });
                MostrarMovimento();
                for (int i = 1; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.DataBoundItem is Movimento mov)
                {
                    if (!ValidarLinha(row, "dataEncerramento"))
                    {
                        throw new Exception("Preencha os campos obrigatórios.");
                    }
                    BancoDeDados.UpdateMovimento(mov, (long)row.Cells["idx"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarLinha(DataGridViewRow row, string colDataEnc)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.OwningColumn.Name == colDataEnc)
                    continue;

                if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                    return false;
            }

            return true;
        }
        //TORNAR VALOR DEBITO NEGATIVO

        string currentCellValue = "";
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (cell == null) return;

            currentCellValue = cell.ToString();
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var contas = BancoDeDados.GetContas().ToList();
            if (dataGridView1.Columns[e.ColumnIndex].Name == "codigoForn")
            {
                var cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (cellValue == null)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = currentCellValue;
                    dataGridView1.CancelEdit();
                    return;
                }
                if (!contas.Any(x => x.codigoForn.Equals(cellValue)) && !string.IsNullOrEmpty(currentCellValue))
                {
                    MessageBox.Show("Conta inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = currentCellValue;
                    dataGridView1.CancelEdit();
                    return;
                }
            }

            if (Program.ClienteFornecedor() == "Fornecedor")
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "debito")
                {
                    var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (decimal.TryParse(cell.Value?.ToString(), out decimal valorD))
                    {
                        cell.Value = -Math.Abs(valorD);
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "credito")
                {
                    var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (decimal.TryParse(cell.Value?.ToString(), out decimal valorC))
                    {
                        cell.Value = Math.Abs(valorC);
                    }
                }
            }
            else if (Program.ClienteFornecedor() == "Cliente")
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "debito")
                {
                    var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (decimal.TryParse(cell.Value?.ToString(), out decimal valorD))
                    {
                        cell.Value = Math.Abs(valorD);
                    }
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "credito")
                {
                    var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if (decimal.TryParse(cell.Value?.ToString(), out decimal valorC))
                    {
                        cell.Value = -Math.Abs(valorC);
                    }
                }
            }
        }

        private void DuplicarButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                    throw new Exception("Nenhuma linhas selecionada.");

                List<Movimento> mov = BancoDeDados.GetMovimentos().Where(x => x.codigoForn == textBox1.Text).ToList();

                Movimento newLine = mov.FirstOrDefault(x => x.idx == (long)dataGridView1.SelectedRows[0].Cells["idx"].Value);
                if (newLine != null)
                    BancoDeDados.AddMovimento(new Movimento()
                    {
                        codigoForn = newLine.codigoForn,
                        dataMov = newLine.dataMov,
                        historico = $"index-{newLine.historico}",
                        credito = newLine.credito,
                        debito = newLine.debito,
                        notaRef = newLine.notaRef
                    });
                MostrarMovimento();
                for (int i = 1; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selecionarConta_Click(object sender, EventArgs e)
        {
            RelatorioDeContas form = new();
            var posBotao = selecionarConta.PointToScreen(Point.Empty);

            form.StartPosition = FormStartPosition.Manual; // posição manual
            form.Location = new System.Drawing.Point(posBotao.X, posBotao.Y);
            form.ShowDialog();
        }

        public TextBox textBoxConta
        {
            get { return textBox1; }
        }
    }
}