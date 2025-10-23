namespace Conciliacao_Plamev
{
    partial class GerenciamentoContasCadastradas
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
            pesquisarContas = new TextBox();
            label1 = new Label();
            contasGridView = new DataGridView();
            AdicionarButton = new Button();
            RemoverButton = new Button();
            ((System.ComponentModel.ISupportInitialize)contasGridView).BeginInit();
            SuspendLayout();
            // 
            // pesquisarContas
            // 
            pesquisarContas.Location = new Point(78, 12);
            pesquisarContas.Name = "pesquisarContas";
            pesquisarContas.Size = new Size(229, 23);
            pesquisarContas.TabIndex = 0;
            pesquisarContas.TextChanged += pesquisarContas_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Pesquisar:";
            // 
            // contasGridView
            // 
            contasGridView.AllowUserToAddRows = false;
            contasGridView.AllowUserToDeleteRows = false;
            contasGridView.AllowUserToResizeColumns = false;
            contasGridView.AllowUserToResizeRows = false;
            contasGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contasGridView.Location = new Point(12, 41);
            contasGridView.MultiSelect = false;
            contasGridView.Name = "contasGridView";
            contasGridView.ReadOnly = true;
            contasGridView.RowHeadersVisible = false;
            contasGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contasGridView.Size = new Size(689, 289);
            contasGridView.TabIndex = 2;
            // 
            // AdicionarButton
            // 
            AdicionarButton.Location = new Point(545, 336);
            AdicionarButton.Name = "AdicionarButton";
            AdicionarButton.Size = new Size(75, 23);
            AdicionarButton.TabIndex = 3;
            AdicionarButton.Text = "Adicionar";
            AdicionarButton.UseVisualStyleBackColor = true;
            AdicionarButton.Click += AdicionarButton_Click;
            // 
            // RemoverButton
            // 
            RemoverButton.Location = new Point(626, 336);
            RemoverButton.Name = "RemoverButton";
            RemoverButton.Size = new Size(75, 23);
            RemoverButton.TabIndex = 4;
            RemoverButton.Text = "Remover";
            RemoverButton.UseVisualStyleBackColor = true;
            RemoverButton.Click += RemoverButton_Click;
            // 
            // GerenciamentoContasCadastradas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 364);
            Controls.Add(RemoverButton);
            Controls.Add(AdicionarButton);
            Controls.Add(contasGridView);
            Controls.Add(label1);
            Controls.Add(pesquisarContas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "GerenciamentoContasCadastradas";
            Text = "GerenciamentoContasCadastradas";
            ((System.ComponentModel.ISupportInitialize)contasGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox pesquisarContas;
        private Label label1;
        private DataGridView contasGridView;
        private Button AdicionarButton;
        private Button RemoverButton;
    }
}