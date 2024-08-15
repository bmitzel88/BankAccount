using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {

        private Account account;

        [TestInitialize]
        public void CreateDefaultAccount() 
        {
            account = new Account("John Doe");
        }

        
        
        
        
        [TestMethod()]
        [DataRow(100)]
        [DataRow(0.01)]
        [DataRow(9999.99)]
        [DataRow(9.9999)]
        public void Deposit_APositiveAmount_AddToBalance(double depositAmount) /// Naming convention: what is the name of the method im testing_the state testing_What should it do?
        {
            account.Deposit(depositAmount);

            Assert.AreEqual(depositAmount, account.Balance);
        }


        [TestMethod]
        [TestCategory("Deposit")]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange Act Assert

            // Arrange
            double depositAmount = 531;
            double expectedReturn = 531;
           
            // Act
            double returnValue = account.Deposit(depositAmount);


            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }


        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [TestCategory("Deposit")]
        public void Deposit_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidDepositAmount)
        {
            // Arrange

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Deposit(invalidDepositAmount));
        }




        // Withdraw

        // Withdrawing a positive amount - decrease balance
        // Withdrawing 0 - Throws ArgumentOutOfRange exception
        // Withdrawing negative amount - Throws ArgumentOutOfRange exception
        // Withdrawing more than balance - Throws ArgumentException

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            // Arrange
            double initialDeposit = 100;
            double withdrawAmount = 50;
            double expectedBalance = initialDeposit - withdrawAmount;

            // Act
            account.Deposit(initialDeposit);
            account.Withdraw(withdrawAmount);

            double actualBalance = account.Balance;

            // Assert
            Assert.AreEqual(expectedBalance, actualBalance);

        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance()
        {
            double initialDeposit = 500;
            double withdrawAmount = 25;
            double expectedBalance = 475;

            account.Deposit(initialDeposit);
            double  actualBalance = account.Withdraw(withdrawAmount);


            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [TestCategory("Withdraw")]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double amount)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => account.Withdraw(amount));
        }

        [TestMethod]
        [TestCategory("Withdraw")]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            double withdrawAmount = 10000;
            
            
            Assert.ThrowsException<ArgumentException>(() => account.Withdraw(withdrawAmount));
        }



        [TestMethod]
        public void Owner_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => account.Owner = null);
        }


        [TestMethod]
        public void Owner_SetAsWhitespaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => account.Owner = String.Empty);
            Assert.ThrowsException<ArgumentException>(() => account.Owner = "     ");
        }


        [TestMethod]
        [DataRow("Bran don")]
        [DataRow("This IsThe LongestNameEver")]
        public void Owner_SetAsUpTo20Characters_SetsSuccessfully(string ownerName)
        {
            account.Owner = ownerName;
            Assert.AreEqual(ownerName, account.Owner);
        }


        [TestMethod]
        [DataRow("Brandon 361")]
        [DataRow("^@*#")]
        [DataRow("BR@NDON M!TZ3L")]

        public void Owner_InvalidOwnerName_ThrowsArgumentException(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => account.Owner = ownerName);
        }


    }
}