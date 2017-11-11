namespace BankGUI
{
    partial class frmLoadCreateBank
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
            this.btnLoadBank = new System.Windows.Forms.Button();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.upDownMaxNoAccount = new System.Windows.Forms.NumericUpDown();
            this.groupCreate = new System.Windows.Forms.GroupBox();
            this.txtBankFilePath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseBankFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.upDownMaxNoAccount)).BeginInit();
            this.groupCreate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadBank
            // 
            this.btnLoadBank.Location = new System.Drawing.Point(11, 86);
            this.btnLoadBank.Name = "btnLoadBank";
            this.btnLoadBank.Size = new System.Drawing.Size(142, 37);
            this.btnLoadBank.TabIndex = 0;
            this.btnLoadBank.Text = "Load Existing Bank";
            this.btnLoadBank.UseVisualStyleBackColor = true;
            this.btnLoadBank.Click += new System.EventHandler(this.btnLoadBank_Click);
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(227, 22);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(259, 21);
            this.txtBankName.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(11, 95);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(142, 37);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "Create Bank Now";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter the name for your new Bank:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Enter the max no of accounts for the Bank to store:";
            // 
            // upDownMaxNoAccount
            // 
            this.upDownMaxNoAccount.Location = new System.Drawing.Point(323, 58);
            this.upDownMaxNoAccount.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.upDownMaxNoAccount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.upDownMaxNoAccount.Name = "upDownMaxNoAccount";
            this.upDownMaxNoAccount.Size = new System.Drawing.Size(163, 21);
            this.upDownMaxNoAccount.TabIndex = 7;
            this.upDownMaxNoAccount.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupCreate
            // 
            this.groupCreate.Controls.Add(this.upDownMaxNoAccount);
            this.groupCreate.Controls.Add(this.label2);
            this.groupCreate.Controls.Add(this.label1);
            this.groupCreate.Controls.Add(this.btnCreate);
            this.groupCreate.Controls.Add(this.txtBankName);
            this.groupCreate.Location = new System.Drawing.Point(1, 4);
            this.groupCreate.Name = "groupCreate";
            this.groupCreate.Size = new System.Drawing.Size(534, 138);
            this.groupCreate.TabIndex = 8;
            this.groupCreate.TabStop = false;
            this.groupCreate.Text = "Create a new Bank";
            // 
            // txtBankFilePath
            // 
            this.txtBankFilePath.Location = new System.Drawing.Point(11, 59);
            this.txtBankFilePath.Name = "txtBankFilePath";
            this.txtBankFilePath.Size = new System.Drawing.Size(421, 21);
            this.txtBankFilePath.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "File Path";
            // 
            // btnBrowseBankFile
            // 
            this.btnBrowseBankFile.Location = new System.Drawing.Point(438, 57);
            this.btnBrowseBankFile.Name = "btnBrowseBankFile";
            this.btnBrowseBankFile.Size = new System.Drawing.Size(90, 23);
            this.btnBrowseBankFile.TabIndex = 11;
            this.btnBrowseBankFile.Text = "Browse";
            this.btnBrowseBankFile.UseVisualStyleBackColor = true;
            this.btnBrowseBankFile.Click += new System.EventHandler(this.btnBrowseBankFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.txt";
            this.openFileDialog1.FileName = "openFileDialogBank";
            this.openFileDialog1.Filter = "\"Bank Text Files|*.txt|All Files|*.*\"";
            this.openFileDialog1.InitialDirectory = "AccountBankManagement\\bin\\Debug";
            this.openFileDialog1.Title = "Open an Existing Bank From File";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowseBankFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtBankFilePath);
            this.groupBox1.Controls.Add(this.btnLoadBank);
            this.groupBox1.Location = new System.Drawing.Point(1, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 129);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Existing Bank";
            // 
            // frmLoadCreateBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 289);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupCreate);
            this.Font = new System.Drawing.Font("Arial", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLoadCreateBank";
            this.Text = "Load an Existing Bank or Create a New One";
            ((System.ComponentModel.ISupportInitialize)(this.upDownMaxNoAccount)).EndInit();
            this.groupCreate.ResumeLayout(false);
            this.groupCreate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadBank;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown upDownMaxNoAccount;
        private System.Windows.Forms.GroupBox groupCreate;
        private System.Windows.Forms.TextBox txtBankFilePath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseBankFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

