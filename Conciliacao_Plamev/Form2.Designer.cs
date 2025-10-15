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
            components = new System.ComponentModel.Container();
            fixo1 = new Label();
            textBox1 = new TextBox();
            consultaFornecedor = new Label();
            consultaSaldo = new Label();
            dataGridView1 = new DataGridView();
            dataMovDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notaRefDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            historicoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            creditoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            movimentosAbertosBindingSource = new BindingSource(components);
            SalvarButton = new Button();
            EditarButton = new Button();
            CancelarButton = new Button();
            bindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movimentosAbertosBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // fixo1
            // 
            fixo1.AutoSize = true;
            fixo1.Location = new Point(12, 12);
            fixo1.Name = "fixo1";
            fixo1.Size = new Size(52, 15);
            fixo1.TabIndex = 0;
            fixo1.Text = "Código: ";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(70, 9);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            textBox1.Leave += textBox1_TextChanged;
            // 
            // consultaFornecedor
            // 
            consultaFornecedor.AutoSize = true;
            consultaFornecedor.Location = new Point(192, 12);
            consultaFornecedor.Name = "consultaFornecedor";
            consultaFornecedor.Size = new Size(70, 15);
            consultaFornecedor.TabIndex = 2;
            consultaFornecedor.Text = "Fornecedor:";
            // 
            // consultaSaldo
            // 
            consultaSaldo.AutoSize = true;
            consultaSaldo.Location = new Point(558, 52);
            consultaSaldo.Name = "consultaSaldo";
            consultaSaldo.Size = new Size(96, 15);
            consultaSaldo.TabIndex = 3;
            consultaSaldo.Text = "Saldo em aberto:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = SystemColors.ControlLight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { dataMovDataGridViewTextBoxColumn, notaRefDataGridViewTextBoxColumn, historicoDataGridViewTextBoxColumn, creditoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = movimentosAbertosBindingSource;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(12, 70);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(744, 255);
            dataGridView1.TabIndex = 4;
            // 
            // dataMovDataGridViewTextBoxColumn
            // 
            dataMovDataGridViewTextBoxColumn.DataPropertyName = "dataMov";
            dataMovDataGridViewTextBoxColumn.HeaderText = "dataMov";
            dataMovDataGridViewTextBoxColumn.Name = "dataMovDataGridViewTextBoxColumn";
            dataMovDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // notaRefDataGridViewTextBoxColumn
            // 
            notaRefDataGridViewTextBoxColumn.DataPropertyName = "notaRef";
            notaRefDataGridViewTextBoxColumn.HeaderText = "notaRef";
            notaRefDataGridViewTextBoxColumn.Name = "notaRefDataGridViewTextBoxColumn";
            notaRefDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // historicoDataGridViewTextBoxColumn
            // 
            historicoDataGridViewTextBoxColumn.DataPropertyName = "historico";
            historicoDataGridViewTextBoxColumn.HeaderText = "historico";
            historicoDataGridViewTextBoxColumn.Name = "historicoDataGridViewTextBoxColumn";
            historicoDataGridViewTextBoxColumn.ReadOnly = true;
            historicoDataGridViewTextBoxColumn.Width = 400;
            // 
            // creditoDataGridViewTextBoxColumn
            // 
            creditoDataGridViewTextBoxColumn.DataPropertyName = "credito";
            creditoDataGridViewTextBoxColumn.HeaderText = "credito";
            creditoDataGridViewTextBoxColumn.Name = "creditoDataGridViewTextBoxColumn";
            creditoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // movimentosAbertosBindingSource
            // 
            movimentosAbertosBindingSource.DataSource = typeof(MovimentosAbertos);
            // 
            // SalvarButton
            // 
            SalvarButton.Enabled = false;
            SalvarButton.Location = new Point(762, 99);
            SalvarButton.Name = "SalvarButton";
            SalvarButton.Size = new Size(97, 23);
            SalvarButton.TabIndex = 5;
            SalvarButton.Text = "Salvar";
            SalvarButton.UseVisualStyleBackColor = true;
            SalvarButton.Click += SalvarButton_Click;
            // 
            // EditarButton
            // 
            EditarButton.Location = new Point(762, 70);
            EditarButton.Name = "EditarButton";
            EditarButton.Size = new Size(97, 23);
            EditarButton.TabIndex = 6;
            EditarButton.Text = "Editar";
            EditarButton.UseVisualStyleBackColor = true;
            EditarButton.Click += EditarButton_Click;
            // 
            // CancelarButton
            // 
            CancelarButton.Enabled = false;
            CancelarButton.Location = new Point(762, 128);
            CancelarButton.Name = "CancelarButton";
            CancelarButton.Size = new Size(97, 23);
            CancelarButton.TabIndex = 7;
            CancelarButton.Text = "Cancelar";
            CancelarButton.UseVisualStyleBackColor = true;
            CancelarButton.Click += CancelarButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 347);
            Controls.Add(CancelarButton);
            Controls.Add(EditarButton);
            Controls.Add(SalvarButton);
            Controls.Add(dataGridView1);
            Controls.Add(consultaSaldo);
            Controls.Add(consultaFornecedor);
            Controls.Add(textBox1);
            Controls.Add(fixo1);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)movimentosAbertosBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label fixo1;
        private TextBox textBox1;
        private Label consultaFornecedor;
        private Label consultaSaldo;
        private DataGridView dataGridView1;
        private BindingSource movimentosAbertosBindingSource;
        private Button SalvarButton;
        private Button EditarButton;
        private Button CancelarButton;
        private DataGridViewTextBoxColumn dataMovDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notaRefDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn historicoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn creditoDataGridViewTextBoxColumn;
        private BindingSource bindingSource1;
    }
}