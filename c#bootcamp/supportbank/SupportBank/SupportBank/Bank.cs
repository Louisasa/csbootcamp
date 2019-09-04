using System;
using System.Collections.Generic;

namespace SupportBank
{
    public class Bank
    {

        public static List<Account> CreateAccounts(List<Transaction> transactionList)
        {
            List<Account> accountsList = new List<Account>();
            List<string> accountNamesList = new List<string>();
            foreach (Transaction transaction in transactionList)
            {
                if (!accountNamesList.Contains(transaction.To))
                {
                    Account account = new Account(transaction.To, transaction.Amount);
                }
                else
                {
                    accountsList[accountNamesList.IndexOf(transaction.To)].changeBalance(transaction.Amount);
                }

                if (!accountNamesList.Contains(transaction.From))
                {
                    Account account = new Account(transaction.From, transaction.Amount);
                }
                else
                {
                    accountsList[accountNamesList.IndexOf(transaction.From)].changeBalance(transaction.Amount);
                }
            }

            return accountsList;
        }

        public static Dictionary<string, decimal> OutputAllAccounts(List<Account> allAccounts)
        {
            Dictionary<string, decimal> accountsInfo = new Dictionary<string, decimal>();
            foreach (Account account in allAccounts)
            {
                accountsInfo[account.Name] = account.Balance;
            }

            return accountsInfo;
        }
        public static Dictionary<string, decimal> OutputOneAccount(List<Account> allAccounts, string personName)
        {
            decimal total = 0;
            foreach (Account account in allAccounts)
            {
                if (account.Name == personName)
                {
                    total = account.Balance;
                }
            }
            return new Dictionary<string, decimal>() {{personName, total}};
        }
    }
}
