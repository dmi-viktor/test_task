using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTestTasks.Tests
{
    [TestClass]
    public class BalanceBracketsTests
    {
        [TestMethod]
        public void CheckBalanceBrackets_correct_true_returned()
        {
            string str = "((1+3)()(4+(3-5)))";
            bool expected = true;

            BalanceBrackets balanceBrackets = BalanceBrackets.GetBalanceBrackets();
            bool actual = balanceBrackets.CheckBalanceRoundBrackets(str);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckBalanceBrackets_incorrect_false_returned()
        {
            string str = "((1+3)()(4+3-5)))";
            bool expected = false;

            BalanceBrackets balanceBrackets = BalanceBrackets.GetBalanceBrackets();
            bool actual = balanceBrackets.CheckBalanceRoundBrackets(str);

            Assert.AreEqual(expected, actual);
        }
    }
}
