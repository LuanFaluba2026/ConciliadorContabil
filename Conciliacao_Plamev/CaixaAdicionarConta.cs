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
    public partial class CaixaAdicionarConta : Form
    {
        public CaixaAdicionarConta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(codigoTB.Text) || string.IsNullOrEmpty(nomeTB.Text))
                MessageBox.Show("Preencha todos os campos obrigatórios.");
            else
            {
                BancoDeDados.AddConta(new CodigoContas()
                {
                    codigoForn = codigoTB.Text.ToUpper(),
                    contaAnalitica = analiticoTB.Text.ToUpper(),
                    nomeForn = nomeTB.Text.ToUpper()
                });
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
