using System;
using System.Collections.Generic;
using System.Linq;

public class Bank
{

    private List<Account> allAccounts = new List<Account>();
    private List<Transaction> allTransactions = new List<Transaction>();

    public void AddAccounts(List<Transaction> transactionList)
    {
        List<string> accountNamesList = new List<string>();
        foreach (Transaction transaction in transactionList)
        {
            if (!accountNamesList.Contains(transaction.To))
            {
                Account account = new Account(transaction.To, transaction.Amount);
                accountNamesList.Add(account.Name);
                allAccounts.Add(account);
            }
            else
            {
                allAccounts[accountNamesList.IndexOf(transaction.To)].changeBalance(transaction.Amount);
            }

            if (!accountNamesList.Contains(transaction.From))
            {
                Account account = new Account(transaction.From, transaction.Amount);
                accountNamesList.Add(account.Name);
                allAccounts.Add(account);
            }
            else
            {
                allAccounts[accountNamesList.IndexOf(transaction.From)].changeBalance(transaction.Amount);
            }
        }

        allTransactions.AddRange(transactionList);
    }

    public Dictionary<string, decimal> OutputAllAccounts()
    {
        Dictionary<string, decimal> accountsInfo = new Dictionary<string, decimal>();
        foreach (Account account in allAccounts)
        {
            accountsInfo[account.Name] = account.Balance;
        }

        return accountsInfo;
    }

    public List<Transaction> GetPersonsTransactions(string personName)
    {
        return allTransactions.Where(transaction => transaction.From == personName || transaction.To == personName).ToList();
    }
}
