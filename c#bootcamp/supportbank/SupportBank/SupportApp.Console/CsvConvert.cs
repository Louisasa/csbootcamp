using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class CsvConverter
{
    public List<Transaction> CsvToTransactionList(StreamReader reader)
    {
        var headers = GetHeaders(reader);

        if (headers.Count > 0)
        {
            return CreateTransactions(reader, headers);
        }
        else
        {
            return new List<Transaction>();
        }
    }

    private static Dictionary<string, int> GetHeaders(StreamReader reader)
    {
        var line = reader.ReadLine();
        var values = line?.Split(',');
        return Enumerable.Range(0, values.Length).ToDictionary(i => values[i], i => i);
    }

    private static List<Transaction> CreateTransactions(StreamReader reader, Dictionary<string, int> headers)
    {
        var transactionList = new List<Transaction>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');

            var date = values[headers["Date"]].ToLower();
            var to = values[headers["To"]].ToLower();
            var from = values[headers["From"]].ToLower();
            var narrative = values[headers["Narrative"]].ToLower();

            var successfullyParsed = decimal.TryParse(values[headers["Amount"]], out var amount);

            if (successfullyParsed)
            {
                transactionList.Add(new Transaction(date, to, from, narrative, amount));
            }
        }

        return transactionList;
    }
}
