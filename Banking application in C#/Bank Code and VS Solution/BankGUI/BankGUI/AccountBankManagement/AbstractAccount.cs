using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AccountBankManagement
{
    abstract class AbstractAccount
    {
        #region Data Members
        private string m_AccountNumber;
        private string m_Name;
        private string m_Address;
        #endregion

        #region ABSTRACT METHODS
        ///Methods child classes must implement
        abstract public decimal GetBalance();
        abstract public decimal GetOverdraft();
        abstract public decimal GetHalfOverdraft();
        abstract public decimal i_RatePercentofBalance();
        abstract public bool PayIn(decimal pAmount);
        abstract public bool SetBalance(decimal pBalance);
        abstract public byte Withdraw(decimal pAmount);
        abstract public byte SetOverdraft(decimal pOverdraft);
        #endregion

        #region public string GetAccountNumber()
        public string GetAccountNumber()
        {
            return m_AccountNumber;
        }
        #endregion
        #region public bool AccountNoValidation(string pAccountNumber)
        public bool AccountNoValidation(string pAccountNumber) //method that returns a bool
        {
            ///Account Number must be a string longer than zero characters
            if (pAccountNumber.Length > 0)
            {
                m_AccountNumber = pAccountNumber;
                return true;
            }
            return false;
        }
        #endregion

        #region public string GetName()
        public string GetName()
        {
            //Allows outside methods to see the value of m_Name as read only
            return m_Name;
        }
        #endregion
        #region public byte SetName(string pName)
        /// <summary>
        /// Method returns a byte if it returns 0 (zero) the method was
        /// successful all other digits represent a unique error. 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public byte SetName(string pName) //method gets handed the name the user types in
        {
            //name must have at least 1 character
            if (pName.Length > 0)
            {
                ///makes the name into an array the size of the number
                ///of characters the name contains where each
                ///element of array holds a character
                char[] l_StringToCharArray = pName.ToCharArray();

                ///searches through each element in array
                foreach (char a in l_StringToCharArray)
                {
                    //checks the character inside the element to see if its a digit
                    if (char.IsDigit(a))
                    {
                        return 1;
                    }
                }

                ///if we successfully got through that forloop without returning false
                ///we now assign m_Name to the name passed to this method
                ///but we like to tidy things first by making it uppercase and trimming off white spaces
                m_Name = pName.ToUpper().Trim();
                return 0; //and this method exits with bool set to true
            }
            return 2; //if pName was zero characters or less we come to here
        }
        #endregion

        #region public string GetAddress()
        public string GetAddress()
        {
            return m_Address;
        }
        #endregion
        #region public void SetAddress(string pAddress)
        public void SetAddress(string pAddress)
        {
            ///This method is always successful even if it fails the if
            ///statement the address is set to "NOT PROVIDED"
            if (pAddress.Length > 0)
            {
                m_Address = pAddress.Trim().ToUpper();
            }
            else
            {
                m_Address = "NOT PROVIDED";
            }
        }
        #endregion

        #region public virtual void Save(TextWriter pTextOut)
        public virtual void Save(TextWriter pTextOut)
        {
            ///Follows the TextWriter reference to its instance and calls
            ///the WriteLine method which writes the parameter to the stream
            ///the order we have put here cannot be changed
            pTextOut.WriteLine(this.GetType().Name); //name of the class we are saving running (to get the account type)
            pTextOut.WriteLine(GetAccountNumber());
            pTextOut.WriteLine(GetName());
            pTextOut.WriteLine(GetAddress());
        }
        #endregion
        #region public void Save(string pFileName)
        ///The Save method is overloaded this one accepts a string pFileName as a parameter
        public void Save(string pFileName)
        {
            ///Reference pTextOut can point to instances of TextWriter
            ///we point it to null because in the finally block we wish
            ///to close a Stream its pointing to only if its pointing to anything
            TextWriter l_TextOut = null;
            try
            {
                ///points the reference pTextOut to a new instance of
                ///StreamWriter(passed in the parameter) that was
                ///handed to this method StreamWriter sets up a Stream to
                ///write to and the filepath/name.extension is included in the string
                l_TextOut = new StreamWriter(pFileName);
                ///Now we have an open Stream we need content to write to it
                ///we call the other Save method giving it the pointer to our
                ///current stream (pTextOut)
                Save(l_TextOut);
            }
            catch (Exception e) //if the try fails move to here and store the Exception in variable e of type Exception
            {
                throw e; //throw it back again
            }
            finally //this is executed regardless on Exception thrown or not
            {
                //if pTextOut reference is not null (ie. Its pointing to an instance of TextWriter)
                if (l_TextOut != null)
                {
                    //follow the reference to ask the stream its pointing to close
                    l_TextOut.Close();
                }
            }
        }
        #endregion

    }
}
