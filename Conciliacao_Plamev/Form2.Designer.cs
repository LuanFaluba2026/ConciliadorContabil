namespace Conciliacao_Plamev
{
    partial class Form2
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
            fixo1 = new Label();
            textBox1 = new TextBox();
            consultaFornecedor = new Label();
            consultaSaldo = new Label();
            dataGridView1 = new DataGridView();
            SalvarButton = new Button();
            EditarButton = new Button();
            CancelarButton = new Button();
            mostrarEncerrados = new CheckBox();
            BotaoAdicionar = new Button();
            BotaoExcluir = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // fixo1
            // 
            fixo1.AutoSize = true;
            fixo1.Location = new Point(12, 16);
            fixo1.Name = "fixo1";
            fixo1.Size = new Size(52, 15);
            fixo1.TabIndex = 0;
            fixo1.Text = "Código: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.Leave += textBox1_Leave;
            // 
            // consultaFornecedor
            // 
            consultaFornecedor.AutoSize = true;
            consultaFornecedor.Location = new Point(12, 45);
            consultaFornecedor.Name = "consultaFornecedor";
            consultaFornecedor.Size = new Size(70, 15);
            consultaFornecedor.TabIndex = 2;
            consultaFornecedor.Text = "Fornecedor:";
            // 
            // consultaSaldo
            // 
            consultaSaldo.AutoSize = true;
            consultaSaldo.Dock = DockStyle.Bottom;
            consultaSaldo.Location = new Point(0, 494);
            consultaSaldo.Name = "consultaSaldo";
            consultaSaldo.Padding = new Padding(10, 0, 0, 10);
            consultaSaldo.RightToLeft = RightToLeft.No;
            consultaSaldo.Size = new Size(143, 25);
            consultaSaldo.TabIndex = 3;
            consultaSaldo.Text = "Saldo em aberto: R$0,00";
            consultaSaldo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = SystemColors.ControlLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(12, 117);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1213, 362);
            dataGridView1.TabIndex = 4;
            // 
            // SalvarButton
            // 
            SalvarButton.Enabled = false;
            SalvarButton.Location = new Point(1128, 41);
            SalvarButton.Name = "SalvarButton";
            SalvarButton.Size = new Size(97, 23);
            SalvarButton.TabIndex = 5;
            SalvarButton.Text = "Salvar";
            SalvarButton.UseVisualStyleBackColor = true;
            SalvarButton.Click += SalvarButton_Click;
            // 
            // EditarButton
            // 
            EditarButton.Location = new Point(1128, 12);
            EditarButton.Name = "EditarButton";
            EditarButton.Size = new Size(97, 23);
            EditarButton.TabIndex = 6;
            EditarButton.Text = "Editar";
            EditarButton.UseVisualStyleBackColor = true;
            EditarButton.Click += EditarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Location = new Point(1128, 70);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(97, 23);
            CancelarButton.TabIndex = 7;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // mostrarEncerrados
            // 
            mostrarEncerrados.AutoSize = true;
            mostrarEncerrados.Location = new Point(12, 96);
            mostrarEncerrados.Name = "mostrarEncerrados";
            mostrarEncerrados.Size = new Size(198, 19);
            mostrarEncerrados.TabIndex = 8;
            mostrarEncerrados.Text = "Mostrar movimentos encerrados";
            mostrarEncerrados.UseVisualStyleBackColor = true;
            mostrarEncerrados.CheckedChanged += mostrarEncerrados_CheckedChanged;
            // 
            // BotaoAdicionar
            // 
            BotaoAdicionar.Enabled = false;
            BotaoAdicionar.Font = new Font("Book Antiqua", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoAdicionar.Location = new Point(1159, 485);
            BotaoAdicionar.Name = "BotaoAdicionar";
            BotaoAdicionar.Size = new Size(30, 27);
            BotaoAdicionar.TabIndex = 9;
            BotaoAdicionar.Text = "+";
            BotaoAdicionar.TextAlign = ContentAlignment.TopCenter;
            BotaoAdicionar.UseVisualStyleBackColor = true;
            // 
            // BotaoExcluir
            // 
            BotaoExcluir.Enabled = false;
            BotaoExcluir.Font = new Font("Book Antiqua", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BotaoExcluir.Location = new Point(1195, 485);
            BotaoExcluir.Name = "BotaoExcluir";
            BotaoExcluir.Size = new Size(30, 27);
            BotaoExcluir.TabIndex = 10;
            BotaoExcluir.Text = "-";
            BotaoExcluir.TextAlign = ContentAlignment.TopCenter;
            BotaoExcluir.UseVisualStyleBackColor = true;
            BotaoExcluir.Click += BotaoExcluir_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1238, 519);
            Controls.Add(BotaoExcluir);
            Controls.Add(BotaoAdicionar);
            Controls.Add(mostrarEncerrados);
            Controls.Add(CancelarButton);
            Controls.Add(EditarButton);
            Controls.Add(SalvarButton);
            Controls.Add(dataGridView1);
            Controls.Add(consultaSaldo);
            Controls.Add(consultaFornecedor);
            Controls.Add(textBox1);
            Controls.Add(fixo1);
            MaximizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Saldos Anteriores";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label fixo1;
        private TextBox textBox1;
        private Label consultaFornecedor;
        private Label consultaSaldo;
        private DataGridView dataGridView1;
        private Button SalvarButton;
        private Button EditarButton;
        private Button CancelarButton;
        private CheckBox mostrarEncerrados;
        private Button BotaoAdicionar;
        private Button BotaoExcluir;
    }
}