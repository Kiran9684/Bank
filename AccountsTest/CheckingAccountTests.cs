using Accounts;

namespace AccountsTest
{
    [TestFixture] //The [TestFixture] attribute denotes a class that contains unit tests.
    public class CheckingAccountTests
    {
        [SetUp] //The [SetUp] attribute in NUnit is used to mark a method that should be run before each test method in a test class. This allows you to perform any necessary setup or initialization steps that are required before each test is executed.
        public void Setup()
        {
        }

        [Test] //The [Test] attribute indicates a method is a test method.
        public void Withdraw_ValidAmount_ChangesBalance()
        {
            //Arrange
            double initialBalance = 100.0;
            double withDrawal = 40.0;
            double expectedBalance = 60.0;
            var account = new CheckingAccount(initialBalance);

            //Act
            account.Withdraw(withDrawal);

            //Assert
            Assert.That(() => { return account.m_balance == expectedBalance; } );
        }

        [Test]
        public void Withdraw_AmountMoreThanBalance_Throws()
        {
            //Arrange
            double initialBalance = 100.0;
            double withDrawal = 200.0;
            var account = new CheckingAccount(initialBalance);

            //Act and Assert
            Assert.Throws<System.ArgumentException>(() => { 
                account.Withdraw(withDrawal); 
            });
        }

        [Test]
        [TestCase(200.00)]//A [TestCase] attribute is used to create a suite of tests that execute the same code but have different input arguments.
        [TestCase(300.00)]
        [TestCase(400.00)]
        public void Withdraw_AmountMoreThanBalance_ThrowsCopy(double withDrawalAmount)
        {
            //Arrange
            AccountInfo accountInfo = new AccountInfo( 123,"KiranBS",100.00);
            var account = new CheckingAccount(accountInfo.Balance);

            //Act and Assert
            Assert.Throws<System.ArgumentException>(() => {
                account.Withdraw(withDrawalAmount);
            });
        }
    }
}