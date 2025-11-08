using DocumentFormat.OpenXml.Bibliography;
using Microsoft.VisualBasic;
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
    public partial class ListagemEmpresas : Form
    {
        public List<string> bancos = new();
        public ListagemEmpresas()
        {
            InitializeComponent();
            if (!Directory.Exists(Form1.dbPath))
            {
                Directory.CreateDirectory(Form1.dbPath);
            }
            GerenciarEmpresas();
            ListarEmpresas(bancos);
        }
        public void GerenciarEmpresas()
        {
            bancos.Clear();
            foreach (var file in Directory.GetFiles(Form1.dbPath).Where(x => !x.Contains("BACKUP", StringComparison.OrdinalIgnoreCase)))
            {
                bancos.Add(Path.GetFileNameWithoutExtension(file));
            }
        }
        public void ListarEmpresas(List<string> lista)
        {
            empresasListBox.DataSource = null;
            empresasListBox.DataSource = lista;
        }

        private void pesquisarEmpresa_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(pesquisarEmpresa.Text))
            {
                ListarEmpresas(bancos);
            }
            else
            {
                ListarEmpresas(bancos.Where(x => x.Contains(pesquisarEmpresa.Text.ToUpper())).ToList());
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string val = Interaction.InputBox("Digite o nome da empresa:", "Entrada de dados");
            if (!String.IsNullOrEmpty(val))
            {
                BancoDeDados._empresa = val.ToUpper().Replace(" ", "_");
                BancoDeDados.CriarBancoSQlite();
                GerenciarEmpresas();
                ListarEmpresas(bancos);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if(empresasListBox.SelectedItems != null)
            {
                string file = Path.GetFileNameWithoutExtension(Directory.GetFiles(Form1.dbPath).FirstOrDefault(x => x.Contains(empresasListBox.SelectedItem.ToString())));
                BancoDeDados.ExcluirBancoSQlite(file);
                GerenciarEmpresas();
                ListarEmpresas(bancos);
            }
        }

        private void empresasListBox_DoubleClick(object sender, EventArgs e)
        {
            if (empresasListBox.SelectedItems != null)
            {
                BancoDeDados._empresa = empresasListBox.SelectedItem.ToString();
                Form1.Instance.MudarEmpresa();
                this.Close();
            }
        }

        private void ListagemEmpresas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrEmpty(BancoDeDados._empresa))
            {
                MessageBox.Show("Selecione uma empresa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
