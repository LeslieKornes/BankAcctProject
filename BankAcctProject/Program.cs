using System.Collections.Generic;

namespace BankAcctProject
{
    class Program
    {
        static void Main()  //Main-tried to keep it as tidy as possible
        {
            int userChoice; //Declaring this int for us to use in our do-while loop that contains entire program

            var client = new Client("Rocky Balboa", "11115 Lake Ave.\n\tCleveland, OH  44102",
                "ItalianStallion@gmail.com") {Accounts = GetAccounts()};    //Instantiating client and using object initializer to 
                                                                            //populate the accounts using our helper method
            UserInteraction.GreetUser(client);

            do
            {
                userChoice = UserInteraction.PromptClientForChoice(client); //Prompts user to select an option
                UserInteraction.ExecuteUserChoice(client, userChoice);  //Will execute user choice in UserInteraction class

            } while (userChoice != 5);  //Loop breaks when user selects 5 to quit
        }

        private static List<Account> GetAccounts()  //helper method to populate client accounts.
        {
            return new List<Account>()
            {
                new CheckingAccount(102710, 9431.34),   //checking account linked to client
                new SavingsAccount(102711, 4377.92)     //savings ""    ""  "" with account number and balances populated.
            };
        }
    }
}
