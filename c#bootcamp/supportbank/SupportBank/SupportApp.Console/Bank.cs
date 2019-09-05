using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

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
            if (!accountNamesList.Contains(transaction.ToAccount.ToLower()))
            {
                Account account = new Account(transaction.ToAccount.ToLower(), transaction.Amount);
                accountNamesList.Add(account.Name);
                _allAccounts.Add(account);
            }
            else
            {
                _allAccounts[accountNamesList.IndexOf(transaction.ToAccount.ToLower())].ChangeBalance(transaction.Amount);
            }

            if (!accountNamesList.Contains(transaction.FromAccount.ToLower()))
            {
                Account account = new Account(transaction.FromAccount.ToLower(), transaction.Amount);
                accountNamesList.Add(account.Name);
                _allAccounts.Add(account);
            }
            else
            {
                _allAccounts[accountNamesList.IndexOf(transaction.FromAccount.ToLower())].ChangeBalance(-transaction.Amount);
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
        return _allTransactions.Where(transaction => transaction.FromAccount.ToLower() == personName || transaction.ToAccount.ToLower() == personName).ToList();
    }
}
