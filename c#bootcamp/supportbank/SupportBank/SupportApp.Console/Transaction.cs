using System;

public class Transaction
{
    public string Date;
    public string ToAccount;
    public string FromAccount;
    public string Narrative;
    public decimal Amount;

	public Transaction(string date, string toAccount, string fromAccount, string narrative, decimal amount)
    {
        this.Date = date;
        this.ToAccount = toAccount;
        this.FromAccount = fromAccount;
        this.Narrative = narrative;
        this.Amount = amount;
    }
}
