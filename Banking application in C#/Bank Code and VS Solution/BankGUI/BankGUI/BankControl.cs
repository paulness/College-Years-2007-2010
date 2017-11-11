using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AccountBankManagement; //I want to use things from this namespace

namespace BankGUI
{
    public partial class BankControl : Form
    {
        //Create a reference that CAN refer to instances of the Bank Class
        //We do this so we can refer to the same instance of the Bank class throughout all the forms
        private Bank m_CurrentBank;
        private IAccount m_ActiveAccount;
        #region Constructor to construct this form
        //Constructor that takes in a reference to the Bank class as a parameter
        public BankControl(Bank pActiveBank)
        {
            //simply sets up the form
            InitializeComponent();
            ///makes the m_CurrentBank reference refer to the same location
            ///as the reference pActiveBank which was passed into this constructor
            m_CurrentBank = pActiveBank;
            ///sets the form title to the value returned from the GetBankName()
            ///which is found by following m_CurrentBank to its Bank instance
            this.Text = m_CurrentBank.GetBankName() + " Control Center";
            ///adds the name of the bank to from label on warning letters
            lblFrom.Text += m_CurrentBank.GetBankName();
            ComboRetrieveEnumDataSource();
            ///displays the next Account No to be assigned to the user
            ShowNextAccountNo();
            //displays total num of accounts in add acount tab
            ShowNoOfAccounts();
        }
        #endregion
        #region Button event call methods etc
        private void btnCallWarnLett_Click(object sender, EventArgs e)
        {
            CallWarnLetter();
        }
        private void picBoxSave_Click(object sender, EventArgs e)
        {
            CallSaveBank();
        }
        private void btnShowIrate_Click(object sender, EventArgs e)
        {
            ShowCurrentIrate();
        }
        private void btnModIrate_Click(object sender, EventArgs e)
        {
            SetIrate();
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            CallAddAccount();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetUserInputForTab1();
        }
        private void btnDelAcc_Click(object sender, EventArgs e)
        {
            DelAccount();
            ShowNoOfAccounts();
        }
        private void btnModOverdraft_Click(object sender, EventArgs e)
        {
            BankModOverdraft();
        }
        private void btnFillListAllAccounts_Click(object sender, EventArgs e)
        {
            ShowNoOfAccounts();
            FillListBoxAllAccounts();
        }
        private void btnPayInInterest_Click(object sender, EventArgs e)
        {
            PayInterestOut();
        }
        private void btnAccessFoundAccount_Click(object sender, EventArgs e)
        {
            AccessCustomerAccount();
        }
        private void btnFindAccNo_Click(object sender, EventArgs e)
        {
            CallFindAccNum();
        }
        private void btnLoadAccFindName_Click(object sender, EventArgs e)
        {
            CallFindName();
        }
        private void btnShowOLimit_Click(object sender, EventArgs e)
        {
            ShowCurrentOLimit();
        }
        private void btnUpdateOLimit_Click(object sender, EventArgs e)
        {
            SetOverdraftLimit();
            ShowCurrentOLimit();
        }
        #endregion

        #region Call Set/Get Interest Rate
        private void SetIrate()
        {
            if (!m_CurrentBank.SetInterestRate(upDownIrate.Value, (Bank.AccountSelect)comboAccSelcIrate.SelectedItem))
            {
                MessageBox.Show("BabyAccounts are designed to not have interest rates at: " + m_CurrentBank.GetBankName() + ". We firmly believe Babys should not have financial matters on their mind.", "Error: BabyAccount cannot have an interest rate!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ShowCurrentIrate();
        }
        private void ShowCurrentIrate()
        {
            txtCurrentIrate.Text = m_CurrentBank.GetInterestRate((Bank.AccountSelect)comboAccSelcIrate.SelectedItem).ToString();
        }
        #endregion
        #region Call Add New Account
        private void CallAddAccount()
        {
            try
            {
                if (((Bank.AccountSelect)comboAccountType.SelectedValue == Bank.AccountSelect.BabyAccount) && (updownOverdraft.Value > 0))
                {
                    MessageBox.Show("BabyAccount have NO overdraft functionality any value you may have typed has now been set back to zero!", "Error: BabyAccounts Overdraft Restriction", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                ///follows m_CurrentBank reference to the Bank instance then
                ///calls the AddAccount method in Bank with the following parameters
                ///the combobox selected value must be cast back to the (AccountBankManagement.Bank.AccountSelect) type
                m_CurrentBank.AddAccount((AccountBankManagement.Bank.AccountSelect)comboAccountType.SelectedValue, txtAccName.Text, txtAddress.Text, updownBalance.Value, updownOverdraft.Value);
                MessageBox.Show("Account Successfully Created", "Feedback: Account Creation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ///calls the reset method to reset all user input boxes etc
                ///only after the account has been added successfully
                ResetUserInputForTab1();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error: Creating Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ///call this method to show the number of accounts since it
            ///has changed since we added an account
            ShowNoOfAccounts();
            ///call the method to show the next account number to be assigned
            ShowNextAccountNo();
        }
        #endregion
        #region Call Delete an Account
        private void DelAccount()
        {
            if (m_CurrentBank.DelAccount(txtDelAcc.Text)) //if this method returned true
            {
                MessageBox.Show("Account Successfully Deleted", "Feedback: Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The account number you entered either is incorrect or you have already deleted this account, No Account exists in the Bank with that account number!", "Error: No Account with that Account number exists to delete!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Call Set/Get Overdraft Limit
        private void ShowCurrentOLimit()
        {
            textOLimitNow.Text = m_CurrentBank.GetOverdraftLimit((Bank.AccountSelect)comboAccountSelcOverdraft.SelectedItem).ToString();
        }
        private void SetOverdraftLimit()
        {
            ///call the set overdraft method in the bank class
            ///and see what byte value was returned afterwards
            switch (m_CurrentBank.SetOverdraftLimit((int)upDownSetOverdraftLimit.Value, (Bank.AccountSelect)comboAccountSelcOverdraft.SelectedItem))
            {
                ///success case 0
                case 0: MessageBox.Show("Overdraft limit modification success!", "Feedback: Overdraft Limit Changes Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1: MessageBox.Show("You cannot set a negative overdraft limit", "Error: Negative Overdraft Limits Disallowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2: MessageBox.Show("The overdraft limit you wish for this type of account is not possible because there is an existing customer with this type of account with a higher overdraft. This is an error which occurs when reducing the overdraft limit.", "Error: Existing Customer has Overdraft Higher than Desired Limit!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3: MessageBox.Show("This type of account does not allow alterations to the overdraft limit", "Error: This Account Type has Restrictions on Overdraft Limits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
            ShowCurrentOLimit();
        }
        #endregion
        #region Bank Modify Single Customers Overdraft
        private void BankModOverdraft()
        {
            if (m_CurrentBank.FindAccount(txtAccNoForModOverdraft.Text) != null)
            {
                m_ActiveAccount = m_CurrentBank.FindAccount(txtAccNoForModOverdraft.Text);
                switch (m_ActiveAccount.SetOverdraft(numUpDownOverdraft.Value))
                {
                    case 0: MessageBox.Show("Overdraft modification successful", "Feedback: Overdraft Changes Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 1: MessageBox.Show("Overdraft you tried to set exceeds the overdraft limit for this type of account!", "Error: Overdraft Exceeds Overdraft Limit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2: MessageBox.Show("You cannot have a negative overdraft!", "Error: Overdraft must be positive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 3: MessageBox.Show("BabyAccounts do not have access to overdraft functionality", "Error: Overdraft Changes Denied for BabyAccounts", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            else
            {
                MessageBox.Show("No account exists with that account number", "Error: Invalid Account Number!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Call Find Account By Name
        private void CallFindName()
        {
            listBoxFoundAccountsName.Items.Clear();
            listBoxFoundAccountsName.Items.AddRange(m_CurrentBank.FindName(txtFindName.Text));
        }
        #endregion
        #region Call Find Account By Account Number
        private void CallFindAccNum()
        {
            m_ActiveAccount = m_CurrentBank.FindAccount(txtFindAccNo.Text);
            if (m_ActiveAccount != null)
            {
                FillFoundAccountInfoTab2();
            }
            else
            {
                MessageBox.Show("No account exists with that account number!", "Account Number Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Show Total No of Accounts in Bank (setting txt boxes)
        private void ShowNoOfAccounts()
        {
            txtNumOfAccountsTab1.Text = m_CurrentBank.GetNumberOfAccounts().ToString();
            txtNumOfAccountsTab3.Text = txtNumOfAccountsTab1.Text;
        }
        #endregion
        #region Show Found Account Info (setting txt boxes)
        private void FillFoundAccountInfoTab2()
        {
            //fills the textbox in find account tab with the currently accessed account (provided there is one)
            if (m_ActiveAccount != null)
            {
                txtFoundAccDetails.Text = m_ActiveAccount.ToString();
            }
        }
        #endregion
        #region Show Next Account No (setting labels)
        private void ShowNextAccountNo()
        {
            label7.Text = m_CurrentBank.nextAccNo(m_CurrentBank.GetNextAccountUint());
        }
        #endregion
        #region Save Warning Letters written in Text Box
        public void CallWarnLetter()
        {
            try
            {
                m_CurrentBank.WarnLetter(txtWarnLett.Text);
                MessageBox.Show("Successfully Saved Warning Letters to /Warning Letters", "Feedback: Warning Letters Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion
        #region Resets all input fields in the AddAccount tab
        private void ResetUserInputForTab1()
        {
            ///resetting all textboxes etc
            comboAccountType.SelectedIndex = 0;
            txtAccName.Clear();
            txtAddress.Clear();
            updownBalance.Value = updownBalance.Minimum;
            updownOverdraft.Value = updownOverdraft.Minimum;
        }
        #endregion
        #region Fills Combo boxes with the Account types in 'Bank.AccountSelect' Enum type
        private void ComboRetrieveEnumDataSource()
        {
            ///Fills the combo boxes with the data from the public enumerated type in the Bank Class
            comboAccountSelcOverdraft.DataSource = Enum.GetValues(typeof(Bank.AccountSelect));
            comboAccountType.DataSource = Enum.GetValues(typeof(Bank.AccountSelect));
            comboAccSelcIrate.DataSource = Enum.GetValues(typeof(Bank.AccountSelect));
        }
        #endregion
        #region Access a Customer Account Once Found
        private void AccessCustomerAccount()
        {
            if (m_ActiveAccount != null)
            {
                AccountControl AccountActions = new AccountControl(m_ActiveAccount);
                AccountActions.ShowDialog();
                FillFoundAccountInfoTab2();
            }
            else
            {
                MessageBox.Show("Find an Account First!", "Cannot Access Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Call Bank Pay Out Interest To All Accounts
        private void PayInterestOut()
        {
            if (m_CurrentBank.ApplyInterest())
            {
                MessageBox.Show("Interest has been paid into all accounts", "Feedback: Interest Pay Out Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillFoundAccountInfoTab2();
            }
            else
            {
                MessageBox.Show("Reason: There are no accounts in this bank", "Error: Interest Pay Out Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Display List of All Accounts
        private void FillListBoxAllAccounts()
        {
            ShowNoOfAccounts();
            listBoxAllAccounts.Items.Clear();
            listBoxAllAccounts.Items.AddRange(m_CurrentBank.DisplayAllAccounts());
        }
        #endregion
        #region Call the save Bank method
        private void CallSaveBank()
        {
            try
            {
                saveFileDialogBank.ShowDialog();
                m_CurrentBank.SaveBank(saveFileDialogBank.FileName.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        #endregion


    }
}