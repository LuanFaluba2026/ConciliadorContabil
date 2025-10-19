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
            CodigoContas contasCadastradas = BancoDeDados.GetContas().FirstOrDefault(x => x.codigoForn == textBox1.Text);
            if (contasCadastradas != null)
            {
                List<Movimento> movConta = mostrarEncerrados.Checked ?
                                                   BancoDeDados.GetMovimentos().Where(x => x.codigoForn == textBox1.Text).ToList() :
                                                   BancoDeDados.GetMovimentos().Where(x => x.codigoForn == textBox1.Text && String.IsNullOrEmpty(x.dataEncerramento)).ToList();
                dataGridView1.DataSource = movConta.OrderByDescending(x => x.dataEncerramento).ToList();
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.Columns["historico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
                CancelarButton.Enabled = true;

                for (int i = 1; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].ReadOnly = false;
                }
            }
            else
            {
                textBox1.Enabled = true;
                mostrarEncerrados.Enabled = true;

                EditarButton.Enabled = true;
                SalvarButton.Enabled = false;
                CancelarButton.Enabled = false;

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
            isEditing = false;
        }
        private void mostrarEncerrados_CheckedChanged(object sender, EventArgs e)
        {
            MostrarMovimento();
        }
    }
}