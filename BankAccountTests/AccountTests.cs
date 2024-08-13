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
        [TestMethod()]
        public void Deposit_APositiveAmount_AddToBalance() /// Naming convention: what is the name of the method im testing_the state testing_What should it do?
        {
            Account account = new("John Doe");
            account.Deposit(100);

            Assert.AreEqual(100, account.Balance);
        }


        [TestMethod]
        public void Deposit_APositiveAmount_ReturnsUpdatedBalance()
        {
            // AAA - Arrange Act Assert

            // Arrange
            Account account = new("John Doe");
            double depositAmount = 531;
            double expectedReturn = 531;
           
            // Act
            double returnValue = account.Deposit(depositAmount);


            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }
    }
}