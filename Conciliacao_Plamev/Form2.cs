using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var contasCadastradas = Program.contasCadastradas;
            if (!String.IsNullOrEmpty(textBox1.Text) && contasCadastradas.Any(x => x.codigo == textBox1.Text))
            {

            }
            else
            {
                MessageBox.Show("Código Inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void EditarButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                EditarButton.Enabled = false;
                SalvarButton.Enabled = true;
                CancelarButton.Enabled = true;
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.AllowUserToDeleteRows = true;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = false;
                }
            }
            else
            {
                MessageBox.Show("Insira um código de fornecedor.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            if (!EditarButton.Enabled)
            {
                EditarButton.Enabled = true;
                SalvarButton.Enabled = false;
                CancelarButton.Enabled = false;
                dataGridView1.AllowUserToAddRows = false;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.ReadOnly = true;
                }
            }
        }

        private void SalvarButton_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            EditarButton.Enabled = true;
            SalvarButton.Enabled = false;
            CancelarButton.Enabled = false;
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
