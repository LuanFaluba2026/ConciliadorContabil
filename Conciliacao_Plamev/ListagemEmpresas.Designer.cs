namespace Conciliacao_Plamev
{
    partial class ListagemEmpresas
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
            empresasListBox = new ListBox();
            label1 = new Label();
            pesquisarEmpresa = new TextBox();
            AddButton = new Button();
            RemoveButton = new Button();
            SuspendLayout();
            // 
            // empresasListBox
            // 
            empresasListBox.FormattingEnabled = true;
            empresasListBox.ItemHeight = 15;
            empresasListBox.Location = new Point(12, 35);
            empresasListBox.Name = "empresasListBox";
            empresasListBox.Size = new Size(333, 544);
            empresasListBox.TabIndex = 0;
            empresasListBox.DoubleClick += empresasListBox_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 1;
            label1.Text = "Pesquisar:";
            // 
            // pesquisarEmpresa
            // 
            pesquisarEmpresa.Location = new Point(78, 6);
            pesquisarEmpresa.Name = "pesquisarEmpresa";
            pesquisarEmpresa.PlaceholderText = "Empresa";
            pesquisarEmpresa.Size = new Size(182, 23);
            pesquisarEmpresa.TabIndex = 2;
            pesquisarEmpresa.TextChanged += pesquisarEmpresa_TextChanged;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(289, 6);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(25, 23);
            AddButton.TabIndex = 3;
            AddButton.Text = "+";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.Location = new Point(320, 6);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(25, 23);
            RemoveButton.TabIndex = 4;
            RemoveButton.Text = "-";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // ListagemEmpresas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 592);
            Controls.Add(RemoveButton);
            Controls.Add(AddButton);
            Controls.Add(pesquisarEmpresa);
            Controls.Add(label1);
            Controls.Add(empresasListBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ListagemEmpresas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListagemEmpresas";
            FormClosing += ListagemEmpresas_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox empresasListBox;
        private Label label1;
        private TextBox pesquisarEmpresa;
        private Button AddButton;
        private Button RemoveButton;
    }
}