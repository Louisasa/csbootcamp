using System;
using System.Collections.Generic;
using System.Linq;
using NLog;

public class Bank
{

    private readonly List<Account> _allAccounts = new List<Account>();
    private readonly List<Transaction> _allTransactions = new List<Transaction>();
    private static readonly ILogger logger = LogManager.GetCurrentClassLogger();
    
    public void AddToBank(List<Transaction> transactionList)
    {
        List<string> accountNamesList = new List<string>();
        foreach (Transaction transaction in transactionList)
        {
            if (!accountNamesList.Contains(transaction.ToAccount))
            {
                Account account = new Account(transaction.ToAccount, transaction.Amount);
                accountNamesList.Add(account.Name);
                _allAccounts.Add(account);
            }
            else
            {
                _allAccounts[accountNamesList.IndexOf(transaction.ToAccount)].ChangeBalance(transaction.Amount);
            }

            if (!accountNamesList.Contains(transaction.FromAccount))
            {
                Account account = new Account(transaction.FromAccount, transaction.Amount);
                accountNamesList.Add(account.Name);
                _allAccounts.Add(account);
            }
            else
            {
                _allAccounts[accountNamesList.IndexOf(transaction.FromAccount)].ChangeBalance(-transaction.Amount);
            }
        }

        _allTransactions.AddRange(transactionList);
    }

    public Dictionary<string, decimal> OutputAllAccounts()
    {
        Dictionary<string, decimal> accountsInfo = new Dictionary<string, decimal>();
        foreach (Account account in _allAccounts)
        {
            accountsInfo[account.Name] = account.Balance;
        }

        return accountsInfo;
    }

    public List<Transaction> GetPersonsTransactions(string personName)
    {
        return _allTransactions.Where(transaction => transaction.FromAccount.ToLower() == personName || transaction.ToAccount.ToLower() == personName).ToList();
    }
}
