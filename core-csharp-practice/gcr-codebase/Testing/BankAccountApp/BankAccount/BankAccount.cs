using System;

namespace BankAccount
{
    public class BankAccount
    {
        private double _balance;

        public BankAccount(double initialBalance = 0)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");
            _balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");
            if (_balance < amount)
                throw new InvalidOperationException("Insufficient funds.");
            _balance -= amount;
        }

        public double GetBalance()
        {
            return _balance;
        }
    }
}
