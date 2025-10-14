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
            ListarContas = new Button();
            ListarMovimentacao = new Button();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pathTextBox
            // 
            pathTextBox.Location = new Point(12, 13);
            pathTextBox.Name = "pathTextBox";
            pathTextBox.Size = new Size(326, 23);
            pathTextBox.TabIndex = 0;
            // 
            // ProcessButton
            // 
            ProcessButton.Location = new Point(397, 5);
            ProcessButton.Name = "ProcessButton";
            ProcessButton.Size = new Size(109, 37);
            ProcessButton.TabIndex = 1;
            ProcessButton.Text = "Processar";
            ProcessButton.UseVisualStyleBackColor = true;
            ProcessButton.Click += ProcessButton_Click;
            // 
            // OpenFileButton
            // 
            OpenFileButton.Location = new Point(344, 12);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(27, 24);
            OpenFileButton.TabIndex = 2;
            OpenFileButton.Text = "...";
            OpenFileButton.UseVisualStyleBackColor = true;
            // 
            // logBox
            // 
            logBox.Location = new Point(19, 57);
            logBox.Multiline = true;
            logBox.Name = "logBox";
            logBox.ReadOnly = true;
            logBox.Size = new Size(487, 146);
            logBox.TabIndex = 3;
            // 
            // ListarContas
            // 
            ListarContas.Location = new Point(383, 209);
            ListarContas.Name = "ListarContas";
            ListarContas.Size = new Size(123, 29);
            ListarContas.TabIndex = 4;
            ListarContas.Text = "Listar Contas";
            ListarContas.UseVisualStyleBackColor = true;
            ListarContas.Click += ListarContas_Click;
            // 
            // ListarMovimentacao
            // 
            ListarMovimentacao.Location = new Point(219, 209);
            ListarMovimentacao.Name = "ListarMovimentacao";
            ListarMovimentacao.Size = new Size(158, 29);
            ListarMovimentacao.TabIndex = 5;
            ListarMovimentacao.Text = "Listar Movimentaçoes";
            ListarMovimentacao.UseVisualStyleBackColor = true;
            ListarMovimentacao.Click += ListarMovimentacao_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 250);
            Controls.Add(ListarMovimentacao);
            Controls.Add(ListarContas);
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
        private Button ListarContas;
        private Button ListarMovimentacao;
    }
}
