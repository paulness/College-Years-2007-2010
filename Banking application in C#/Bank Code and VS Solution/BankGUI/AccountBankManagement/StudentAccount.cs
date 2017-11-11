using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AccountBankManagement
{
    /// <summary>
    /// StudentAccount has different overdraft limit and interest rate
    /// </summary>
    sealed class StudentAccount : AbstractAccount, IAccount
    {
        #region Static Data Members
        static private int m_OverdraftLimit = 9000;
        static private decimal m_IRate = 2.45M; //M is required at the end of literal value to make it assign it as a decimal not double
        #endregion
        #region Data Members
        private decimal m_Balance = 0;
        private decimal m_Overdraft = 0;
        #endregion

        #region Constructors that link to the main Constructor
        public StudentAccount(string pAccountNumber, string pName)
            : this(pAccountNumber, pName, "")
        {
        }
        public StudentAccount(string pAccountNumber, string pName, string pAddress)
            : this(pAccountNumber, pName, pAddress, 0) //balance will be set to zero
        {
        }
        public StudentAccount(string pAccountNumber, string pName, string pAddress, decimal pBalance)
            : this(pAccountNumber, pName, pAddress, pBalance, 0) //overdraft will be set to zero
        {
        }
        #endregion
        #region Main Constructor for when supplied with all parameters
        public StudentAccount(string pAccountNumber, string pName, string pAddress, decimal pBalance, decimal pOverdraft)
        {
            string l_ErrorString = ""; //Create a empty string to hold all error messages produced in one go
            base.SetAddress(pAddress); //Call the SetAddress method and give it pAddress (the address handed to this constructor)

            if (base.AccountNoValidation(pAccountNumber) == false)
            {
                l_ErrorString = l_ErrorString + "Enter a valid Account Number: " + pAccountNumber + "\r\n";
            }
            if (base.SetName(pName) == 2) //if SetName supplied with (pName) returned 2 then pName.Length was not greater than zero
            {
                l_ErrorString = l_ErrorString + "Please enter a name!" + "\r\n"; //adds the error message to the l_ErrorString
            }
            if (base.SetName(pName) == 1) //if SetName supplied with (pName) returned 1 then pName contained numerical digits
            {
                l_ErrorString = l_ErrorString + "The Name: " + pName + " - Contains numerical digits and is therefore not allowed" + "\r\n"; //adds the error message to the l_ErrorString
            }
            if (SetOverdraft(pOverdraft) == 1)
            {
                l_ErrorString = l_ErrorString + "The overdraft: " + pOverdraft.ToString() + " - you attempted to set was more than the Overdraft limit for your Account type!" + "\r\n";
            }
            if (SetOverdraft(pOverdraft) == 2)
            {
                l_ErrorString = l_ErrorString + "The overdraft: " + pOverdraft.ToString() + " - you attempted to set was a negative value, this is not allowed!" + "\r\n";
            }
            if (SetBalance(pBalance) == false) //if SetBalance supplied with (pBalance) returned false
            {
                l_ErrorString = l_ErrorString + "The balance you have tried to set " + pBalance.ToString() + " was lower than your overdraft (as a minus)" + "\r\n";
            }
            if (l_ErrorString.Length > 0) //test to see if there was any error messages produced in l_ErrorString
            {
                throw new Exception(l_ErrorString); //throws an exception with the entire message in l_ErrorString
            }
        }
        #endregion

        #region public static int GetOverdraftLimit()
        public static int GetOverdraftLimit()
        {
            return m_OverdraftLimit;
        }
        #endregion
        #region public static bool SetInterest(decimal pSetInterest)
        public static bool SetInterest(decimal pSetInterest)
        {
            if ((pSetInterest >= 0) && (pSetInterest <= 100))
            {
                m_IRate = pSetInterest;
                return true;
            }
            return false;
        }
        #endregion
        #region public static bool SetOverdraftLimit(int pLimit)
        public static void SetOverdraftLimit(int pLimit)
        {
            m_OverdraftLimit = pLimit;
        }
        #endregion
        #region public static decimal GetInterest()
        public static decimal GetInterest()
        {
            return m_IRate;
        }
        #endregion

        #region override public decimal GetBalance()
        override public decimal GetBalance()
        {
            return m_Balance;
        }
        #endregion
        #region override public decimal GetOverdraft()
        override public decimal GetOverdraft()
        {
            return m_Overdraft;
        }
        #endregion
        #region override public bool SetBalance(decimal pBalance)
        override public bool SetBalance(decimal pBalance)
        {
            if (pBalance >= (-m_Overdraft))
            {
                m_Balance = pBalance;
                return true;
            }
            return false;
        }
        #endregion
        #region override public bool PayIn(decimal pAmount)
        override public bool PayIn(decimal pAmount)
        {
            if (pAmount > 0)
            {
                m_Balance = m_Balance + pAmount;
                return true;
            }
            return false;
        }
        #endregion
        #region override public byte Withdraw(decimal pAmount)
        override public byte Withdraw(decimal pAmount)
        {
            ///amount you wish to withdraw must be greater than zero ie. 1 or higher
            if (pAmount > 0)
            {
                ///amount you wish to withdraw must be less than your (balance + overdraft)
                if (pAmount <= (m_Balance + m_Overdraft))
                {
                    m_Balance = m_Balance - pAmount;
                    return 0; //success: return true
                }
                return 1; //error: insufficient funds
            }
            return 2; //error: trying to withdraw a negative amount
        }
        #endregion
        #region override public decimal i_RatePercentofBalance()
        override public decimal i_RatePercentofBalance()
        {
            decimal l_IRateToPay = ((m_IRate * m_Balance) / 100);
            return l_IRateToPay;
        }
        #endregion
        #region override public decimal GetHalfOverdraft()
        override public decimal GetHalfOverdraft()
        {
            return (m_Overdraft / 2);
        }
        #endregion
        #region public override void Save(TextWriter pTextOut)
        public override void Save(TextWriter pTextOut)
        {
            ///Simply writes balance and overdraft to the stream then calls
            ///the base save method (abstract class)
            ///the order of save is (balance, overdraft, classname, accountno, name, address)
            pTextOut.WriteLine(GetBalance());
            pTextOut.WriteLine(GetOverdraft());
            base.Save(pTextOut);
        }
        #endregion
        #region ToString Override
        public override string ToString()
        {
            return "Account Type: " + this.GetType().Name + ",  Account No: " + base.GetAccountNumber() + ",  Name: " + base.GetName() + ",  Address: " + base.GetAddress() + ",  Balance: " + GetBalance() + ",  Overdraft: " + GetOverdraft();
        }
        #endregion
        #region override public byte SetOverdraft(decimal pOverdraft)
        override public byte SetOverdraft(decimal pOverdraft)
        {
            if (pOverdraft >= 0)
            {
                if (pOverdraft <= m_OverdraftLimit)
                {
                    m_Overdraft = pOverdraft;
                    return 0; //return 0 == return true
                }
                return 1; ///error: overdraft you are trying to set exceeds overdraft limit
            }
            return 2; ///error: overdraft you are trying to set is a negative value
        }
        #endregion
    }
}