using System;
using System.Collections.Generic;

public class Bank
{

    private List<Account> allAccounts;
    private List<Transaction> allTransactions;

    public List<Account> CreateAccounts(List<Transaction> transactionList)
    {
        List<Account> accountsList = new List<Account>();
        List<string> accountNamesList = new List<string>();
        foreach (Transaction transaction in transactionList)
        {
            if (!accountNamesList.Contains(transaction.To))
            {
                Account account = new Account(transaction.To, transaction.Amount);
                accountNamesList.Add(account.Name);
                accountsList.Add(account);
            }
            else
            {
                accountsList[accountNamesList.IndexOf(transaction.To)].changeBalance(transaction.Amount);
            }

            if (!accountNamesList.Contains(transaction.From))
            {
                Account account = new Account(transaction.From, transaction.Amount);
                accountNamesList.Add(account.Name);
                accountsList.Add(account);
            }
            else
            {
                accountsList[accountNamesList.IndexOf(transaction.From)].changeBalance(transaction.Amount);
            }
        }

        allAccounts = accountsList;
        allTransactions = transactionList;

        return accountsList;
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
        List<Transaction> resultTransactions = new List<Transaction>();
        foreach (Transaction transaction in allTransactions)
        {
            if (transaction.From == personName || transaction.To == personName)
            {
                resultTransactions.Add(transaction);
            }
        }

        return resultTransactions;
    }
}
