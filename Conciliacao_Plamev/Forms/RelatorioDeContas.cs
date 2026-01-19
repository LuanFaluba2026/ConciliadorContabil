using Conciliacao_Plamev.Scripts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conciliacao_Plamev
{
    public partial class RelatorioDeContas : Form
    {
        public RelatorioDeContas()
        {
            InitializeComponent();
            MostrarContas(BancoDeDados.GetContas());
        }

        private void MostrarContas(List<CodigoContas> contas)
        {
            tabelaContas.DataSource = contas;
            tabelaContas.Columns["contaAnalitica"].Visible = false;
            tabelaContas.AutoResizeColumns();
            tabelaContas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            tabelaContas.Columns["nomeForn"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void pesquisarTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pesquisarTextBox.Text))
            {
                MostrarContas(BancoDeDados.GetContas());
            }
            else
            {
                MostrarContas(BancoDeDados.GetContas().Where(x => x.nomeForn.Contains(pesquisarTextBox.Text.ToUpper(), StringComparison.OrdinalIgnoreCase)).ToList());
            }
        }

        private void tabelaContas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form2.form2.textBoxConta.Text = tabelaContas.Rows[e.RowIndex].Cells["codigoForn"].Value.ToString();
            Form2.form2.ActiveControl = Form2.form2.textBoxConta;
            this.Close();
        }
    }
}
