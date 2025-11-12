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
            ImportarMovimentoCheck = new CheckBox();
            progressBar1 = new ProgressBar();
            SubstituirButton = new CheckBox();
            cadastrosToolStripMenuItem = new ToolStripMenuItem();
            gerenciamentoSaldosAnterioresToolStripMenuItem = new ToolStripMenuItem();
            gerenciamentoContasCadastradasToolStripMenuItem = new ToolStripMenuItem();
            importaçãoToolStripMenuItem = new ToolStripMenuItem();
            importarSaldosAnterioresToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            SelecionarEmpresaButton = new Button();
            displayEmpresa = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pathTextBox
            // 
            pathTextBox.Location = new Point(12, 88);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new Size(492, 23);
            pathTextBox.TabIndex = 0;
            // 
            // ProcessButton
            // 
            ProcessButton.Location = new Point(567, 81);
            ProcessButton.Name = "ProcessButton";
            ProcessButton.Size = new Size(109, 37);
            ProcessButton.TabIndex = 1;
            ProcessButton.Text = "Processar";
            ProcessButton.UseVisualStyleBackColor = true;
            ProcessButton.Click += ProcessButton_Click;
            // 
            // OpenFileButton
            // 
            OpenFileButton.Location = new Point(510, 88);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(27, 24);
            OpenFileButton.TabIndex = 2;
            OpenFileButton.Text = "...";
            OpenFileButton.UseVisualStyleBackColor = true;
            OpenFileButton.Click += OpenFileButton_Click;
            // 
            // logBox
            // 
            logBox.Location = new Point(19, 123);
            logBox.Multiline = true;
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.Size = new Size(657, 297);
            logBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 61);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 5;
            label1.Text = "Competência:";
            // 
            // competenciaTextBox
            // 
            competenciaTextBox.Location = new Point(99, 58);
            competenciaTextBox.Name = "competenciaTextBox";
            competenciaTextBox.Size = new Size(69, 23);
            competenciaTextBox.TabIndex = 6;
            competenciaTextBox.TextChanged += competenciaTextBox_TextChanged;
            competenciaTextBox.Leave += OnCompetenciaChange;
            // 
            // ImportarMovimentoCheck
            // 
            ImportarMovimentoCheck.AutoSize = true;
            ImportarMovimentoCheck.Checked = true;
            ImportarMovimentoCheck.CheckState = CheckState.Checked;
            ImportarMovimentoCheck.Location = new Point(174, 61);
            ImportarMovimentoCheck.Name = "ImportarMovimentoCheck";
            ImportarMovimentoCheck.RightToLeft = RightToLeft.No;
            ImportarMovimentoCheck.Size = new Size(142, 19);
            ImportarMovimentoCheck.TabIndex = 8;
            ImportarMovimentoCheck.Text = "Importar movimentos";
            ImportarMovimentoCheck.UseVisualStyleBackColor = true;
            ImportarMovimentoCheck.CheckedChanged += ImportarMovimentoCheck_CheckedChanged;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(19, 426);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(657, 15);
            progressBar1.TabIndex = 9;
            // 
            // SubstituirButton
            // 
            SubstituirButton.AutoSize = true;
            SubstituirButton.Location = new Point(322, 62);
            SubstituirButton.Name = "SubstituirButton";
            SubstituirButton.RightToLeft = RightToLeft.No;
            SubstituirButton.Size = new Size(150, 19);
            SubstituirButton.TabIndex = 10;
            SubstituirButton.Text = "Substituir Lançamentos";
            SubstituirButton.UseVisualStyleBackColor = true;
            // 
            // cadastrosToolStripMenuItem
            // 
            cadastrosToolStripMenuItem.BackColor = SystemColors.ButtonHighlight;
            cadastrosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gerenciamentoSaldosAnterioresToolStripMenuItem, gerenciamentoContasCadastradasToolStripMenuItem });
            cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            cadastrosToolStripMenuItem.Size = new Size(71, 20);
            cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // gerenciamentoSaldosAnterioresToolStripMenuItem
            // 
            gerenciamentoSaldosAnterioresToolStripMenuItem.Name = "gerenciamentoSaldosAnterioresToolStripMenuItem";
            gerenciamentoSaldosAnterioresToolStripMenuItem.Size = new Size(262, 22);
            gerenciamentoSaldosAnterioresToolStripMenuItem.Text = "Gerenciamento Saldos Anteriores";
            gerenciamentoSaldosAnterioresToolStripMenuItem.Click += gerenciamentoSaldosAnterioresToolStripMenuItem_Click;
            // 
            // gerenciamentoContasCadastradasToolStripMenuItem
            // 
            gerenciamentoContasCadastradasToolStripMenuItem.Name = "gerenciamentoContasCadastradasToolStripMenuItem";
            gerenciamentoContasCadastradasToolStripMenuItem.Size = new Size(262, 22);
            gerenciamentoContasCadastradasToolStripMenuItem.Text = "Gerenciamento Contas Cadastradas";
            gerenciamentoContasCadastradasToolStripMenuItem.Click += gerenciamentoContasCadastradasToolStripMenuItem_Click;
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
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ButtonHighlight;
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosToolStripMenuItem, importaçãoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(688, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // SelecionarEmpresaButton
            // 
            SelecionarEmpresaButton.Location = new Point(12, 31);
            SelecionarEmpresaButton.Name = "SelecionarEmpresaButton";
            SelecionarEmpresaButton.Size = new Size(29, 23);
            SelecionarEmpresaButton.TabIndex = 11;
            SelecionarEmpresaButton.Text = "...";
            SelecionarEmpresaButton.UseVisualStyleBackColor = true;
            SelecionarEmpresaButton.Click += SelecionarEmpresaButton_Click;
            // 
            // displayEmpresa
            // 
            displayEmpresa.AutoSize = true;
            displayEmpresa.Location = new Point(47, 35);
            displayEmpresa.Name = "displayEmpresa";
            displayEmpresa.Size = new Size(55, 15);
            displayEmpresa.TabIndex = 12;
            displayEmpresa.Text = "Empresa:";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(688, 450);
            Controls.Add(displayEmpresa);
            Controls.Add(SelecionarEmpresaButton);
            Controls.Add(SubstituirButton);
            Controls.Add(progressBar1);
            Controls.Add(ImportarMovimentoCheck);
            Controls.Add(competenciaTextBox);
            Controls.Add(label1);
            Controls.Add(logBox);
            Controls.Add(OpenFileButton);
            Controls.Add(ProcessButton);
            Controls.Add(pathTextBox);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Conferência Conciliação";
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
        private ToolStripMenuItem gerenciamentoContasToolStripMenuItem;
        private CheckBox ImportarMovimentoCheck;
        private ProgressBar progressBar1;
        private CheckBox SubstituirButton;
        private ToolStripMenuItem cadastrosToolStripMenuItem;
        private ToolStripMenuItem gerenciamentoSaldosAnterioresToolStripMenuItem;
        private ToolStripMenuItem importaçãoToolStripMenuItem;
        private ToolStripMenuItem importarSaldosAnterioresToolStripMenuItem;
        private MenuStrip menuStrip1;
        private Button SelecionarEmpresaButton;
        private Label displayEmpresa;
        private ToolStripMenuItem gerenciamentoContasCadastradasToolStripMenuItem;
    }
}
