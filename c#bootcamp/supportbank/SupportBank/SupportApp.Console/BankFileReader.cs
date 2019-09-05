using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using SupportApp.Console.Transaction_Files;

public class BankFileReader
{
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
    public List<Transaction> GetTransactions(string fileName)
    {
        if (fileName.EndsWith(".csv"))
        {
            CsvConverter csvConverter = new CsvConverter();
            return csvConverter.CsvToTransactionList(new StreamReader(File.OpenRead(
                "C:/Users/LouNas/c#bootcamp/supportbank/SupportBank/SupportApp.Console/Transaction Files/" + 
                fileName)));

        }
        else if (fileName.EndsWith(".json"))
        {
            List<JsonTransaction> jsonTransactions = JsonConvert.DeserializeObject<List<JsonTransaction>>(File.ReadAllText(
                "C:/Users/LouNas/c#bootcamp/supportbank/SupportBank/SupportApp.Console/Transaction Files/" + 
                fileName));
            return jsonTransactions.Select(transaction => transaction.ToTransaction()).ToList();
        }
        else if (fileName.EndsWith(".xml"))
        {
            StreamReader reader = new StreamReader(File.OpenRead(
                "C:/Users/LouNas/c#bootcamp/supportbank/SupportBank/SupportApp.Console/Transaction Files/" +
                fileName));
            XmlSerializer serializer = new XmlSerializer(typeof(XmlTransactionList));
            XmlTransactionList xmlTransactions = (XmlTransactionList)serializer.Deserialize(reader);
            var result = xmlTransactions.ToTransaction();

            return result;
        }
        else
        {
            return null;
        }
    }
}
