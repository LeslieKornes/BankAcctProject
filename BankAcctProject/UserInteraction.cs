using System;
using System.Diagnostics;

namespace BankAcctProject
{
    class UserInteraction
    {
        public static void GreetUser(Client client) //Greeting user
        {
            Console.WriteLine($"Hello {client.FullName}\n");
        }

        public static int PromptClientForChoice(Client client)  //Prompts client for their choice. Calls the ShowMenu method and returns
        {                                                       //int that the user chose
            return ShowMenu();
        }

        private static int ShowMenu()   //Main options menu
        {
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. View Client Info");
            Console.WriteLine("2. View Account Balance");
            Console.WriteLine("3. Deposit Funds");
            Console.WriteLine("4. Withdraw Funds");
            Console.WriteLine("5. Exit");
            Console.WriteLine("\nPlease enter 1-5 for your selection!");

            string userInput = Console.ReadLine();
            while (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4" && userInput != "5" && userInput != null)
            {
                Console.WriteLine("That was not a valid selection. Please try again.");
                userInput = Console.ReadLine();
            }

            Debug.Assert(condition: userInput != null, message: $"userInput != null"); //Resharper prompted me to add this
            return int.Parse(userInput);
        }

        public static string PromptClientForAccount()   //Prompting user to choose checking or savings acct (per specs)
        {
            Console.WriteLine("\nWhich account would you like?\n");
            Console.WriteLine("a. for Checking Account");
            Console.WriteLine("b. for Savings Account");
            var acctSelected = Console.ReadLine();

            while (acctSelected != "a" && acctSelected != "b" && acctSelected != null)  //input verification
            {
                Console.WriteLine("That is not a valid account. Please try again.");
                acctSelected = Console.ReadLine();
            }

            return acctSelected;    //returns valid input
        }

        public static void ExecuteUserChoice(Client client, int userChoice) //The big method
        {
            if (userChoice == 1)    //user wants to see client info
            {
                client.PrintClientInfo();
            }
            else if (userChoice == 2)   //user wants to see balance
            {
                string acctSelection = PromptClientForAccount();    //balance of which account?
                if (acctSelection == "a")               //checking is selected
                {
                    client.Accounts[0].ShowBalance();   //displays checking account bal for user
                }
                else
                {
                    client.Accounts[1].ShowBalance();   //displays savings account bal for user
                }
            }
            else if (userChoice == 3)   //user would like to make a deposit
            {
                string acctSelection = PromptClientForAccount();    //to which account?
                double transactionAmt = PromptClientForAmount();    //in what amount?
                if (acctSelection == "a")               //checking is selected
                {
                    client.Accounts[0].Deposit(transactionAmt); //depositing chosen amount to checking account
                    client.Accounts[0].ShowBalance();   //displaying current balance after deposit per specs
                }
                else          //if not "a" for checking, then we know the user chose savings
                {
                    client.Accounts[1].Deposit(transactionAmt); //depositing chosen amount to savings
                    client.Accounts[1].ShowBalance();   //showing current balance after deposit
                }
            }
            else if (userChoice == 4)   //user wants to withdraw funds
            {
                string acctSelection = PromptClientForAccount();    //same functionality as above 
                double transactionAmt = PromptClientForAmount();
                if (acctSelection == "a")   //checking
                {
                    client.Accounts[0].Withdraw(transactionAmt);
                    client.Accounts[0].ShowBalance();
                }
                else                 //savings
                {
                    client.Accounts[1].Withdraw(transactionAmt);
                    client.Accounts[0].ShowBalance();
                }
            }
            else         //user has chosen 5 to quit
            {
                Console.WriteLine($"Thank you for banking with us today, {client.FullName}. Have a great Day!");
            }
        }
        
        private static double PromptClientForAmount()   //reusable method prompting user for amount whether it be w/d or deposit
        {
            double transactionAmount;
            Console.WriteLine("\nWhat is the desired amount for your transaction?");
            bool validAmount = double.TryParse(Console.ReadLine(), out transactionAmount);  //validating input
            if (!validAmount)
            {
                Console.WriteLine("That is not a valid transaction amount. Please enter the desired amount of your transaction.");
                transactionAmount = Convert.ToDouble(Console.ReadLine());
            }
            return transactionAmount;   //return input when it's been validated
        }
    }
}
