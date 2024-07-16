// Project Prolog
// Name: Andrew Lewis
// CS3260
// Project: Lab_04
// Date: 07/15/2024 
// Purpose: Program for creating various different types of bank accounts. 
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// ---------------------------------------------------------------------------
using System;

namespace UVUBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountManager = new AccountManager();

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter account type (Savings, Checking, CD): ");
                    var accountTypeInput = Console.ReadLine();
                    if (!Enum.TryParse(accountTypeInput, true, out AccountType accountType))
                    {
                        Console.WriteLine("Invalid account type. Please enter Savings, Checking, or CD.");
                        continue;
                    }

                    Console.WriteLine("Enter name: ");
                    var name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty.");
                        continue;
                    }

                    Console.WriteLine("Enter address: ");
                    var address = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(address))
                    {
                        Console.WriteLine("Address cannot be empty.");
                        continue;
                    }

                    Console.WriteLine("Enter starting balance: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal balance))
                    {
                        Console.WriteLine("Invalid balance. Please enter a numeric value.");
                        continue;
                    }

                    try
                    {
                        // Creates an account with the info provided. 
                        Account account = accountType switch
                        {
                            AccountType.Savings => new SavingsAccount(name, address, balance),
                            AccountType.Checking => new CheckingAccount(name, address, balance),
                            AccountType.CD => new CDAccount(name, address, balance),
                            _ => throw new ArgumentException("Invalid account type")
                        };

                        if (accountManager.StoreAccount(account))
                        {
                            Console.WriteLine($"Account for {name} created successfully with account number {account.GetAccountNumber()}.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to create account. Account may already exist.");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    Console.WriteLine("Do you want to search for an account? (yes/no): ");
                    var input = Console.ReadLine();
                    if (input.ToLower() == "yes")
                    {
                        Console.WriteLine("Enter account number to search: ");
                        var accountNumber = Console.ReadLine();
                        var foundAccount = accountManager.FindAccountByNumber(accountNumber);
                        if (foundAccount != null) 
                        {
                            Console.WriteLine($"Account found: {foundAccount.GetName()}, {foundAccount.GetAddress()}, {foundAccount.GetBalance()}, {foundAccount.GetAccountNumber()}, {foundAccount.GetAccountType()}, {foundAccount.GetServiceFee()}");
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                    }

                    Console.WriteLine("Do you want to continue? Must enter: (yes/no)");
                    var continueInput = Console.ReadLine();
                    if (continueInput.ToLower() != "yes") break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
