using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using SupportApp.Console.BankInfo;

public class Bank
{

    private readonly List<Account> _allAccounts = new List<Account>();
    private readonly List<Transaction> _allTransactions = new List<Transaction>();
    List<string> accountNamesList = new List<string>();
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
    
    public void AddToBank(List<Transaction> transactionList)
    {
        foreach (Transaction transaction in transactionList)
        {
            if (!accountNamesList.Contains(transaction.ToName.ToLower()))
            {
                Account account = new Account(transaction.ToName.ToLower(), transaction.Amount);
                accountNamesList.Add(account.Name);
                _allAccounts.Add(account);
            }
            else
            {
                _allAccounts[accountNamesList.IndexOf(transaction.ToName.ToLower())].ChangeBalance(transaction.Amount);
            }

            if (!accountNamesList.Contains(transaction.FromName.ToLower()))
            {
                Account account = new Account(transaction.FromName.ToLower(), transaction.Amount);
                accountNamesList.Add(account.Name);
                _allAccounts.Add(account);
            }
            else
            {
                _allAccounts[accountNamesList.IndexOf(transaction.FromName.ToLower())].ChangeBalance(-transaction.Amount);
            }
        }

        _allTransactions.AddRange(transactionList);
    }

    public Dictionary<string, decimal> GetAllAccounts()
    {
        return _allAccounts.ToDictionary(a => a.Name, a => a.Balance);
    }

    public List<Transaction> GetPersonsTransactions(string personName)
    {
        return _allTransactions.Where(transaction => transaction.FromName.ToLower() == personName || transaction.ToName.ToLower() == personName).ToList();
    }
}
