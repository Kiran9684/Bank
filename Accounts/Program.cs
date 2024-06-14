using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounts
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of AccountInfo
            var accountInfo = new AccountInfo(12345, "John Doe", 1000.0);

            // Create an instance of CheckingAccount with an initial balance
            var checkingAccount = new CheckingAccount(accountInfo.Balance);

            // Display initial balance
            Console.WriteLine($"Initial Balance: {checkingAccount.GetBalance()}");

            // Deposit money
            checkingAccount.Deposit(500.0);
            Console.WriteLine($"Balance after deposit: {checkingAccount.GetBalance()}");

            // Attempt to withdraw money
            try
            {
                checkingAccount.Withdraw(200.0);
                Console.WriteLine($"Balance after withdrawal: {checkingAccount.GetBalance()}");

                checkingAccount.Withdraw(1500.0); // This will throw an exception
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            // Final balance
            Console.WriteLine($"Final Balance: {checkingAccount.GetBalance()}");
        }
    }
}
