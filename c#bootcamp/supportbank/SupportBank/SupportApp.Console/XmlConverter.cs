using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

public class XmlConverter
{
    public List<Transaction> XmlToTransactionList(StreamReader reader)
    {
        List<string> headers = new List<string>(new string[] { "Date", "Description", "To", "From", "Value" });

        return CreateTransactions(reader, headers);

        //xml version line
        //transactionlist
        //supporttransactiondate (weird date format)
        //description
        //value
        //parties
        //from
        //to
        //end parties
        //end support transactions
    }

    private static List<Transaction> CreateTransactions(StreamReader reader, List<string> headers)
    {
        var transactionList = new List<Transaction>();
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            string values = line.Split('<', '>')[1];
            if (headers.Contains(values))
            {

            }
        }

        return transactionList;
    }
}
