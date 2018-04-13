using System;

namespace UnitTestFluentAssertion
{
    public class BankAccount
    {
        private double balance;

        private bool frozen = false;

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public double Balance
        {
            get { return balance; }
        }

        public void Debit(double amount)
        {
            if (frozen)
                throw new Exception("Account frozen");

            if (amount > balance)
                throw new ArgumentOutOfRangeException("Not enough balance.");

            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount should be bigger than zero.");

            balance -= amount;
        }

        public void Credit(double amount)
        {
            if (frozen)
                throw new Exception("Account frozen");

            if (amount < 0)
                throw new ArgumentOutOfRangeException("Amount should be bigger than zero.");

            balance += amount;
        }

        public void FreezeAccount()
        {
            frozen = true;
        }

        public void UnfreezeAccount()
        {
            frozen = false;
        }
    }
}
