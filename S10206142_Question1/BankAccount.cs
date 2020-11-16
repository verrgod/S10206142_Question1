using System;
using System.Collections.Generic;
using System.Text;

namespace S10206142_Question1
{
    class BankAccount
    {
        private string accNo;

        public string AccNo
        {
            get { return accNo; }
            set { accNo = value; }
        }

        private string accName;

        public string AccName
        {
            get { return accName; }
            set { accName = value; }
        }

        private double balance;

        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public BankAccount() { }

        public BankAccount(string no, string name, double bal) 
        {
            accNo = no;
            accName = name;
            balance = bal;
        }
        public void Deposit(double amount)
        {
            balance += amount;
        }
        public bool Withdraw(double amount)
        {
            if (balance > amount)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return "Account Number: " + accNo + "," + "Account Name: " + accName + "," + "Balance: " + balance + ",";
        }
    }
    class SavingsAccount : BankAccount
    {
        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public SavingsAccount() { }

        public SavingsAccount(string no, string name, double bal, double r):base(no, name, bal)
        {
            AccNo = no;
            AccName = name;
            Balance = bal;
            Rate = r;
        }

        public double CalculateInterest()
        {
            return Balance * (rate / 100);
        }

        public override string ToString()
        {
            return base.ToString() + "Rate: " + rate;
        }
    }
}
