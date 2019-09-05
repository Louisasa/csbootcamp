using System;

public class Transaction
{
    public string Date;
    public string ToName;
    public string FromName;
    public string Narrative;
    public decimal Amount;

	public Transaction(string date, string toName, string fromName, string narrative, decimal amount)
    {
        this.Date = date;
        this.ToName = toName;
        this.FromName = fromName;
        this.Narrative = narrative;
        this.Amount = amount;
    }

    public override string ToString()
    {
        return Date + " " + " " + ToName + " " + " " + FromName + " " + " " + Narrative + " " + " " + Amount;
    }
}
