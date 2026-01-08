using System;

interface ILoanable
{
    void ApplyForLoan();
    double CalculateLoanEligibility();
}

abstract class BankAccount
{
    private string accountNumber;
    protected double balance;

    protected BankAccount(string accNo, double balance)
    {
        accountNumber = accNo;
        this.balance = balance;
    }

    public void Deposit(double amount)
    {
        balance += amount;
    }

    public abstract double CalculateInterest();
}

class SavingsAccount : BankAccount
{
    public SavingsAccount(string accNo, double balance)
        : base(accNo, balance) { }

    public override double CalculateInterest()
    {
        return balance * 0.04;
    }
}

class BankingSystem
{
    static void Main()
    {
        BankAccount account = new SavingsAccount("SB101", 50000);
        Console.WriteLine("Interest: " + account.CalculateInterest());
    }
}
