using Conciliacao_Plamev.Scripts;
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

namespace Conciliacao_Plamev.Forms
{
    public partial class ParametrizaçãoDePrefixos : Form
    {
        List<Prefixos> prefixosDefinidos = BancoDeDados.GetPrefixos();
        public ParametrizaçãoDePrefixos()
        {
            InitializeComponent();
            AtualizarGV();
        }
        private void AtualizarGV()
        {
            prefixosGV.DataSource = null;
            prefixosGV.DataSource = prefixosDefinidos.OrderByDescending(x => x.index).ToList();
            prefixosGV.AutoResizeColumns();
            prefixosGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            prefixosGV.Columns["index"].Visible = false;
            prefixosGV.Columns["prefx"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //Ferramenta para ajudar a entender funcionalidade
        ToolTip ttp = new();
        private void HelpButton_MouseEnter(object sender, EventArgs e)
        {
            ttp.Show("Adicione ou remova prefixos padrões que são utilizados para verificação e captura\n dos números das notas presentes nos históricos de movimentação", HelpButton, 2000);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Digite o prefixo desejado");

            if (prefixosDefinidos.Any(x => x.prefx == input))
            {
                MessageBox.Show("Prefixo já existente na lista!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!String.IsNullOrEmpty(input))
            {
                BancoDeDados.AddPrefixo(new Prefixos() { prefx = input });
                prefixosDefinidos = BancoDeDados.GetPrefixos();
                AtualizarGV();
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if(prefixosGV.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow selected in prefixosGV.SelectedRows)
                {
                    BancoDeDados.RemovePrefixo(selected.Cells["prefx"].Value.ToString() ?? "");
                    prefixosDefinidos = BancoDeDados.GetPrefixos();
                    AtualizarGV();
                }
            }
        }
    }
    public class Prefixos
    {
        public long index { get; set; }
        public string? prefx { get; set; }
    }
}
