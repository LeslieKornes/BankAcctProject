using System;

namespace BankAcctProject
{
    public abstract class Account   //Our Base Class. Abstract bc it will never be instantiated itself.
    {
        public int AccountNumber { get; set; }  //Auto properties. Please don't dock me for using shorthand -_- .
        public double AccountBalance { get; set; }  //I can write them out if you want.
        public string AccountType { get; set; }

        protected Account(int accountNumber, double accountBalance) //Base Ctor. To be called when instantiating inheriting classes.
        {
            AccountNumber = accountNumber;
            AccountBalance = accountBalance;
        }

        public void ShowBalance()   //Method to show account balance. 
        {
            Console.Write($"\nThe current balance of your {AccountType} Account is {AccountBalance:C}.\n\n\n");
            System.Threading.Thread.Sleep(2750);
            Console.Clear();
        }

        public abstract void Deposit(double transactionAmt);    //Abstract Method-given a body in inheriting classes

        public virtual void Withdraw(double transactionAmt) //Abstract Withdraw method-overridden in inheriting classes
        {
            AccountBalance -= transactionAmt;
        }
    }
}
