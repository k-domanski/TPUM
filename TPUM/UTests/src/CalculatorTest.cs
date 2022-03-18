using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UTests
{
    [TestClass]
    public class CalculatorTest
    {
        private static Calculator.Calculator calculator;
        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            calculator = new Calculator.Calculator();
        }

        [TestMethod]
        public void Addition()
        {
            Assert.AreEqual(4, calculator.Add(2, 2));
        }

        [TestMethod]
        public void Multiplication()
        {
            Assert.AreEqual(4, calculator.Multiply(2, 2));
        }
    }
}
