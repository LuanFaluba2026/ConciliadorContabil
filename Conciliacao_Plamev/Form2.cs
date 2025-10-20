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
        public Form2()
        {
            InitializeComponent();
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
                    saldo -= s.debito;
                }
                consultaSaldo.Text = $"Saldo em aberto: R${saldo.ToString("F2")}";
                dataGridView1.DataSource = movConta.OrderByDescending(x => x.dataEncerramento).ToList();
                dataGridView1.Columns["codigoForn"].Visible = false;
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns["historico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.ForeColor = Color.Gray;
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
                SalvarButton.Enabled = true;

                BotaoExcluir.Enabled = true;
                BotaoAdicionar.Enabled = true;

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
                SalvarButton.Enabled = false;

                BotaoExcluir.Enabled = false;
                BotaoAdicionar.Enabled = false;

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
        private void SalvarButton_Click(object sender, EventArgs e)
        {
            isEditing = false;
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
                if(confirmacao == DialogResult.Yes)
                {
                    BancoDeDados.ExcluirMovimento(dataGridView1.SelectedRows[0].Cells["historico"].Value?.ToString() ?? "");
                    MostrarMovimento();
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}