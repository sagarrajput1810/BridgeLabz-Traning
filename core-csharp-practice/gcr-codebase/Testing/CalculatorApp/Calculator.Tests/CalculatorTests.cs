using NUnit.Framework;
using Calculator;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            var result = _calculator.Add(2, 3);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Subtract_ShouldReturnCorrectDifference()
        {
            var result = _calculator.Subtract(5, 3);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Multiply_ShouldReturnCorrectProduct()
        {
            var result = _calculator.Multiply(2, 3);
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Divide_ShouldReturnCorrectQuotient()
        {
            var result = _calculator.Divide(6, 3);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Divide_ByZero_ShouldThrowDivideByZeroException()
        {
            Assert.Throws<System.DivideByZeroException>(() => _calculator.Divide(1, 0));
        }
    }
}