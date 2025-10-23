namespace Conciliacao_Plamev
{
    partial class CaixaAdicionarConta
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
            label2 = new Label();
            label3 = new Label();
            codigoTB = new TextBox();
            analiticoTB = new TextBox();
            nomeTB = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 20);
            label1.Name = "label1";
            label1.Size = new Size(92, 15);
            label1.TabIndex = 0;
            label1.Text = "Codigo Conta: *";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 48);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 1;
            label2.Text = "Conta Analítica:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(5, 77);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 2;
            label3.Text = "Nome Fornecedor: *";
            // 
            // codigoTB
            // 
            codigoTB.Location = new Point(125, 12);
            codigoTB.Name = "codigoTB";
            codigoTB.Size = new Size(93, 23);
            codigoTB.TabIndex = 3;
            // 
            // analiticoTB
            // 
            analiticoTB.Location = new Point(125, 40);
            analiticoTB.Name = "analiticoTB";
            analiticoTB.Size = new Size(137, 23);
            analiticoTB.TabIndex = 4;
            // 
            // nomeTB
            // 
            nomeTB.Location = new Point(125, 69);
            nomeTB.Name = "nomeTB";
            nomeTB.Size = new Size(252, 23);
            nomeTB.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(389, 11);
            button1.Name = "button1";
            button1.Size = new Size(96, 23);
            button1.TabIndex = 6;
            button1.Text = "Salvar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(389, 40);
            button2.Name = "button2";
            button2.Size = new Size(96, 23);
            button2.TabIndex = 7;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CaixaAdicionarConta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 108);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(nomeTB);
            Controls.Add(analiticoTB);
            Controls.Add(codigoTB);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CaixaAdicionarConta";
            Text = "CaixaAdicionarConta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox codigoTB;
        private TextBox analiticoTB;
        private TextBox nomeTB;
        private Button button1;
        private Button button2;
    }
}