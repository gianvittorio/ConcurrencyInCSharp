namespace DeadLock;

public class ATMDetails
{
    public double _balance;
    public int Id { get; }

    public ATMDetails(double balance, int id)
    {
        _balance = balance;
        Id = id;
    }

    public void WithDraw(double amount)
    {
        _balance -= amount;
    }

    public void Deposit(double amount)
    {
        _balance += amount;
    }
}