using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class BankFileReader
{
    public static Dictionary<string, Transaction> CreateTransactionDictionary(string fileName)
    {
    StreamReader reader = new StreamReader(File.OpenRead("C:/Users/LouNas/c#bootcamp/supportbank/SupportBank/SupportBank/" + fileName));
    var line = reader.ReadLine();
    var values = line.Split(',');
    var headers = Enumerable.Range(0, values.Length).ToDictionary(i => values[i], i => i);
    Dictionary<string, Transaction> transactionDictionary = new Dictionary<string, Transaction>();
        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            values = line.Split(',');

            var transactionList = new List<String>();

            string date = values[headers["Date"]].ToLower();
            string to = values[headers["To"]].ToLower();
            string from = values[headers["From"]].ToLower();
            decimal amount = decimal.Parse(values[headers["Amount"]]);
            string narrative = values[headers["Narrative"]].ToLower();

            var transactionName = from + " To " + to;

            transactionDictionary[transactionName] = new Transaction(date, to, from, narrative, amount);
        }

        return transactionDictionary;
    }
}
