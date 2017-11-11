using System;
using System.Collections.Generic;
using System.Text;
using AccountBankManagement; //required to access this namespace

namespace UnitTesting
{
    class UnitTesting
    {
        ///testing Withdraw on all account types
        public static void TestingWithdraw()
        {
            ///make a new bank with room for 3 accounts
            Bank l_WithdrawBank = new Bank("", 3);
            ///for each account type (each value in enum type Bank.AccountSelect
            foreach (Bank.AccountSelect a in Enum.GetValues(typeof(Bank.AccountSelect)))
            {
                ///total error & pass calculators
                uint l_PassCounter = 0;
                uint l_InsufficientFundsCounter = 0;
                uint l_NegativeWithdrawalCounter = 0;

                ///add an account (of type 'a') see above foreach loop
                ///balance is 100 overdraft is 48 (total funds 148)
                IAccount l_WithdrawActiveAccount = l_WithdrawBank.AddAccount(a, "name", "address", 100, 48);
                ///for -1000 to 1000 total (2001) including zero
                for (int i = -1000; i <= 1000; i++)
                {
                    ///call the withdraw method try to withdraw the current value of 'i'
                    switch (l_WithdrawActiveAccount.Withdraw(i))
                    {
                        ///if the withdraw method returned 0 withdrawal successful
                        case 0: l_PassCounter++;
                            break;
                        ///if the withdraw method returned 1 insufficient funds
                        case 1: l_InsufficientFundsCounter++;
                            break;
                        ///if the withdraw method returned 2 tried to withdraw negative amount
                        case 2: l_NegativeWithdrawalCounter++;
                            break;
                    }
                    ///need to set the balance back to 100 when we finish each withdrawal try
                    ///otherwise when withdraw method succeeds the balance goes down
                    l_WithdrawActiveAccount.SetBalance(100);
                }


                ///we should be able to withdraw 148 successfully 148 times
                ///these are all withdrawals where the amount to withdraw is any number
                ///1 to 148 (inclusive)
                ///we dont allow negative withdrawals or withdrawals of zero this is
                ///1001 total failed withdrawals this way -1000 to 0 (inclusive)
                if ((l_PassCounter == 148) && (l_NegativeWithdrawalCounter == 1001)
                    && (a.ToString() != "BabyAccount"))
                {
                    Console.WriteLine(a.ToString() + " Withdrawal Test PASSED!");
                }
                ///Same as above BUT BabyAccounts cant withdraw more than 5
                ///so valid withdrawals are 1, 2, 3, 4, 5 (total of 5)
                else if ((l_PassCounter == 5) && (l_NegativeWithdrawalCounter == 1001)
                    && (a.ToString() == "BabyAccount"))
                {
                    Console.WriteLine(a.GetType().Name + " Withdrawal Test (more than 5pounds not allowed) + (overdraft not allowed) therefore - PASSED!");
                }
            }
        }

        ///testing PayIn (cannot pay in a negative amount)
        static void TestPayIn()
        {
            Bank l_PayInBank = new Bank("", 3);
            IAccount l_ActiveAccount;
            foreach (Bank.AccountSelect a in Enum.GetValues(typeof(Bank.AccountSelect)))
            {
                uint l_FailCounter = 0;
                uint l_PassCounter = 0;
                l_ActiveAccount = l_PayInBank.AddAccount(a, "name", "address", 0, 0);
                ///valid PayIn amounts should be 1 to 1000 (total: 1000)
                ///invalid PayIn amounts should be -1000 to 0 (total: 1001)
                for (int i = -1000; i <= 1000; i++)
                {
                    if (!l_ActiveAccount.PayIn(i))
                    {
                        l_FailCounter++;
                    }
                    else
                    {
                        l_PassCounter++;
                    }
                }
                if ((l_PassCounter == 1000) && (l_FailCounter == 1001))
                {
                    Console.WriteLine("Testing PayIn Functionality PASSED!");
                }
                else
                {
                    Console.WriteLine("Testing PayIn Functionality Failed!");
                }
            }
        }

        ///testing SetInterest on all account types
        static void TestSetInterest()
        {
            Bank l_SetInterestBank = new Bank("", 3);
            ///for each type of account in the bank
            foreach (Bank.AccountSelect a in Enum.GetValues(typeof(Bank.AccountSelect)))
            {
                ///reset back to zero when foreach executed
                uint l_TotalTrue = 0;
                uint l_TotalFalse = 0;

                ///valid interest rates are 0-100 (total 101)
                for (int i = -1000; i <= 1000; i++)
                {
                    switch (l_SetInterestBank.SetInterestRate(i, a))
                    {
                        case true: l_TotalTrue++;
                            break;
                        case false: l_TotalFalse++;
                            break;
                    }
                }
                ///if we can set the interest rate to 100 on account type 'a'
                if (l_TotalTrue == 101)
                {
                    Console.WriteLine(a.ToString() + " Set Interest Rate PASSED!");
                }
                else if ((a.ToString() == "BabyAccount") && (l_TotalTrue == 0))
                {
                    Console.WriteLine(a.ToString() + " Set Interest Rate Not Allowed Therefore - PASSED!");
                }
            }
        }

        ///simple TestAddAccount on all account types
        static void TestAddAccount()
        {
            int l_AddAccountCounter = 0;
            Bank l_AddAccountBank = new Bank("", 3);
            ///for each type of account
            foreach (Bank.AccountSelect a in Enum.GetValues(typeof(Bank.AccountSelect)))
            {
                ///add a new account
                l_AddAccountBank.AddAccount(a, "testNAME", "testADDRESS", 100, 0);
                l_AddAccountCounter++;
            }
            ///if the number of accounts in the l_SetInterestBank == to the counter
            if (l_AddAccountBank.GetNumberOfAccounts() == l_AddAccountCounter)
            {
                Console.WriteLine("Testing Adding Accounts PASSED");
            }
        }

        ///testing SetOverdraft on all account types (test not exceed overdraft limit for account type)
        static void TestSetOverdraft()
        {
            Bank l_SetOverdraftBank = new Bank("", 3);
            foreach (Bank.AccountSelect a in Enum.GetValues(typeof(Bank.AccountSelect)))
            {
                uint l_PassCounter = 0;
                uint l_FailExceedLimitCounter = 0;
                uint l_FailNegativeCounter = 0;
                uint l_PassBabyAccountCounter = 0;
                IAccount l_SetOverdraftActiveAccount = l_SetOverdraftBank.AddAccount(a, "name", "address", 0, 0);

                ///valid values Account == 0 to 1000 (1000 being overdraft limit) (inclusive)
                ///valid values StudentAccount == 0 to 9000 (inclusive)
                ///valid values BabyAccount == all values set to zero (l_PassBabyAccountCounter)
                for (int i = -1000; i <= 10000; i++)
                {
                    switch (l_SetOverdraftActiveAccount.SetOverdraft(i))
                    {
                        case 0: l_PassCounter++;
                            break;
                        case 1: l_FailExceedLimitCounter++;
                            break;
                        case 2: l_FailNegativeCounter++;
                            break;
                        case 3: l_PassBabyAccountCounter++;
                            break;
                    }
                }
                if ((a.ToString() == "Account") && (l_PassCounter == 1001))
                {
                    Console.WriteLine(a.ToString() + " Set Overdraft PASSED!");
                }
                else if ((a.ToString() == "StudentAccount") && (l_PassCounter == 9001))
                {
                    Console.WriteLine(a.ToString() + " Set Overdraft PASSED!");
                }
                else if ((a.ToString() == "BabyAccount") && (l_PassBabyAccountCounter == 11001))
                {
                    Console.WriteLine(a.ToString() + " Set Overdraft PASSED!");
                }
            }
        }

        ///adding accounts with numerical numbers in their names to see if any get made
        static void TestingNumericalInputToName()
        {
            Bank l_TestName = new Bank("", 3);
            ///foreach type of account
            foreach (Bank.AccountSelect a in Enum.GetValues(typeof(Bank.AccountSelect)))
            {
                uint l_FailCounter = 0;

                ///for all numbers from -100 to 100 (total 201)
                for (int i = -100; i <= 100; i++)
                {
                    ///the input name will be in the format:
                    ///"accountType-Valueofi-AccountType" excluding the "-"
                    try
                    {
                        l_TestName.AddAccount(a, a + i.ToString() + a, "", 0, 0);
                        ///if the above line made an account without throwing exception
                        ///then we have a bug in our code
                        Console.WriteLine("Testing Set Name FAILED - Bug in Code");
                    }
                    catch
                    {
                        l_FailCounter++;
                    }
                }
                if (l_FailCounter == 201)
                {
                    Console.WriteLine(a.ToString() + " Test Set Name Passed as all " + l_FailCounter + " Attempts to Create Accounts Containing Digits in Names Failed!");
                }
            }
        }

        static void Main(string[] args)
        {
            TestPayIn();
            TestSetOverdraft();
            TestSetInterest();
            TestingWithdraw();
            TestAddAccount();
            TestingNumericalInputToName();
            Console.ReadKey();
        }
    }
}