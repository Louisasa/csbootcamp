using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;


namespace SupportBank
{

    public class Program
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public static void Main(string[] args)
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;

            Console.WriteLine("Please input name of file.");
            var fileName = Console.ReadLine();

            var transactionsList = BankFileReader.GetTransactions(fileName);

            if (transactionsList != null)
            {
                var bank = new Bank();

                bank.AddToBank(transactionsList);


                Console.WriteLine("Please input all or user name for account info.");
                var input = Console.ReadLine();

                if (input.ToLower() == "all")
                {
                    OutputAllAccounts(bank);
                }
                else
                {
                    OutputOnePersonsTransactions(bank, input.ToLower());
                }
            }
            else
            {
                Console.WriteLine("Please input a valid filename");
            }

            Console.ReadLine();
        }

        private static void OutputAllAccounts(Bank bank)
        {
            var accountsInfo = bank.OutputAllAccounts();
            PrintAccountsInfo(accountsInfo);
        }

        private static void OutputOnePersonsTransactions(Bank bank, string personName)
        {
            var resultTransactions = bank.GetPersonsTransactions(personName);

            Console.WriteLine(personName+":");
            foreach (var transaction in resultTransactions)
            {
                Console.WriteLine("Date: " + transaction.Date + " ToAccount: " + transaction.ToAccount + " FromAccount: " + transaction.FromAccount + " Narrative: " + transaction.Narrative + " Amount: " + transaction.Amount);
            }
        }

        private static void PrintAccountsInfo(Dictionary<string, decimal> accountsInfo)
        {
            foreach (var entry in accountsInfo)
            {
                Console.WriteLine(entry.Key + " is owed " + entry.Value);
            }
        }
    }
}
