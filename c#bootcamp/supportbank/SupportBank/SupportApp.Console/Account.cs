using System;

public class Account
{
    public string Name;
    public decimal Balance;

	public Account(string name, decimal balance)
    {
        this.Name = name;
        this.Balance = balance;
    }

    public Account(string name)
    {
        this.Name = name;
    }

    public void changeBalance(decimal amountToChangeBy)
    {
        this.Balance += amountToChangeBy;
    }
}
