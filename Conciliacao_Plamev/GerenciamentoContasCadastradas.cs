using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conciliacao_Plamev
{
    public partial class GerenciamentoContasCadastradas : Form
    {
        public GerenciamentoContasCadastradas()
        {
            InitializeComponent();
            MandarListagem();
        }
        public void ListarContas(List<CodigoContas> lista)
        {
            contasGridView.DataSource = null;
            contasGridView.DataSource = lista;
            contasGridView.AutoResizeColumns();
            contasGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            contasGridView.Columns["nomeForn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void MandarListagem()
        {
            if (String.IsNullOrEmpty(pesquisarContas.Text))
            {
                ListarContas(BancoDeDados.GetContas());
            }
            else
            {
                ListarContas(BancoDeDados.GetContas().Where(x => x.nomeForn.Contains(pesquisarContas.Text.ToUpper())).ToList());
            }
        }

        private void AdicionarButton_Click(object sender, EventArgs e)
        {
            CaixaAdicionarConta form = new();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MandarListagem();
            }
        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if(contasGridView.SelectedRows.Count > 0)
            {
                var msg = MessageBox.Show("Deseja excluir conta selecionada?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(msg == DialogResult.Yes)
                {
                    var row = contasGridView.SelectedRows[0].Cells["codigoForn"].Value.ToString();
                    if (!String.IsNullOrEmpty(row))
                        BancoDeDados.RemoveConta(row);
                    else
                        MessageBox.Show("Conta selecionada não encontrada.");

                    MandarListagem();
                }
            }
        }
        private void pesquisarContas_TextChanged(object sender, EventArgs e)
        {
            MandarListagem();
        }
    }
}
