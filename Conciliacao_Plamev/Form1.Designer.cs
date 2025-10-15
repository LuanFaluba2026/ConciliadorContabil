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
            GerenciarSaldos = new Button();
            label1 = new Label();
            competenciaTextBox = new TextBox();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pathTextBox
            // 
            pathTextBox.Location = new Point(12, 41);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new Size(326, 23);
            pathTextBox.TabIndex = 0;
            // 
            // ProcessButton
            // 
            ProcessButton.Location = new Point(397, 33);
            ProcessButton.Name = "ProcessButton";
            ProcessButton.Size = new Size(109, 37);
            ProcessButton.TabIndex = 1;
            ProcessButton.Text = "Processar";
            ProcessButton.UseVisualStyleBackColor = true;
            ProcessButton.Click += ProcessButton_Click;
            // 
            // OpenFileButton
            // 
            OpenFileButton.Location = new Point(344, 40);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(27, 24);
            OpenFileButton.TabIndex = 2;
            OpenFileButton.Text = "...";
            OpenFileButton.UseVisualStyleBackColor = true;
            // 
            // logBox
            // 
            logBox.Location = new Point(19, 85);
            logBox.Multiline = true;
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.Size = new Size(487, 146);
            logBox.TabIndex = 3;
            // 
            // GerenciarSaldos
            // 
            GerenciarSaldos.Location = new Point(383, 237);
            GerenciarSaldos.Name = "GerenciarSaldos";
            GerenciarSaldos.Size = new Size(123, 29);
            GerenciarSaldos.TabIndex = 4;
            GerenciarSaldos.Text = "Gerenciar Saldos";
            GerenciarSaldos.UseVisualStyleBackColor = true;
            GerenciarSaldos.Click += GerenciarSaldos_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 5;
            label1.Text = "Competência:";
            // 
            // competenciaTextBox
            // 
            competenciaTextBox.Location = new Point(99, 11);
            competenciaTextBox.Name = "competenciaTextBox";
            competenciaTextBox.Size = new Size(69, 23);
            competenciaTextBox.TabIndex = 6;
            competenciaTextBox.TextChanged += competenciaTextBox_TextChanged;
            competenciaTextBox.Leave += OnCompetenciaChange;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 283);
            Controls.Add(competenciaTextBox);
            Controls.Add(label1);
            Controls.Add(GerenciarSaldos);
            Controls.Add(logBox);
            Controls.Add(OpenFileButton);
            Controls.Add(ProcessButton);
            Controls.Add(pathTextBox);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Conciliação Plamev";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TextBox pathTextBox;
        private Button ProcessButton;
        private Button OpenFileButton;
        private TextBox logBox;
        private Button GerenciarSaldos;
        private Label label1;
        private TextBox competenciaTextBox;
    }
}
