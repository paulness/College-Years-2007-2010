namespace BankGUI
{
    partial class AccountControl
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
            this.l_UpDownDeposit = new System.Windows.Forms.NumericUpDown();
            this.l_UpDownWithdraw = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupCustomerAccountManagement = new System.Windows.Forms.GroupBox();
            this.l_btnWithdraw = new System.Windows.Forms.Button();
            this.l_btnDeposit = new System.Windows.Forms.Button();
            this.txtAccType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupAccDetails = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtBal = new System.Windows.Forms.TextBox();
            this.txtOverdraft = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.l_UpDownDeposit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.l_UpDownWithdraw)).BeginInit();
            this.groupCustomerAccountManagement.SuspendLayout();
            this.groupAccDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // l_UpDownDeposit
            // 
            this.l_UpDownDeposit.DecimalPlaces = 2;
            this.l_UpDownDeposit.Location = new System.Drawing.Point(15, 45);
            this.l_UpDownDeposit.Maximum = new decimal(new int[] {
            -1863462912,
            46,
            0,
            0});
            this.l_UpDownDeposit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.l_UpDownDeposit.Name = "l_UpDownDeposit";
            this.l_UpDownDeposit.Size = new System.Drawing.Size(183, 21);
            this.l_UpDownDeposit.TabIndex = 2;
            this.l_UpDownDeposit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // l_UpDownWithdraw
            // 
            this.l_UpDownWithdraw.DecimalPlaces = 2;
            this.l_UpDownWithdraw.Location = new System.Drawing.Point(15, 97);
            this.l_UpDownWithdraw.Maximum = new decimal(new int[] {
            -1863462912,
            46,
            0,
            0});
            this.l_UpDownWithdraw.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.l_UpDownWithdraw.Name = "l_UpDownWithdraw";
            this.l_UpDownWithdraw.Size = new System.Drawing.Size(183, 21);
            this.l_UpDownWithdraw.TabIndex = 3;
            this.l_UpDownWithdraw.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Deposit Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Withdraw Amount:";
            // 
            // groupCustomerAccountManagement
            // 
            this.groupCustomerAccountManagement.Controls.Add(this.l_btnWithdraw);
            this.groupCustomerAccountManagement.Controls.Add(this.l_btnDeposit);
            this.groupCustomerAccountManagement.Controls.Add(this.label3);
            this.groupCustomerAccountManagement.Controls.Add(this.label2);
            this.groupCustomerAccountManagement.Controls.Add(this.l_UpDownWithdraw);
            this.groupCustomerAccountManagement.Controls.Add(this.l_UpDownDeposit);
            this.groupCustomerAccountManagement.Location = new System.Drawing.Point(0, 9);
            this.groupCustomerAccountManagement.Name = "groupCustomerAccountManagement";
            this.groupCustomerAccountManagement.Size = new System.Drawing.Size(292, 153);
            this.groupCustomerAccountManagement.TabIndex = 8;
            this.groupCustomerAccountManagement.TabStop = false;
            this.groupCustomerAccountManagement.Text = "Customer Account Management";
            // 
            // l_btnWithdraw
            // 
            this.l_btnWithdraw.Location = new System.Drawing.Point(204, 91);
            this.l_btnWithdraw.Name = "l_btnWithdraw";
            this.l_btnWithdraw.Size = new System.Drawing.Size(75, 30);
            this.l_btnWithdraw.TabIndex = 11;
            this.l_btnWithdraw.Text = "Withdraw";
            this.l_btnWithdraw.UseVisualStyleBackColor = true;
            this.l_btnWithdraw.Click += new System.EventHandler(this.l_btnWithdraw_Click);
            // 
            // l_btnDeposit
            // 
            this.l_btnDeposit.Location = new System.Drawing.Point(204, 42);
            this.l_btnDeposit.Name = "l_btnDeposit";
            this.l_btnDeposit.Size = new System.Drawing.Size(75, 30);
            this.l_btnDeposit.TabIndex = 10;
            this.l_btnDeposit.Text = "Deposit";
            this.l_btnDeposit.UseVisualStyleBackColor = true;
            this.l_btnDeposit.Click += new System.EventHandler(this.l_btnDeposit_Click);
            // 
            // txtAccType
            // 
            this.txtAccType.Location = new System.Drawing.Point(143, 26);
            this.txtAccType.Name = "txtAccType";
            this.txtAccType.ReadOnly = true;
            this.txtAccType.Size = new System.Drawing.Size(163, 21);
            this.txtAccType.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Type of Account:";
            // 
            // groupAccDetails
            // 
            this.groupAccDetails.Controls.Add(this.txtOverdraft);
            this.groupAccDetails.Controls.Add(this.txtBal);
            this.groupAccDetails.Controls.Add(this.txtAddress);
            this.groupAccDetails.Controls.Add(this.txtName);
            this.groupAccDetails.Controls.Add(this.label8);
            this.groupAccDetails.Controls.Add(this.label7);
            this.groupAccDetails.Controls.Add(this.label6);
            this.groupAccDetails.Controls.Add(this.label4);
            this.groupAccDetails.Controls.Add(this.txtAccNo);
            this.groupAccDetails.Controls.Add(this.label1);
            this.groupAccDetails.Controls.Add(this.txtAccType);
            this.groupAccDetails.Controls.Add(this.label5);
            this.groupAccDetails.Location = new System.Drawing.Point(298, 9);
            this.groupAccDetails.Name = "groupAccDetails";
            this.groupAccDetails.Size = new System.Drawing.Size(331, 211);
            this.groupAccDetails.TabIndex = 10;
            this.groupAccDetails.TabStop = false;
            this.groupAccDetails.Text = "Customer Account Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Account Number:";
            // 
            // txtAccNo
            // 
            this.txtAccNo.Location = new System.Drawing.Point(143, 54);
            this.txtAccNo.Name = "txtAccNo";
            this.txtAccNo.ReadOnly = true;
            this.txtAccNo.Size = new System.Drawing.Size(163, 21);
            this.txtAccNo.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Customer Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Customer Address:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Account Balance:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Account Overdraft:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(143, 85);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(163, 21);
            this.txtName.TabIndex = 16;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(143, 116);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(163, 21);
            this.txtAddress.TabIndex = 17;
            // 
            // txtBal
            // 
            this.txtBal.BackColor = System.Drawing.SystemColors.Control;
            this.txtBal.Location = new System.Drawing.Point(143, 147);
            this.txtBal.Name = "txtBal";
            this.txtBal.Size = new System.Drawing.Size(163, 21);
            this.txtBal.TabIndex = 18;
            // 
            // txtOverdraft
            // 
            this.txtOverdraft.Location = new System.Drawing.Point(143, 178);
            this.txtOverdraft.Name = "txtOverdraft";
            this.txtOverdraft.ReadOnly = true;
            this.txtOverdraft.Size = new System.Drawing.Size(163, 21);
            this.txtOverdraft.TabIndex = 19;
            // 
            // AccountControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 224);
            this.Controls.Add(this.groupAccDetails);
            this.Controls.Add(this.groupCustomerAccountManagement);
            this.Font = new System.Drawing.Font("Arial", 7.854546F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AccountControl";
            this.Text = "Account Control Panel";
            ((System.ComponentModel.ISupportInitialize)(this.l_UpDownDeposit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.l_UpDownWithdraw)).EndInit();
            this.groupCustomerAccountManagement.ResumeLayout(false);
            this.groupCustomerAccountManagement.PerformLayout();
            this.groupAccDetails.ResumeLayout(false);
            this.groupAccDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown l_UpDownDeposit;
        private System.Windows.Forms.NumericUpDown l_UpDownWithdraw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupCustomerAccountManagement;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAccType;
        private System.Windows.Forms.Button l_btnWithdraw;
        private System.Windows.Forms.Button l_btnDeposit;
        private System.Windows.Forms.GroupBox groupAccDetails;
        private System.Windows.Forms.TextBox txtAccNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOverdraft;
        private System.Windows.Forms.TextBox txtBal;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}