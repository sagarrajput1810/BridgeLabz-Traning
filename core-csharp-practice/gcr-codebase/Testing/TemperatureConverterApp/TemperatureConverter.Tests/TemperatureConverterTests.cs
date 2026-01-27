using NUnit.Framework;

namespace TemperatureConverter.Tests
{
    public class TemperatureConverterTests
    {
        private TemperatureConverter _converter;

        [SetUp]
        public void Setup()
        {
            _converter = new TemperatureConverter();
        }

        [TestCase(0, 32)]
        [TestCase(100, 212)]
        [TestCase(-10, 14)]
        public void CelsiusToFahrenheit_ShouldReturnCorrectFahrenheit(double celsius, double expectedFahrenheit)
        {
            var result = _converter.CelsiusToFahrenheit(celsius);
            Assert.That(result, Is.EqualTo(expectedFahrenheit).Within(0.01));
        }

        [TestCase(32, 0)]
        [TestCase(212, 100)]
        [TestCase(14, -10)]
        public void FahrenheitToCelsius_ShouldReturnCorrectCelsius(double fahrenheit, double expectedCelsius)
        {
            var result = _converter.FahrenheitToCelsius(fahrenheit);
            Assert.That(result, Is.EqualTo(expectedCelsius).Within(0.01));
        }
    }
}
