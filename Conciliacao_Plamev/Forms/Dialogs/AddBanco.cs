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
    public partial class AddBanco : Form
    {
        public AddBanco()
        {
            InitializeComponent();
        }

        private void clienteTB_CheckedChanged(object sender, EventArgs e)
        {
            if (clienteTB.Checked)
                fornecedorTB.Checked = false;
        }

        private void fornecedorTB_CheckedChanged(object sender, EventArgs e)
        {
            if (fornecedorTB.Checked)
                clienteTB.Checked = false;
        }

        private void CancelarBttn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkBttn_Click(object sender, EventArgs e)
        {
            CreateDb();
            this.Close();
        }
        private void CreateDb()
        {
            try
            {
                string tipo = "";
                if (fornecedorTB.Checked)
                    tipo = "Fornecedor";
                else if (clienteTB.Checked)
                    tipo = "Cliente";
                else
                    throw new Exception();

                
                if (String.IsNullOrEmpty(nomeEmpresaTB.Text))
                    throw new Exception();

                BancoDeDados._empresa = nomeEmpresaTB.Text; 

                BancoDeDados.CriarBancoSQlite(tipo);

            }catch(Exception ex)
            {
                MessageBox.Show("Campos Inválidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
