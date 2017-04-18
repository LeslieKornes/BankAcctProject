using System;

namespace BankAcctProject
{
    class CheckingAccount : Account
    {
        public int MinBalance { get; set; } //Auto property for checking account
        public int TransactionFee { get; set; } //Auto prop for transaction fee

        public CheckingAccount(int accountNumber, double accountBalance) : base(accountNumber, accountBalance)  //Ctor using base ctor 
        {                                                                                                       //functionality
            AccountType = "Checking";   //Additionally setting these properties here
            MinBalance = 5;
            TransactionFee = 2;
        }

        public override void Withdraw(double transactionAmt)    //Overriding the base Withdraw method
        {
            transactionAmt += TransactionFee;
            if ((AccountBalance - transactionAmt) < MinBalance)
            {
                Console.WriteLine("Unfortunately, we cannot process your withdrawal. Your checking account balance would be lower than " +
                                  "the minimum balance allowed ($ 5.00).");
            }
            else
            {
                Console.WriteLine($"Including the {TransactionFee:c} transaction fee, you are withdrawing {transactionAmt:c} from " +
                                  $"your checking account number {AccountNumber}.");
                base.Withdraw(transactionAmt);  //Still using base functionality
            }
        }

        public override void Deposit(double transactionAmt) //Overriding the abstract Deposit method
        {
            Console.WriteLine($"You are depositing {transactionAmt:c} into your checking account number {AccountNumber}.");
            AccountBalance += transactionAmt;
        }
    }
}
