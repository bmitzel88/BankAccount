﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customers bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Creates an account with a specific owner and a balance of 0
        /// </summary>
        /// <param name="accOwner">The customer full name that owners the account</param>
        public Account(string accOwner)
        {
            Owner = accOwner;

        }
        /// <summary>
        /// Account holders full name, first and last
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// The amount of money currently in the account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Adds a specified amount of money to the account. Returns the new balance
        /// </summary>
        /// <param name="amount">The positive amount to deposit</param>
        /// <returns>The new balance after the deposit</returns>
        public double Deposit(double amount)
        {
            if (amount <= 0) 
            {
                throw new ArgumentOutOfRangeException("The amount must be more than 0");
            }
            
            Balance += amount;
            return Balance;
        }

        /// <summary>
        /// Removes a specified amount of money to the account and
        /// returns the updated balance
        /// </summary>
        /// <param name="amount">The positive amount to withdraw</param>
        /// <returns>Returns the updated balance after withdrawal</returns>
        public double Withdraw(double amount)
        {
            Balance -= amount;
            return Balance;
        }
    }
}
