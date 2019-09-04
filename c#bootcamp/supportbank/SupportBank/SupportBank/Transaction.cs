using System;

public class Transaction
{
    public string date;
    public string to;
    public string from;
    public string narrative;
    public decimal amount;

	public Transaction(string date, string to, string from, string narrative, decimal amount)
    {
        this.date = date;
        this.to = to;
        this.from = from;
        this.narrative = narrative;
        this.amount = amount;
    }

    public override string ToString()
    {
        return "Date: " + date + " To: " + to + " From: " + from + " Amount: " + amount;
    }
}
