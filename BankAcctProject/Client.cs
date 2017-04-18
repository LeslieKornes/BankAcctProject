using System;
using System.Collections.Generic;

namespace BankAcctProject
{
    public class Client
    {
        public string FullName { get; set; }    //Auto properties for Client
        public string Address { get; set; }
        public string Email { get; set; }
        public List<Account> Accounts { get; set; }

        public Client(string fullName, string address, string email)    //Client Ctor
        {
            FullName = fullName;
            Address = address;
            Email = email;
        }

        public void PrintClientInfo()   //Method that will print client info
        {
            Console.Clear();
            Console.WriteLine("*****CLIENT INFORMATION*****\n\n");
            Console.WriteLine($"Client Name: {FullName}");
            Console.WriteLine();
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine();
            Console.WriteLine($"Email: {Email}\n\n\n");
        }
    }
}
