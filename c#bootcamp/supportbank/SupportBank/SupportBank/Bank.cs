using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;

namespace SupportBank
{
    public class Bank
    {
        private static Dictionary<string, int> _headers;

        public static void Main(string[] args)
        {
            StreamReader reader = readInFile();
            Dictionary<string, Transaction> transactionDictionary = createTransactionDictionary(reader);

            Console.WriteLine("Please input all or user name for account info.");
            string input = Console.ReadLine();
            if (input.ToLower() == "all")
            {
                outputAllTransactions(transactionDictionary);
            }
            else
            {
                totalOwed(transactionDictionary, input.ToLower());
            }
        }

        private static StreamReader readInFile()
        {
            var reader = new StreamReader(File.OpenRead("C:/Users/LouNas/c#bootcamp/supportbank/SupportBank/SupportBank/Transactions2014.csv"));
            var line = reader.ReadLine();
            var values = line.Split(',');
            _headers = Enumerable.Range(0, values.Length).ToDictionary(i => values[i], i => i);

            return reader;
        }

        private static Dictionary<string, Transaction> createTransactionDictionary(StreamReader reader)
        {
            Dictionary<string, Transaction> transactionDictionary = new Dictionary<string, Transaction>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var transactionList = new List<String>();

                string date = values[_headers["Date"]].ToLower();
                string to = values[_headers["To"]].ToLower();
                string from = values[_headers["From"]].ToLower();
                decimal amount = decimal.Parse(values[_headers["Amount"]]);
                string narrative = values[_headers["Narrative"]].ToLower();

                var transactionName = from + " To " + to;

                transactionDictionary[transactionName] = new Transaction(date, to, from, narrative, amount);
            }

            return transactionDictionary;
        }

        private static void outputAllTransactions(Dictionary<string, Transaction> transactionDictionary)
        {
            List<string> namesAlreadyDone = new List<string>();
            foreach (KeyValuePair<string, Transaction> entry in transactionDictionary)
            {
                string[] namesInvolvedInTransaction = entry.Key.Split(new string[] { " To " }, StringSplitOptions.None);
                foreach (string name in namesInvolvedInTransaction)
                {
                    if (!namesAlreadyDone.Contains(name))
                    {
                        namesAlreadyDone.Add(name);
                        totalOwed(transactionDictionary, name);
                    }
                }
            }
        }

        private static void totalOwed(Dictionary<string, Transaction> transactionDictionary, string personName)
        {
            List<Transaction> transactionDetails = findTransactionDetails(transactionDictionary, personName);

            if (transactionDetails != null)
            {

                decimal totalOwed = 0;
                foreach (Transaction transaction in transactionDetails)
                {
                    if (transaction.to == personName)
                    {
                        totalOwed += transaction.amount;
                    }
                    else if (transaction.from == personName)
                    {
                        totalOwed -= transaction.amount;
                    }
                }

                Console.WriteLine(personName + " is owed: " + totalOwed);
            }
        }

        private static List<Transaction> findTransactionDetails(Dictionary<string, Transaction> transactionDictionary, string person)
        {
            List<Transaction> resultList = new List<Transaction>();
            foreach (KeyValuePair<string, Transaction> entry in transactionDictionary)
            {
                if (entry.Key.Contains(person))
                {
                    resultList.Add(entry.Value);
                }
            }

            if (resultList.Count == 0)
            {
                Console.WriteLine("Please input a valid name.");
                return null;
            }

            return resultList;
        }
    }
}
