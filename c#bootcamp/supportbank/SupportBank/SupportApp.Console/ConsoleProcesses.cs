using System;
using System.Collections.Generic;

public class ConsoleProcess
{
    public string GetFileName()
    {
        Console.WriteLine("Please input name of file.");
        return Console.ReadLine();
    }

    public string GetUser()
    {
        Console.WriteLine("Please input all or user name for account info.");
        return Console.ReadLine();
    }

    public int GetUserOption()
    {
        Console.WriteLine("To add another file, type 1.");
        Console.WriteLine("To request user information, type 2.");
        Console.WriteLine("To export to file, type 3.");
        Console.WriteLine("To close requests, type 4.");
        var input = Console.ReadLine();
        bool successfullyParsed = int.TryParse(input, out var result);
        if (!successfullyParsed)
        {
            Console.WriteLine("Please return an int");
            return GetUserOption();
        }
        else
        {
            return result;
        }
    }

    public void OutputOnePersonsTransactions(List<Transaction> resultTransactions, string personName)
    {
        Console.WriteLine(personName + ":");
        foreach (var transaction in resultTransactions)
        {
            Console.WriteLine("Date: " + transaction.Date + " ToName: " + transaction.ToName + " FromName: " + transaction.FromName + " Narrative: " + transaction.Narrative + " Amount: " + transaction.Amount);
        }
    }

    public void OutputAllAccounts(Dictionary<string, decimal> accountsInfo)
    {
        foreach (var entry in accountsInfo)
        {
            Console.WriteLine(entry.Key + " is owed " + entry.Value);
        }
    }
}
