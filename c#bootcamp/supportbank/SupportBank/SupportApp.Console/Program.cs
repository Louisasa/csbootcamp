﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.ServiceModel.Channels;
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
            CreateLoggerConfig();

            var bank = new Bank();
            var bankFileReader = new BankFileReader();
            var consoleProcess = new ConsoleProcess();

            ReadInNewFile(bank, bankFileReader, consoleProcess);

            while (true)
            {
                var userOption = consoleProcess.GetUserOption();

                if (userOption == 1)
                {
                    ReadInNewFile(bank, bankFileReader, consoleProcess);
                }
                else if (userOption == 2)
                {
                    var input = consoleProcess.GetUser();
                    ProcessUserRequest(input, bank, consoleProcess);
                }
                else
                {
                    break;
                }
            }

            Console.ReadLine();
        }

        private static void CreateLoggerConfig()
        {
            var config = new LoggingConfiguration();
            var target = new FileTarget { FileName = @"SupportBank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
            config.AddTarget("File Logger", target);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
            LogManager.Configuration = config;
        }

        private static void ReadInNewFile(Bank bank, BankFileReader bankFileReader, ConsoleProcess consoleProcess)
        {
            var fileName = consoleProcess.GetFileName();
            var transactionsList = bankFileReader.GetTransactions(fileName);
            AddNonNullTransactionsToBank(bank, transactionsList);
        }

        private static void ProcessUserRequest(string input, Bank bank, ConsoleProcess consoleProcess)
        {
            if (input.ToLower() == "all")
            {
                var accountsInfo = bank.GetAllAccounts();
                consoleProcess.OutputAllAccounts(accountsInfo);
            }
            else
            {
                consoleProcess.OutputOnePersonsTransactions(bank, input.ToLower());
            }
        }

        private static void AddNonNullTransactionsToBank(Bank bank, List<Transaction> transactionsList)
        {
            if (transactionsList != null)
            {
                bank.AddToBank(transactionsList);
            }
            else
            {
                Console.WriteLine("Please input a valid filename");
            }
        }
    }
}
