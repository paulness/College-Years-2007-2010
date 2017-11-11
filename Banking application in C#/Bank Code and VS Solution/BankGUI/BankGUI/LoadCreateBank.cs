using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankGUI
{
    public partial class frmLoadCreateBank : Form
    {
        public frmLoadCreateBank()
        {
            InitializeComponent();
        }
        #region Call Bank Static Load Method
        private void btnLoadBank_Click(object sender, EventArgs e)
        {
            try
            {
                AccountBankManagement.Bank newBank = AccountBankManagement.Bank.Load(txtBankFilePath.Text);
                BankControl OpenBank = new BankControl(newBank);
                OpenBank.ShowDialog();
                this.Close();
            }
            catch (Exception FileOpenProblem)
            {
                MessageBox.Show(FileOpenProblem.Message, "Error: Loading Bank From File", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Call Bank Constructor
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                AccountBankManagement.Bank newBank = new AccountBankManagement.Bank(txtBankName.Text, (int)upDownMaxNoAccount.Value);
                BankControl OpenBank = new BankControl(newBank);
                OpenBank.ShowDialog();
                this.Close();
            }
            catch (Exception CreateBankProb)
            {
                MessageBox.Show(CreateBankProb.Message, "Error: Creating Bank", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnBrowseBankFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtBankFilePath.Text = openFileDialog1.FileName.ToString();
        }
    }
}