using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
namespace BankUnitTest
{
    [TestClass]
    public class BankTest
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            BankAccount account = new BankAccount("Cristel Orellana", beginningBalance);
            account.Debit(debitAmount);

            double actual = account.Balance;

            Assert.AreEqual(expected, actual, "Account not debit correctly");

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double beginningBalance = 11.99;
            double debitAmount = -400;

            BankAccount account = new BankAccount("Cesar Vargas", beginningBalance);
            account.Debit(debitAmount);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentFroozenAccount))]
        public void Debit_WhenFrozenAccount_ShouldThrowArgumentFroozenAccount()
        {
            double beginningBalance = 500;
            double debitAmount = 60;

            BankAccount account = new BankAccount("Tony Rojas", beginningBalance);
            account.FreezeAccount();
            account.Debit(debitAmount);
        }
    }
}
