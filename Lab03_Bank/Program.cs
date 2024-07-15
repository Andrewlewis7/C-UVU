using System;

namespace UVUBank
{
    /// <summary>
    /// Main program to test the Account classes and AccountManager
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            AccountManager accountManager = new AccountManager();

            Console.WriteLine("Enter account details for Savings Account:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Initial Balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            IAccount savingsAccount = new SavingsAccount(name, address, balance);
            accountManager.StoreAccount(savingsAccount);

            Console.WriteLine("\nEnter account details for Checking Account:");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Address: ");
            address = Console.ReadLine();
            Console.Write("Initial Balance: ");
            balance = decimal.Parse(Console.ReadLine());

            IAccount checkingAccount = new CheckingAccount(name, address, balance);
            accountManager.StoreAccount(checkingAccount);

            Console.WriteLine("\nEnter account details for CD Account:");
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Address: ");
            address = Console.ReadLine();
            Console.Write("Initial Balance: ");
            balance = decimal.Parse(Console.ReadLine());

            IAccount cdAccount = new CDAccount(name, address, balance);
            accountManager.StoreAccount(cdAccount);

            Console.WriteLine("\nEnter name to search for an account:");
            string searchName = Console.ReadLine();
            IAccount foundAccount = accountManager.FindAccount(searchName);
            if (foundAccount != null)
            {
                Console.WriteLine($"Account found: {foundAccount.GetName()}, {foundAccount.GetAddress()}, {foundAccount.GetAccountNumber()}, Balance: {foundAccount.GetBalance()}, Type: {foundAccount.GetAccountType()}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }
}

