using System;

public class Transaction
{
    public string Date;
    public string To;
    public string From;
    public string Narrative;
    public decimal Amount;

	public Transaction(string date, string to, string from, string narrative, decimal amount)
    {
        this.Date = date;
        this.To = to;
        this.From = from;
        this.Narrative = narrative;
        this.Amount = amount;
    }

    public override string ToString()
    {
        return "Date: " + Date + " To: " + To + " From: " + From + " Narrative: " + Narrative + " Amount: " + Amount;
    }
}
