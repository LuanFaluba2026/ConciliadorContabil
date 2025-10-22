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
    public partial class ImportarMovimentacao : Form
    {
        public ImportarMovimentacao()
        {
            InitializeComponent();
        }

        private void gerarModeloLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FolderBrowserDialog fbd = new())
            {
                fbd.Description = "Selecione uma pasta";
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    GerarCsv(fbd.SelectedPath);
                }
            }
        }
        private void GerarCsv(string path)
        {
            File.WriteAllText(Path.Combine(path, "Importar Movimentos.csv"), "Codigo;Data;Nota Fiscal;Descricao;Debito;Credito");
            MessageBox.Show("Arquivo criado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FindPathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new();
            ofd.Filter = "Arquivo .CSV (*.csv) | *.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                csvPath.Text = ofd.FileName;
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(csvPath.Text))
                {
                    var msg = MessageBox.Show("Deseja importar os movimentos do arquivo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(msg == DialogResult.Yes)
                    {
                        ImpSaldosAnteriores.ImportarSaldo(csvPath.Text);
                    }
                }
                else
                {
                    throw new Exception("Selecione um arquivo.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
