using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Lab_2
{
    [TestFixture]
    class CalculatorTest
    {
        #region Addition tests
        [Test]
        public void AdditionIsNotNull() {
            double result = Calculator.Add(2, 3);
            Assert.IsNotNull(result);
        }

        [Test]
        public void AdditionExpectedValue() {
            double result = Calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void AdditionReturnSameValues() {
            double result_first = Calculator.Add(2, 3);
            double result_second = Calculator.Add(2, 3);
            Assert.AreEqual(result_first, result_second);
        }

        [Test]
        public void AdditionIsNaN() {
            Assert.IsNaN(Calculator.Add(Double.NaN, 2));
        }

        [Test]
        public void AddReverseValues() {
            double result = Calculator.Add(10,-10);
            Assert.AreEqual(0, result);
        }

        #endregion

        #region Substraction tests

        [Test]
        public void SubtractionIsNotNull()
        {
            double result = Calculator.Subtract(3, 2);
            Assert.IsNotNull(result);
        }

        [Test]
        public void SubtractionExpectedValue()
        {
            double result = Calculator.Subtract(3, 2);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void SubtractionIsNaN()
        {
            Assert.IsNaN(Calculator.Subtract(Double.NaN, 2));
        }

        [Test]
        public void SubtractionReturnSameValues()
        {
            double result_first = Calculator.Subtract(2, 3);
            double result_second = Calculator.Subtract(2, 3);
            Assert.AreEqual(result_first, result_second);
        }


        [Test]
        public void SubtractSameValues()
        {
            double result = Calculator.Subtract(10, 10);
            Assert.AreEqual(0, result);
        }

        #endregion

        #region Division tests

        [Test]
        public void DivisionDivideByZeroException() {
            Assert.Throws(typeof( DivideByZeroException), delegate { Calculator.Divide(2, 0); });
        }

        [Test]
        public void DivisionIsNotNull()
        {
            double result = Calculator.Divide(2, 3);
            Assert.IsNotNull(result);
        }

        [Test]
        public void DivisionIsNaN()
        {
            double result = Calculator.Divide(2, Double.NaN);
            Assert.IsNaN( result);
        }

        [Test]
        public void DivisionExpectedValue()
        {
            double result = Calculator.Divide(6, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void DivisionReturnSameValues()
        {
            double result_first = Calculator.Divide(2, 3);
            double result_second = Calculator.Divide(2, 3);
            Assert.AreEqual(result_first, result_second);
        }
        #endregion

        #region Multiplication tests
        [Test]
        public void MultiplicationIsNotNull()
        {
            double result = Calculator.Multiply(2, 3);
            Assert.IsNotNull(result);
        }

        [Test]
        public void MultiplicationExpectedValue()
        {
            double result = Calculator.Multiply(2, 3);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void MultiplicationReturnSameValues()
        {
            double result_first = Calculator.Multiply(2, 3);
            double result_second = Calculator.Multiply(2, 3);
            Assert.AreEqual(result_first, result_second);
        }

        [Test]
        public void MultiplicationIsNaN()
        {
            Assert.IsNaN(Calculator.Multiply(Double.NaN, 2));
        }

        [Test]
        public void MultiplyReverseValues()
        {
            double result = Calculator.Multiply(10, 0.1);
            Assert.AreEqual(1, result);
        }

        #endregion

    }
}
