namespace Conciliacao_Plamev
{
    partial class ImportarMovimentacao
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
            csvPath = new TextBox();
            FindPathButton = new Button();
            ConvertButton = new Button();
            gerarModeloLabel = new LinkLabel();
            SuspendLayout();
            // 
            // csvPath
            // 
            csvPath.Location = new Point(12, 12);
            csvPath.Name = "csvPath";
            csvPath.Size = new Size(255, 23);
            csvPath.TabIndex = 0;
            // 
            // FindPathButton
            // 
            FindPathButton.Location = new Point(273, 12);
            FindPathButton.Name = "FindPathButton";
            FindPathButton.Size = new Size(25, 23);
            FindPathButton.TabIndex = 1;
            FindPathButton.Text = "...";
            FindPathButton.UseVisualStyleBackColor = true;
            FindPathButton.Click += FindPathButton_Click;
            // 
            // ConvertButton
            // 
            ConvertButton.Location = new Point(304, 12);
            ConvertButton.Name = "ConvertButton";
            ConvertButton.Size = new Size(95, 23);
            ConvertButton.TabIndex = 2;
            ConvertButton.Text = "Converter";
            ConvertButton.UseVisualStyleBackColor = true;
            ConvertButton.Click += ConvertButton_Click;
            // 
            // gerarModeloLabel
            // 
            gerarModeloLabel.AutoSize = true;
            gerarModeloLabel.Location = new Point(12, 49);
            gerarModeloLabel.Name = "gerarModeloLabel";
            gerarModeloLabel.Size = new Size(257, 15);
            gerarModeloLabel.TabIndex = 3;
            gerarModeloLabel.TabStop = true;
            gerarModeloLabel.Text = "Se não possuir o modelo, clique aqui para gerar";
            gerarModeloLabel.LinkClicked += gerarModeloLabel_LinkClicked;
            // 
            // ImportarMovimentacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(409, 73);
            Controls.Add(gerarModeloLabel);
            Controls.Add(ConvertButton);
            Controls.Add(FindPathButton);
            Controls.Add(csvPath);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ImportarMovimentacao";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ImportarMovimentacao";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox csvPath;
        private Button FindPathButton;
        private Button ConvertButton;
        private LinkLabel gerarModeloLabel;
    }
}