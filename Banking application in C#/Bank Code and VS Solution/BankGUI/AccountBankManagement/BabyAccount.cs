using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AccountBankManagement
{
    /// <summary>
    /// BabyAccount extends Account it inherits all methods from Account
    /// BabyAccount is sealed which means nobody can extend it (it cant be another classes parent)
    /// </summary>
    sealed class BabyAccount : Account, IAccount
    {
        public override decimal i_RatePercentofBalance()
        {
            ///When the bank pays out interest instead of calculating the amount
            ///to pay into BabyAccount we force this to be zero so it wont ever get access to interest
            return 0;
        }
        public override byte SetOverdraft(decimal pOverdraft)
        {
            pOverdraft = 0;
            return 3; ///error: BabyAccounts cannot be set an overdraft (it is always zero)
        }
        public override decimal GetOverdraft()
        {
            SetOverdraft(0);
            return base.GetOverdraft();
        }
        public override byte Withdraw(decimal pAmount)
        {
            if (pAmount > 5)
            {
                return 3; //error: BabyAccount cannot withdraw more than £5 at a time
            }
            //return base. means it returns the value to the orignal method (in the parent class)
            return base.Withdraw(pAmount);
        }

        public BabyAccount(string pAccountNumber, string pName)
            : this(pAccountNumber, pName, "")
        {
        }
        public BabyAccount(string pAccountNumber, string pName, string pAddress)
            : this(pAccountNumber, pName, pAddress, 0)
        {
        }
        public BabyAccount(string pAccountNumber, string pName, string pAddress, decimal pBalance)
            : base(pAccountNumber, pName, pAddress, pBalance) //calls the constructor in the parent class
        {
        }
    }
}