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

        BindingList<MovimentosAbertos> listaOriginal;
        BindingList<MovimentosAbertos> listaAtual;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {/*
            string codigo = textBox1.Text;
            if (!String.IsNullOrEmpty(codigo))
            {
                var contaSelecionada = Program.contasCadastradas.Where(x => x.codigo == codigo).ToList();

                if (contaSelecionada.Count == 0)
                {
                    MessageBox.Show("Código do Fornecedor Inválido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox1.Text = "";
                }
                else
                {
                    //var saldosPorConta = Program.saldosEmAberto.Where(x => x.codigoForn == contaSelecionada[0].codigo);

                    listaOriginal = new BindingList<MovimentosAbertos>(
                        saldosPorConta.Select(m => new MovimentosAbertos
                        {
                            dataMov = m.dataMov,
                            notaRef = m.notaRef,
                            historico = m.historico,
                            credito = m.credito
                        }).ToList()
                     );

                    listaAtual = new BindingList<MovimentosAbertos>(
                        saldosPorConta.Select(m => new MovimentosAbertos
                        {
                            dataMov = m.dataMov,
                            notaRef = m.notaRef,
                            historico = m.historico,
                            credito = m.credito
                        }).ToList()
                    );

                    dataGridView1.DataSource = listaAtual;
                }
            }*/
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

                listaAtual = new BindingList<MovimentosAbertos>(
                listaOriginal.Select(m => new MovimentosAbertos
                {
                    dataMov = m.dataMov,
                    notaRef = m.notaRef,
                    historico = m.historico,
                    credito = m.credito
                }).ToList()
                );

                dataGridView1.DataSource = listaAtual;
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
            listaAtual = new BindingList<MovimentosAbertos>(
                listaOriginal.Select(m => new MovimentosAbertos
                {
                    dataMov = m.dataMov,
                    notaRef = m.notaRef,
                    historico = m.historico,
                    credito = m.credito
                }).ToList()
                );
            foreach (var item in listaAtual)
            {
                    
                    
                    /*codigoForn = item.codigoForn,
                    dataMov = item.dataMov,
                    notaRef = item.notaRef,
                    historico = item.historico,
                    credito = item.credito});*/
            }
        }
    }
}
