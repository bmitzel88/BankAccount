using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmount)
        {
            // Arrange

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => account.Deposit(invalidDepositAmount));
            
        }




        // Withdraw

        // Withdrawing a positive amount - decrease balance
        // Withdrawing 0 - Throws ArgumentOutOfRange exception
        // Withdrawing negative amount - Throws ArgumentOutOfRange exception
        // Withdrawing more than balance - Throws ArgumentException

        [TestMethod]
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
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance()
        {
            Assert.Fail();
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(0.01)]
        [DataRow(-1)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Withdraw_MoreThanAvailableBalance_ThrowsArgumentException()
        {
            Assert.Fail();
        }



    }
}