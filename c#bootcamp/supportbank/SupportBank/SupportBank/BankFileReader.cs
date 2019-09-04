using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BankFileReader
{
    public static List<Transaction> GetTransactions(string fileName)
    {
        StreamReader reader = new StreamReader(File.OpenRead("C:/Users/LouNas/c#bootcamp/supportbank/SupportBank/SupportBank/" + fileName));

        Dictionary<string, int> headers = GetHeaders(reader);

        return CreateTransactions(reader, headers);
    }

    private static Dictionary<string, int> GetHeaders(StreamReader reader)
    {
        var line = reader.ReadLine();
        var values = line.Split(',');
        return Enumerable.Range(0, values.Length).ToDictionary(i => values[i], i => i);
    }

    private static List<Transaction> CreateTransactions(StreamReader reader, Dictionary<string, int> headers)
    {
        var transactionList = new List<Transaction>();
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            string date = values[headers["Date"]].ToLower();
            string to = values[headers["To"]].ToLower();
            string from = values[headers["From"]].ToLower();
            decimal amount = decimal.Parse(values[headers["Amount"]]);
            string narrative = values[headers["Narrative"]].ToLower();

            transactionList.Add(new Transaction(date, to, from, narrative, amount));
        }

        return transactionList;
    }
}
