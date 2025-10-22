namespace Conciliacao_Plamev
{
    partial class RelatorioDeContas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            pesquisarTextBox = new TextBox();
            tabelaContas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tabelaContas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "Procurar:";
            // 
            // pesquisarTextBox
            // 
            pesquisarTextBox.Location = new Point(73, 6);
            pesquisarTextBox.Name = "pesquisarTextBox";
            pesquisarTextBox.Size = new Size(303, 23);
            pesquisarTextBox.TabIndex = 1;
            pesquisarTextBox.TextChanged += pesquisarTextBox_TextChanged;
            // 
            // tabelaContas
            // 
            tabelaContas.AllowUserToAddRows = false;
            tabelaContas.AllowUserToDeleteRows = false;
            tabelaContas.AllowUserToResizeColumns = false;
            tabelaContas.AllowUserToResizeRows = false;
            tabelaContas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tabelaContas.Location = new Point(12, 35);
            tabelaContas.MultiSelect = false;
            tabelaContas.Name = "tabelaContas";
            tabelaContas.ReadOnly = true;
            tabelaContas.RowHeadersVisible = false;
            tabelaContas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabelaContas.Size = new Size(364, 442);
            tabelaContas.TabIndex = 2;
            tabelaContas.CellDoubleClick += tabelaContas_CellDoubleClick;
            // 
            // RelatorioDeContas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(388, 489);
            Controls.Add(tabelaContas);
            Controls.Add(pesquisarTextBox);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "RelatorioDeContas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RelatorioDeContas";
            ((System.ComponentModel.ISupportInitialize)tabelaContas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox pesquisarTextBox;
        private DataGridView tabelaContas;
    }
}