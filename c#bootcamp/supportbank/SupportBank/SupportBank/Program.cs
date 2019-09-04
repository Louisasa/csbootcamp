using System;
using System.Collections.Generic;
using SupportBank;

public class Program
{
    public static void Main(string[] args)
    {
        List<Transaction> transactionsList = BankFileReader.GetTransactions("Transactions2014.csv");

        List<Account> accountsList = Bank.CreateAccounts(transactionsList);

        Console.WriteLine("Please input all or user name for account info.");
        string input = Console.ReadLine();
        Dictionary<string, decimal> accountsInfo = new Dictionary<string, decimal>();
        if (input.ToLower() == "all")
        {
            accountsInfo = Bank.OutputAllAccounts(accountsList);
        }
        else
        {
            accountsInfo = Bank.OutputOneAccount(accountsList, input.ToLower());
        }

        printAccountsInfo(accountsInfo);
    }

    private static void printAccountsInfo(Dictionary<string, decimal> accountsInfo)
    {
        foreach (KeyValuePair<string, decimal> entry in accountsInfo)
        {
            Console.WriteLine(entry.Key + " is owed " + entry.Value);
        }
    }
}
