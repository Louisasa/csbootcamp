using System;
using System.Collections.Generic;


namespace SupportBank
{

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Transaction> transactionsList = BankFileReader.GetTransactions("Transactions2014.csv");
            var bank = new Bank();

            bank.AddAccounts(transactionsList);

            Console.WriteLine("Please input all or user name for account info.");
            string input = Console.ReadLine();
            
            if (input.ToLower() == "all")
            {
                OutputAllAccounts(bank);
            }
            else
            {
                OutputOnePersonsTransactions(bank, input.ToLower());
            }

            
        }

        private static void OutputAllAccounts(Bank bank)
        {
            Dictionary<string, decimal> accountsInfo = bank.OutputAllAccounts();
            PrintAccountsInfo(accountsInfo);
        }

        private static void OutputOnePersonsTransactions(Bank bank, String personName)
        {
            List<Transaction> resultTransactions = bank.GetPersonsTransactions(personName);

            Console.WriteLine(personName+":");
            foreach (Transaction transaction in resultTransactions)
            {
                Console.WriteLine(transaction.ToString());
            }
        }

        private static void PrintAccountsInfo(Dictionary<string, decimal> accountsInfo)
        {
            foreach (KeyValuePair<string, decimal> entry in accountsInfo)
            {
                Console.WriteLine(entry.Key + " is owed " + entry.Value);
            }
        }
    }
}
