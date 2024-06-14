using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    public class CheckingAccount : IAccount
    {
        public double m_balance;
        public CheckingAccount(double initialBalance)
        {
            m_balance = initialBalance;
        }
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive!", nameof(amount));
            }
            m_balance += amount;
        }

        public double GetBalance()
        {
            return m_balance;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive!", nameof(amount));
            }

            if (m_balance >= amount)
            {
                m_balance -= amount;
            }
            else
            {
                throw new ArgumentException("Withdrawal exceeds balance!", nameof(amount));
            }
        }
    }
}
