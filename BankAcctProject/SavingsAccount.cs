using System;

namespace BankAcctProject
{
    class SavingsAccount : Account
    {
        public int MinBalance { get; set; } //Savings account property (was in requirements, but I added it in checking as well)

        public SavingsAccount(int accountNumber, double accountBalance) : base(accountNumber, accountBalance)   //Ctor
        {
            AccountType = "Savings";    //Assigning accountType and minBal
            MinBalance = 250;
        }

        public override void Withdraw(double transactionAmt)    //Overridden Withdraw method
        {
            if ((AccountBalance - transactionAmt) < MinBalance)
            {
                Console.WriteLine($"Unfortunately, we cannot process your withdrawal. Your savings account balance would be lower than " +
                                  $"the minimum balance ({MinBalance:c}).");
            }
            else
            {
                Console.WriteLine($"You are withdrawing {transactionAmt:c} from your savings account number {AccountNumber}.");
                base.Withdraw(transactionAmt);  //Calling functionality from base virtual method
            }
        }

        public override void Deposit(double transactionAmt) //Overridden Deposit method
        {                                                   
            Console.WriteLine($"You are depositing {transactionAmt:c} into your savings account number {AccountNumber}.");
            AccountBalance += transactionAmt;
        }
    }
}
