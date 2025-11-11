namespace Conciliacao_Plamev
{
    partial class AddBanco
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
            nomeEmpresaTB = new TextBox();
            clienteTB = new CheckBox();
            fornecedorTB = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome da Empresa:";
            // 
            // nomeEmpresaTB
            // 
            nomeEmpresaTB.Location = new Point(12, 27);
            nomeEmpresaTB.Name = "nomeEmpresaTB";
            nomeEmpresaTB.Size = new Size(230, 23);
            nomeEmpresaTB.TabIndex = 1;
            // 
            // clienteTB
            // 
            clienteTB.AutoSize = true;
            clienteTB.Location = new Point(12, 56);
            clienteTB.Name = "clienteTB";
            clienteTB.Size = new Size(144, 19);
            clienteTB.TabIndex = 2;
            clienteTB.Text = "Conciliação de Cliente";
            clienteTB.UseVisualStyleBackColor = true;
            clienteTB.CheckedChanged += clienteTB_CheckedChanged;
            // 
            // fornecedorTB
            // 
            fornecedorTB.AutoSize = true;
            fornecedorTB.Location = new Point(12, 81);
            fornecedorTB.Name = "fornecedorTB";
            fornecedorTB.Size = new Size(167, 19);
            fornecedorTB.TabIndex = 3;
            fornecedorTB.Text = "Conciliação de Fornecedor";
            fornecedorTB.UseVisualStyleBackColor = true;
            fornecedorTB.CheckedChanged += fornecedorTB_CheckedChanged;
            // 
            // button1
            // 
            button1.Location = new Point(12, 106);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(93, 106);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            // 
            // AddBanco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 140);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(fornecedorTB);
            Controls.Add(clienteTB);
            Controls.Add(nomeEmpresaTB);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddBanco";
            StartPosition = FormStartPosition.Manual;
            Text = "Adicionar Banco";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox nomeEmpresaTB;
        private CheckBox clienteTB;
        private CheckBox fornecedorTB;
        private Button button1;
        private Button button2;
    }
}