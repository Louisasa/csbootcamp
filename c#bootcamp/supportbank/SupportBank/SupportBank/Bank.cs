using System;
using System.Collections.Generic;

namespace SupportBank
{
    public class Bank
    {

        public static void Main(string[] args)
        {
            Dictionary<string, Transaction> transactionDictionary = BankFileReader.CreateTransactionDictionary("Transactions2014.csv");

            Console.WriteLine("Please input all or user name for account info.");
            string input = Console.ReadLine();
            if (input.ToLower() == "all")
            {
                outputAllTransactions(transactionDictionary);
            }
            else
            {
                outputOneTransaction(transactionDictionary, input.ToLower());
            }
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
                        decimal total = totalOwed(transactionDictionary, name);

                        Console.WriteLine(name + " is owed " + total);
                    }
                }
            }
        }

        private static void outputOneTransaction(Dictionary<string, Transaction> trasactionDictionary,
            string personName)
        {
            decimal total = totalOwed(trasactionDictionary, personName);
            Console.WriteLine(personName + " is owed " + total);
        }

        private static decimal totalOwed(Dictionary<string, Transaction> transactionDictionary, string personName)
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

                return totalOwed;
            }

            return 0;
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
