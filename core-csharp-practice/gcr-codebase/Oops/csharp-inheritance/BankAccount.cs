using System;

class BankAccount
{
    public int AccountNumber;
    public double Balance;

    public BankAccount(int accountNumber, double balance)
    {
        AccountNumber = accountNumber;
        Balance = balance;
    }
}

class SavingsAccount : BankAccount
{
    public double InterestRate;

    public SavingsAccount(int accountNumber, double balance, double interestRate)
        : base(accountNumber, balance)
    {
        InterestRate = interestRate;
    }

    public void DisplayAccountType()
    {
        Console.WriteLine("Savings Account");
    }
}

class CheckingAccount : BankAccount
{
    public int WithdrawalLimit;

    public CheckingAccount(int accountNumber, double balance, int withdrawalLimit)
        : base(accountNumber, balance)
    {
        WithdrawalLimit = withdrawalLimit;
    }

    public void DisplayAccountType()
    {
        Console.WriteLine("Checking Account");
    }
}

class FixedDepositAccount : BankAccount
{
    public int Tenure;

    public FixedDepositAccount(int accountNumber, double balance, int tenure)
        : base(accountNumber, balance)
    {
        Tenure = tenure;
    }

    public void DisplayAccountType()
    {
        Console.WriteLine("Fixed Deposit Account");
    }
}

class BankTest
{
    static void Main()
    {
        SavingsAccount s = new SavingsAccount(101, 5000, 4.5);
        CheckingAccount c = new CheckingAccount(102, 3000, 5);
        FixedDepositAccount f = new FixedDepositAccount(103, 10000, 24);

        s.DisplayAccountType();
        c.DisplayAccountType();
        f.DisplayAccountType();
    }
}
