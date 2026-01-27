using NUnit.Framework;
using System;

namespace BankAccount.Tests
{
    public class BankAccountTests
    {
        private BankAccount _account;

        [SetUp]
        public void Setup()
        {
            _account = new BankAccount(100);
        }

        [Test]
        public void Deposit_ShouldIncreaseBalance()
        {
            _account.Deposit(50);
            Assert.That(_account.GetBalance(), Is.EqualTo(150));
        }

        [Test]
        public void Withdraw_ShouldDecreaseBalance()
        {
            _account.Withdraw(50);
            Assert.That(_account.GetBalance(), Is.EqualTo(50));
        }

        [Test]
        public void Withdraw_InsufficientFunds_ShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _account.Withdraw(200));
        }

        [Test]
        public void Deposit_NegativeAmount_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _account.Deposit(-50));
        }

        [Test]
        public void Withdraw_NegativeAmount_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _account.Withdraw(-50));
        }
        
        [Test]
        public void NewAccount_NegativeInitialBalance_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(-100));
        }
    }
}
