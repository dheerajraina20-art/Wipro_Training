using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorLibrary;
using System;

namespace CalculatorLibrary.Tests
{
    [TestClass]
    public class Test1
    {
        Calculator calc;

        // This method runs before EACH test
        [TestInitialize]
        public void Setup()
        {
            calc = new Calculator();
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            int result = calc.Add(5, 3);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            int result = calc.Subtract(10, 4);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            int result = calc.Multiply(6, 7);
            Assert.AreEqual(42, result);
        }

        [TestMethod]
        public void Divide_TwoNumbers_ReturnsQuotient()
        {
            int result = calc.Divide(20, 4);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() =>
            {
                calc.Divide(10, 0);
            });
        }
    }
}
