using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportApp.Console.Transaction_Files
{
    public class JsonTransaction
    {
        public string Date;
        public string ToAccount;
        public string FromAccount;
        public string Narrative;
        public decimal Amount;

        public JsonTransaction(string date, string toAccount, string fromAccount, string narrative, decimal amount)
        {
            this.Date = date;
            this.ToAccount = toAccount;
            this.FromAccount =fromAccount;
            this.Narrative = narrative;
            this.Amount = amount;
        }

        public Transaction ToTransactions()
        {
            return new Transaction(Date, ToAccount, FromAccount, Narrative, Amount);
        }
    }
}
