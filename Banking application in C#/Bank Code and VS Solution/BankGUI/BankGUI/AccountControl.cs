using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BankGUI
{
    public partial class AccountControl : Form
    {
        #region References + Data Members
        private AccountBankManagement.IAccount m_ActiveAccount;
        #endregion
        #region Constructor for this form
        public AccountControl(AccountBankManagement.IAccount pActiveAccount)
        {
            InitializeComponent();
            ///m_ActiveAccount reference now points to the same instance as the parameter reference
            ///this is useful as we can now access the object
            ///outside of this constructor (the scope of pActiveAccount is only visible in this constructor block)
            m_ActiveAccount = pActiveAccount;
            //Set title of form to following
            this.Text = "Bank Account: " + m_ActiveAccount.GetAccountNumber() + " Customer Control Center";
            ///call UpdateAccountInfoBox(); method
            UpdateAccountInfoBox();
        }
        #endregion

        private void UpdateAccountInfoBox()
        {
            txtAccType.Text = m_ActiveAccount.GetType().Name;
            txtAccNo.Text = m_ActiveAccount.GetAccountNumber().ToString();
            txtName.Text = m_ActiveAccount.GetName().ToString();
            txtAddress.Text = m_ActiveAccount.GetAddress().ToString();
            if (m_ActiveAccount.GetBalance() < 0)
            {
                txtBal.ForeColor = Color.Red;
            }
            txtBal.Text = "£" + m_ActiveAccount.GetBalance().ToString();
            txtOverdraft.Text = "£" + m_ActiveAccount.GetOverdraft().ToString();
        }

        private void l_btnDeposit_Click(object sender, EventArgs e)
        {
            m_ActiveAccount.PayIn(l_UpDownDeposit.Value);
            UpdateAccountInfoBox();
        }

        private void l_btnWithdraw_Click(object sender, EventArgs e)
        {
            switch (m_ActiveAccount.Withdraw(l_UpDownWithdraw.Value))
            {
                case 0: break; ///success so dont need to show anything break;
                case 1: MessageBox.Show("You have insufficient funds in your account!", "Error: Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2: MessageBox.Show("The amount you wish to withdraw cannot be negative", "Error: Trying to withdraw negative funds", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3: MessageBox.Show("You have a BabyAccount you are limited to withdrawals of £5.00 at a single time!", "Error: Exceeding BabyAccount Withdrawal Limit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            UpdateAccountInfoBox();
        }
    }
}