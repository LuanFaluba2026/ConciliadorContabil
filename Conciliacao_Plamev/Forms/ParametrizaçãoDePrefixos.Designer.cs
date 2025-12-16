namespace Conciliacao_Plamev.Forms
{
    partial class ParametrizaçãoDePrefixos
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
            prefixosGV = new DataGridView();
            HelpButton = new Button();
            addButton = new Button();
            removeButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)prefixosGV).BeginInit();
            SuspendLayout();
            // 
            // prefixosGV
            // 
            prefixosGV.AllowUserToAddRows = false;
            prefixosGV.AllowUserToDeleteRows = false;
            prefixosGV.AllowUserToResizeColumns = false;
            prefixosGV.AllowUserToResizeRows = false;
            prefixosGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            prefixosGV.Location = new Point(11, 41);
            prefixosGV.MultiSelect = false;
            prefixosGV.Name = "prefixosGV";
            prefixosGV.ReadOnly = true;
            prefixosGV.RowHeadersVisible = false;
            prefixosGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            prefixosGV.Size = new Size(200, 267);
            prefixosGV.TabIndex = 0;
            // 
            // HelpButton
            // 
            HelpButton.Location = new Point(186, 314);
            HelpButton.Name = "HelpButton";
            HelpButton.Size = new Size(24, 23);
            HelpButton.TabIndex = 1;
            HelpButton.Text = "?";
            HelpButton.UseVisualStyleBackColor = true;
            HelpButton.MouseEnter += HelpButton_MouseEnter;
            // 
            // addButton
            // 
            addButton.Location = new Point(158, 12);
            addButton.Name = "addButton";
            addButton.Size = new Size(22, 23);
            addButton.TabIndex = 2;
            addButton.Text = "+";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(186, 12);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(22, 23);
            removeButton.TabIndex = 3;
            removeButton.Text = "-";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 16);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 4;
            label1.Text = "Prefixos definidos:";
            // 
            // ParametrizaçãoDePrefixos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(223, 345);
            Controls.Add(label1);
            Controls.Add(removeButton);
            Controls.Add(addButton);
            Controls.Add(HelpButton);
            Controls.Add(prefixosGV);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ParametrizaçãoDePrefixos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Parametrização Prefixos";
            ((System.ComponentModel.ISupportInitialize)prefixosGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView prefixosGV;
        private Button HelpButton;
        private Button addButton;
        private Button removeButton;
        private Label label1;
    }
}