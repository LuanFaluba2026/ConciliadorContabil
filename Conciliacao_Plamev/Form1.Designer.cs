namespace Conciliacao_Plamev
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            pathTextBox = new TextBox();
            ProcessButton = new Button();
            OpenFileButton = new Button();
            logBox = new TextBox();
            label1 = new Label();
            competenciaTextBox = new TextBox();
            menuStrip1 = new MenuStrip();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            gerenciamentoSaldosAnterioresToolStripMenuItem = new ToolStripMenuItem();
            importaçãoToolStripMenuItem = new ToolStripMenuItem();
            importarSaldosAnterioresToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pathTextBox
            // 
            pathTextBox.Location = new Point(12, 62);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new Size(326, 23);
            pathTextBox.TabIndex = 0;
            // 
            // ProcessButton
            // 
            ProcessButton.Location = new Point(397, 54);
            ProcessButton.Name = "ProcessButton";
            ProcessButton.Size = new Size(109, 37);
            ProcessButton.TabIndex = 1;
            ProcessButton.Text = "Processar";
            ProcessButton.UseVisualStyleBackColor = true;
            ProcessButton.Click += ProcessButton_Click;
            // 
            // OpenFileButton
            // 
            OpenFileButton.Location = new Point(344, 61);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(27, 24);
            OpenFileButton.TabIndex = 2;
            OpenFileButton.Text = "...";
            OpenFileButton.UseVisualStyleBackColor = true;
            OpenFileButton.Click += OpenFileButton_Click;
            // 
            // logBox
            // 
            logBox.Location = new Point(19, 106);
            logBox.Multiline = true;
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.Size = new Size(487, 146);
            logBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 35);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 5;
            label1.Text = "Competência:";
            // 
            // competenciaTextBox
            // 
            competenciaTextBox.Location = new Point(99, 32);
            competenciaTextBox.Name = "competenciaTextBox";
            competenciaTextBox.Size = new Size(69, 23);
            competenciaTextBox.TabIndex = 6;
            competenciaTextBox.TextChanged += competenciaTextBox_TextChanged;
            competenciaTextBox.Leave += OnCompetenciaChange;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ButtonHighlight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem, importaçãoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(524, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.BackColor = SystemColors.ButtonHighlight;
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gerenciamentoSaldosAnterioresToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // gerenciamentoSaldosAnterioresToolStripMenuItem
            // 
            gerenciamentoSaldosAnterioresToolStripMenuItem.Name = "gerenciamentoSaldosAnterioresToolStripMenuItem";
            gerenciamentoSaldosAnterioresToolStripMenuItem.Size = new Size(249, 22);
            gerenciamentoSaldosAnterioresToolStripMenuItem.Text = "Gerenciamento Saldos Anteriores";
            gerenciamentoSaldosAnterioresToolStripMenuItem.Click += gerenciamentoSaldosAnterioresToolStripMenuItem_Click;
            // 
            // importaçãoToolStripMenuItem
            // 
            importaçãoToolStripMenuItem.BackColor = SystemColors.ControlLight;
            importaçãoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importarSaldosAnterioresToolStripMenuItem });
            importaçãoToolStripMenuItem.Name = "importaçãoToolStripMenuItem";
            importaçãoToolStripMenuItem.Size = new Size(80, 20);
            importaçãoToolStripMenuItem.Text = "Importação";
            // 
            // importarSaldosAnterioresToolStripMenuItem
            // 
            importarSaldosAnterioresToolStripMenuItem.Name = "importarSaldosAnterioresToolStripMenuItem";
            importarSaldosAnterioresToolStripMenuItem.Size = new Size(254, 22);
            importarSaldosAnterioresToolStripMenuItem.Text = "Importar Saldos Anteriores (*.CSV)";
            importarSaldosAnterioresToolStripMenuItem.Click += importarSaldosAnterioresToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(524, 268);
            Controls.Add(competenciaTextBox);
            Controls.Add(label1);
            Controls.Add(logBox);
            Controls.Add(OpenFileButton);
            Controls.Add(ProcessButton);
            Controls.Add(pathTextBox);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conciliação Plamev";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TextBox pathTextBox;
        private Button ProcessButton;
        private Button OpenFileButton;
        private TextBox logBox;
        private Label label1;
        private TextBox competenciaTextBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem gerenciamentoContasToolStripMenuItem;
        private ToolStripMenuItem gerenciamentoSaldosAnterioresToolStripMenuItem;
        private ToolStripMenuItem importaçãoToolStripMenuItem;
        private ToolStripMenuItem importarSaldosAnterioresToolStripMenuItem;
    }
}
