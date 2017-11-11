using System;
using System.Collections; //essential for dynamic array ArrayList in FindName()
using System.Text;
using System.IO;

namespace AccountBankManagement
{
    /// <summary>
    /// Paul Ness Identifier Standards:
    /// m_identifier = private data member
    /// pIdentifier = parameter passed into methods
    /// l_Identifier = local data member (local to a method)
    /// btn_Identifier = form event handler method identifier example
    /// prop_Identifier = property get-set variable
    /// </summary>

    public class Bank
    {
        ///Enumerated type used for many things in the program
        ///including SetOverdraftLimit, Save methods, AddAccount
        public enum AccountSelect { Account, StudentAccount, BabyAccount };
        #region Static method LOAD BANK method
        ///Static method doesn't need a new instance of Bank to run
        ///ie. Bank myBank = Bank.Load("filename.txt");
        public static Bank Load(string pFileName)
        {
            ///This simply calls the constructor that accepts a fileName
            ///as a parameter (we got this from the value passed into this static method
            return new Bank(pFileName);
        }
        #endregion
        #region Data Members
        private string m_Name; //Bank name data member
        private IAccount[] m_Accounts; //Creates a reference 'm_Accounts' that can point to a new Array of IAccount (any class that uses this interface can be held in this array)
        private static uint sm_NextAccountNumber = 1; //holds the next Account number in uint form to be sent to the generate next account no in hex form method
        const string ACCOUNT_KEY = "NEWACCOUNT"; //Used in the saving and loading of Banks to know the next thing to come is an Account
        DateTime dt = DateTime.Now; //used for building the account no
        #endregion

        #region Constructor to construct Bank instance from user input
        //If a user calls this constructor they need to pass it (a string, an int)
        public Bank(string pName, int pNumberOfAccounts)
        {
            if (pNumberOfAccounts > 0) //if pNumberOfAccounts is not negative or zero
            {
                m_Name = pName; //assign bank name the name passed (pName) to m_Name
                //create array of IAccount interfaces the size of the pNumberOfAccounts parameter that was passed into this constructor
                m_Accounts = new IAccount[pNumberOfAccounts];
            }
            else
            {
                throw new Exception("Bank Error: Cannot create a Bank with: " + pNumberOfAccounts + " Accounts \r\n");
            }
        }
        #endregion
        #region Constructor to construct Bank instance passed in a string (filepath/filename.extension)
        public Bank(string pFileName)
        {
            ///Reference l_reader can point to instances of TextReader
            ///we point it to null because in the finally block we wish
            ///to close a Stream its pointing to only if its pointing to anything
            StreamReader l_reader = null;
            try
            {
                ///point l_reader reference to new StreamReader instance given the parameter pFileName
                ///supplied by the constructor call, as the filename to look for
                l_reader = new StreamReader(pFileName);
                ///ask l_reader reference to find .ReadLine() method in its instance StreamReader
                ///which reads the first line of the txt file and assign its string value to m_Name
                m_Name = l_reader.ReadLine();
                ///create an int to hold number of accounts
                ///its value will be the value of int.Parse(second line of the txt file)
                int l_numberOfAccounts = int.Parse(l_reader.ReadLine());

                //create array of IAccount interfaces the size of the pNumberOfAccounts parameter that was passed into this constructor
                m_Accounts = new IAccount[l_numberOfAccounts];
                ///reads the next line of the txt file and this value
                ///is the next account number to be assigned
                sm_NextAccountNumber = uint.Parse(l_reader.ReadLine());


                ///counter increments when StreamReader.ReadLine() == to the const ACCOUNT_KEY
                ///used to move to next element of m_Accounts[l_index] array
                ///when an account is about to be stored in array
                int l_index = 0;
                ///while the StreamReader.ReadLine() value is == to ACCOUNT_KEY const
                ///ie. the line read from the StreamReader is equal to ACCOUNT_KEY
                while (l_reader.ReadLine() == ACCOUNT_KEY)
                {
                    ///because of the way we had to override the AbstractAccount
                    ///saving method the abstract account saves the balance & overdraft
                    ///immediatly after ACCOUNT_KEY which is why i have to use these temp variables
                    decimal l_tempBalance = decimal.Parse(l_reader.ReadLine());
                    decimal l_tempOverdraft = decimal.Parse(l_reader.ReadLine());
                    //this is the class name of the type of Account
                    string l_tempTypeofAccount = l_reader.ReadLine();

                    switch (l_tempTypeofAccount)
                    {
                        ///in the case when the string (l_tempTypeofAccount) contains "Account"
                        case "Account": m_Accounts[l_index] = new Account(l_reader.ReadLine(), l_reader.ReadLine(), l_reader.ReadLine(), l_tempBalance, l_tempOverdraft);
                            break;
                        ///The reference to the array of IAccounts is pointed to the subscript of the int value contained in [l_index]
                        ///create new StudentAccount instance calling its constructor & Assign the constructed object to the array
                        case "StudentAccount": m_Accounts[l_index] = new StudentAccount(l_reader.ReadLine(), l_reader.ReadLine(), l_reader.ReadLine(), l_tempBalance, l_tempOverdraft);
                            break;
                        case "BabyAccount": m_Accounts[l_index] = new BabyAccount(l_reader.ReadLine(), l_reader.ReadLine(), l_reader.ReadLine(), l_tempBalance); //no overdraft for BabyAccount (but we read the default value of zero before)
                            break;
                        default: throw new Exception();
                    }

                    l_index++;//increment l_index because we found a line with value == ACCOUNT_KEY
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (l_reader != null) //if l_reader reference is pointing anywhere
                {
                    l_reader.Close(); //close the stream its pointed to
                }
            }
        }
        #endregion

        #region public string GetBankName()
        public string GetBankName()
        {
            return m_Name;
        }
        #endregion
        #region public uint GetNextAccountUint()
        public uint GetNextAccountUint()
        {
            return sm_NextAccountNumber;
        }
        #endregion

        #region Adding a new Account Factory (can add any type of account)
        public IAccount AddAccount(AccountSelect pSelectAdd, string pName, string pAddress, decimal pBalance, decimal pOverdraft)
        {
            ///Look through the array of references looking for
            ///an appropriate place to store a reference to the new account
            for (uint i = 0; i < m_Accounts.Length; ++i)
            {
                if (m_Accounts[i] == null) //if there is an empty space to store an Account reference
                {
                    ///this switch statement works on the enum type that was passed into this method
                    ///it finds out what type of account you wish to create and makes an instance of it
                    ///which can be pointed to/accessed by the IAccount array l_index, m_Accounts[i]
                    switch (pSelectAdd)
                    {
                        ///in the case the variable pSelectAdd
                        ///holds the enum type AccountSelect.Account
                        case AccountSelect.Account:
                            ///make a new Account class instance by calling its constructor
                            ///with the bracketed parameters and reference to it
                            ///from the IAccount array l_index m_Accounts[i]
                            m_Accounts[i] = new Account(dt.Year.ToString() + "A" + sm_NextAccountNumber.ToString("X"), pName, pAddress, pBalance, pOverdraft);
                            break;
                        case AccountSelect.BabyAccount:
                            ///ditto but making a new BabyAccount class instance
                            ///the constructor has no overdraft!
                            m_Accounts[i] = new BabyAccount(dt.Year.ToString() + "A" + sm_NextAccountNumber.ToString("X"), pName, pAddress, pBalance);
                            break;
                        case AccountSelect.StudentAccount:
                            ///currentyear, "A", HexAccountNo, name, address, balance, overdraft
                            m_Accounts[i] = new StudentAccount(dt.Year.ToString() + "A" + sm_NextAccountNumber.ToString("X"), pName, pAddress, pBalance, pOverdraft);
                            break;
                        default: continue;
                    }

                    // increment the next account number
                    sm_NextAccountNumber++;

                    // and return the reference to the new account
                    return m_Accounts[i];
                }
            }
            ///if you can't find a place to store the new account
            ///(i.e. the bank is full) then return null.
            return null;
        }
        #endregion
        #region Generate next Account No in hex form
        public string nextAccNo(uint pNextAccountNo)
        {
            ///perform the formatting tasks
            string l_nextAccountNumber = dt.Year.ToString() + "A" + pNextAccountNo.ToString("X");
            ///return it back to this string method
            return l_nextAccountNumber;
        }
        #endregion
        #region Finding an Account by Account Number
        //Method that finds Accounts it is given the Account Number your looking for (pAccountNumber)
        public IAccount FindAccount(string pAccountNumber)
        {
            pAccountNumber = pAccountNumber.Trim().ToUpper();
            for (uint i = 0; i < m_Accounts.Length; ++i)
            {
                ///if the reference inside [i] in the array m_Accounts DOES NOT point to null
                ///then the reference points to an Account instance (there is an Account here!)
                ///if we ask the reference to find .GetAccountNumber() method in the instance
                ///and that returns the same value as the account number we are looking for...
                if ((m_Accounts[i] != null) && (pAccountNumber == m_Accounts[i].GetAccountNumber()))
                {
                    //then we return the reference that points to the account we are looking for
                    return m_Accounts[i];
                }
            }
            return null; //no reference points to an Account instance with that Account Number
        }
        #endregion
        #region Finding an Account by Name
        public string[] FindName(string pFindName)
        {
            ///given pFindName we trim it and put it in caps
            pFindName = pFindName.Trim().ToUpper();
            ///make a reference that can point to a new ArrayList
            ///System.Collections is required for ArrayList
            ArrayList AccountNumsFound = new ArrayList();

            ///search the whole array in bank
            for (uint i = 0; i < m_Accounts.Length; ++i)
            {
                ///must be an account there, with the same name as the one this
                ///method was handed as a parameter pFindName
                if ((m_Accounts[i] != null) && (pFindName == m_Accounts[i].GetName()))
                {
                    ///if true add the ToString() of that account to the ArrayList
                    AccountNumsFound.Add(m_Accounts[i].ToString());
                }
            }
            //use ToArray() method on dynamic array then cast it to a string array
            ///return the array list to the methods return type 'normal string array'
            return (string[])AccountNumsFound.ToArray(typeof(string));
        }
        #endregion
        #region Display all Accounts in Bank
        public string[] DisplayAllAccounts()
        {
            ///same as findname just not looking for particular names and no parameters needed
            ArrayList l_ArrayAllAccounts = new ArrayList();

            for (uint i = 0; i < m_Accounts.Length; ++i)
            {
                if (m_Accounts[i] != null)
                {
                    l_ArrayAllAccounts.Add(m_Accounts[i].ToString());
                }
            }
            return (string[])l_ArrayAllAccounts.ToArray(typeof(string));
        }
        #endregion
        #region Delete Account based on Account Number
        public bool DelAccount(string pAccountNumber)
        {
            ///searches for an account in the bank for that account no
            for (uint i = 0; i < m_Accounts.Length; ++i)
            {
                ///if it finds one that isn't null and the we are looking for is the same
                if ((m_Accounts[i] != null) && (pAccountNumber == m_Accounts[i].GetAccountNumber()))
                {
                    m_Accounts[i] = null; //set the reference to that Account to point to nothing
                    return true;
                }
            }
            return false; //no Account with that Account number existed to delete
        }
        #endregion

        #region public int GetOverdraftLimit(AccountSelect pSelectGetOLimit)
        public int GetOverdraftLimit(AccountSelect pSelectGetOLimit)
        {
            switch (pSelectGetOLimit)
            {
                case AccountSelect.Account: return Account.GetOverdraftLimit();
                case AccountSelect.StudentAccount: return StudentAccount.GetOverdraftLimit();
                default: return 0;
            }
        }
        #endregion
        #region public decimal GetInterestRate(AccountSelect pSelectAccount)
        public decimal GetInterestRate(AccountSelect pSelectAccount)
        {
            switch (pSelectAccount)
            {
                case AccountSelect.Account:
                    return Account.GetInterest();
                case AccountSelect.StudentAccount:
                    return StudentAccount.GetInterest();
                default: return 0;
            }
        }
        #endregion
        #region public uint GetNumberOfAccounts()
        ///method that returns an uint figure of how many actual accounts in bank
        public uint GetNumberOfAccounts()
        {
            uint l_Result = 0;
            foreach (IAccount a in m_Accounts)
            {
                if (a != null)
                {
                    l_Result++;
                }
            }
            return l_Result; //returns the l_Result to this method
        }
        #endregion

        #region Set the Interest rate for all accounts of one type
        public bool SetInterestRate(decimal pSetInterest, AccountSelect pSelectSetIrate)
        {
            switch (pSelectSetIrate)
            {
                ///in the case where pSelectSetIrate == AccountSelect.Account
                case AccountSelect.Account:
                    ///if Account.SetInterest given pSetInterest
                    ///returns true then this method also returns true
                    ///not to mention we have already set the interest at this point
                    if (Account.SetInterest(pSetInterest))
                    {
                        return true;
                    }
                    else
                    {
                        ///otherwise we return false
                        return false;
                    }
                case AccountSelect.StudentAccount:
                    if (StudentAccount.SetInterest(pSetInterest))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                ///if pSelectSetIrate != to Account or StudentAccount then it cannot accept Interest alterations so return false
                default: return false;
            }
        }
        #endregion
        #region Set the overdraft limit for all accounts of one type
        public byte SetOverdraftLimit(int pSetLimit, AccountSelect pSelectSetOLimit)
        {
            ///set to the lowest possible overdraft limit to begin with
            decimal l_HighestOverdraft = 0;
            ///obviously pSetLimit (the amount we want the overdraft limit to be)
            ///must be a positive value
            if (pSetLimit >= 0)
            {
                ///what type of account do we want the overdraft limit to be modified on?
                switch (pSelectSetOLimit)
                {
                    ///case where the user selected 'Account'
                    case AccountSelect.Account:
                        ///search every reference in IAccount array m_Accounts
                        foreach (IAccount a in m_Accounts)
                        {
                            ///if reference pointing somewhere ie.(not null)
                            ///AND the reference is pointing to an 'Account'
                            if ((a != null) && (a.GetType().Name == "Account"))
                            {
                                ///if the overdraft of currently accessed account is
                                ///greater than previous value in l_HighestOvedraft
                                if (a.GetOverdraft() > l_HighestOverdraft)
                                {
                                    ///then the new total becomes this overdraft
                                    l_HighestOverdraft = a.GetOverdraft();
                                }
                            }
                        }
                        ///if the number we want to modify the overdraft limit to
                        ///is greater than the highest existing overdraft
                        ///held by any customer of this type of 'Account'
                        if (pSetLimit >= l_HighestOverdraft)
                        {
                            ///then set the overdraft limit to what we asked
                            Account.SetOverdraftLimit(pSetLimit);
                            return 0; ///return 0 == return true
                        }
                        else
                        {
                            return 2; ///error: overdraft limit we wanted was less than one of the customers existing overdrafts of this account type
                        }
                    ///case where the user selected 'StudentAccount'
                    ///ditto as above
                    case AccountSelect.StudentAccount:
                        foreach (IAccount a in m_Accounts)
                        {
                            if ((a != null) && (a.GetType().Name == "StudentAccount"))
                            {
                                if (a.GetOverdraft() > l_HighestOverdraft)
                                {
                                    l_HighestOverdraft = a.GetOverdraft();
                                }
                            }
                        }
                        if (pSetLimit >= l_HighestOverdraft)
                        {
                            StudentAccount.SetOverdraftLimit(pSetLimit);
                            return 0; ///return 0 == return true
                        }
                        else
                        {
                            return 2; ///error: overdraft limit we wanted was less than one of the customers existing overdrafts of this account type
                        }
                    default: return 3; ///the account type you want to alter overdraft limit to does not support changes to the overdraft limit
                }
            }
            else
            {
                return 1; ///error: user tried to set overdraft limit to a negative
            }
        }
        #endregion

        #region Apply its interest rate to all Accounts (monthly bank management task)
        public bool ApplyInterest()
        {
            ///have to have some accounts in the bank
            if (GetNumberOfAccounts() > 0)
            {
                ///for each class in the m_Accounts array that implements IAccount interface 
                foreach (IAccount a in m_Accounts)
                {
                    ///if the reference inside the current array
                    ///element is pointing to somewhere (ie: not null)
                    if (a != null)
                    {
                        ///call the PayIn method giving it the value returned
                        ///from another method as a parameter
                        a.PayIn(a.i_RatePercentofBalance());
                    }
                }
                return true;
            }
            ///if statement wasnt true we had no accounts !!!
            return false;
        }
        #endregion
        #region Save Warning Letters ready for printing
        public void WarnLetter(string pWarnLettBody)
        {
            try
            {
                if (Directory.Exists("Warning Letters"))
                {
                    Directory.Delete("Warning Letters", true); //true means its ok to delete subdirs and files
                }
                Directory.CreateDirectory("Warning Letters"); //create a new one
            }
            catch (Exception e) //any problems in any line in the try we get here
            {
                throw e;
            }
            ///create ref to TextWriter, now we just point it to null
            TextWriter l_WarnLett = null;

            ///for all account references
            foreach (IAccount a in m_Accounts)
            {
                ///if that reference is pointing somewhere (ie. not null)
                if (a != null)
                {
                    ///if the balance + the overdraft is less than half of the overdraft
                    ///(ie. the balance must be negative for this to occur)
                    if ((a.GetBalance() + a.GetOverdraft()) < a.GetHalfOverdraft())
                    {
                        StringBuilder WarningLetter = new StringBuilder();
                        WarningLetter.Append(a.GetAddress().ToString());
                        WarningLetter.Append("\r\n");
                        WarningLetter.Append("\r\n");
                        WarningLetter.Append("Dear, " + a.GetName().ToString());
                        WarningLetter.Append("\r\n");
                        WarningLetter.Append("\r\n");
                        WarningLetter.Append(pWarnLettBody);
                        WarningLetter.Append("\r\n");
                        WarningLetter.Append("\r\n");
                        WarningLetter.Append("\r\n");
                        WarningLetter.Append("Sincerely, " + m_Name);
                        try
                        {
                            l_WarnLett = new StreamWriter("Warning Letters/" + a.GetAccountNumber() + ".txt");
                            l_WarnLett.WriteLine(WarningLetter);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        finally
                        {
                            if (l_WarnLett != null)
                            {
                                l_WarnLett.Close();
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Save the Bank and all its Accounts to a single file
        public void SaveBank(string pFileName)
        {
            //we use the reference l_writer to access our link to a stream when it points to an instance of StreamWriter but now it points to null
            StreamWriter l_writer = null;
            try
            {
                l_writer = new StreamWriter(pFileName); //point l_writer to a stream that creates a file from the pFileName and connects a stream to it
                l_writer.WriteLine(m_Name); //writes the bank name to the first line of the txt file
                l_writer.WriteLine(m_Accounts.Length); //writes the length of the array of Account references (number of Accounts allowable)
                l_writer.WriteLine(sm_NextAccountNumber); //writes the next Account Number to be assigned

                for (int i = 0; i < m_Accounts.Length; i++) // for all possible accounts
                {
                    ///if the account reference points to an Account instance
                    ///then an Account exists so ask the reference to call the instance .Save method
                    if (m_Accounts[i] != null)
                    {
                        // write the account key to signify what follows is an account
                        l_writer.WriteLine(ACCOUNT_KEY);
                        /// ask the Account reference to call the Account instance .Save method
                        /// giving it the current l_writer pointer/reference to StreamWriter as a parameter
                        /// m_Accounts[i].GetType().Name gets the class name of the currently referenced class instance
                        /// so it can save this to file (so it knows what type of Account it is, when it loads the Bank back up)

                        m_Accounts[i].Save(l_writer);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ///if the l_writer reference is pointing to an instance of StreamWriter
                if (l_writer != null)
                {
                    //l_writer finds in StreamWriter the method .Close() and closes it
                    l_writer.Close();
                }
            }
        }
        #endregion
        #region ToString Method
        //overrides ToString method in parent class (object.ToString())
        public override string ToString()
        {
            //declare ref l_Result can point to instances of StringBuilder
            StringBuilder l_Result;
            ///point ref l_Result to new instance of
            ///StringBuilder given parameter (m_Name)
            l_Result = new StringBuilder(m_Name);

            ///search the whole bank account array
            for (uint i = 0; i < m_Accounts.Length; ++i) //uint because we start from positive
            {
                ///if the element in this array subscript contains
                ///a reference that points somewhere (ie. is not null)
                if (m_Accounts[i] != null)
                {
                    //add a carriage return and new line
                    l_Result.Append("\r\n");

                    /// ask the reference contained inside array subscript m_Accounts[i]
                    /// to point to its own instance and call its own ToString()
                    /// this will follow l_Result ref to StringBuilder instance then append
                    /// all the Account info for that Account to it
                    l_Result.Append(m_Accounts[i].ToString());
                }
            }
            /// this is excuted when the 'for loop' has finished
            /// it returns the completed StringBuilder to this string
            /// method which so happens to be this Bank classes ToString()
            return l_Result.ToString();
        }
        #endregion
    }
}