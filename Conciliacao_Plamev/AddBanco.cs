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
            fornecedorTB.Checked = false;
            clienteTB.Checked = true;
        }

        private void fornecedorTB_CheckedChanged(object sender, EventArgs e)
        {
            clienteTB.Checked = false;
            fornecedorTB.Checked = true;
        }

        
    }
}
