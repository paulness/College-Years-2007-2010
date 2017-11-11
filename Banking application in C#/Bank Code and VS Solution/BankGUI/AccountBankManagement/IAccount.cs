using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AccountBankManagement
{
    public interface IAccount
    {
        string GetAccountNumber();
        bool AccountNoValidation(string pAccountNumber);
        string GetName();
        byte SetName(string pName);
        string GetAddress();
        void SetAddress(string pAddress);
        decimal GetBalance();
        bool SetBalance(decimal pBalance);
        bool PayIn(decimal pAmount);
        byte Withdraw(decimal pAmount);
        decimal GetOverdraft(); //if the account doesnt have an overdraft this method method will just return zero
        decimal GetHalfOverdraft();
        decimal i_RatePercentofBalance();
        byte SetOverdraft(decimal pOverdraft);
        void Save(TextWriter pTextOut);
        void Save(string pFileName);
        string ToString();
    }
}
