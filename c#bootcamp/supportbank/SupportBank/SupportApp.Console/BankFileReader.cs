using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;

public class BankFileReader
{
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
    public List<Transaction> GetTransactions(string fileName)
    {
        if (fileName.EndsWith(".csv"))
        {
            CsvConvert csvConverter = new CsvConvert();
            return csvConverter.CsvToTransactionList(new StreamReader(File.OpenRead("C:/Users/LouNas/c#bootcamp/supportbank/SupportBank/SupportApp.Console/" + fileName)));

        }
        else if (fileName.EndsWith(".json"))
        {
            return JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText("C:/Users/LouNas/c#bootcamp/supportbank/SupportBank/SupportApp.Console/" + fileName));
        }
        else
        {
            return null;
        }
    }
}
