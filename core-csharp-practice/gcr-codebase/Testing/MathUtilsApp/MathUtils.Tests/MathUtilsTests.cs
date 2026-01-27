using NUnit.Framework;

namespace MathUtils.Tests
{
    public class MathUtilsTests
    {
        private MathUtils _mathUtils;

        [SetUp]
        public void Setup()
        {
            _mathUtils = new MathUtils();
        }

        [TestCase(2, true)]
        [TestCase(4, true)]
        [TestCase(6, true)]
        [TestCase(7, false)]
        [TestCase(9, false)]
        [TestCase(0, true)]
        [TestCase(-2, true)]
        [TestCase(-3, false)]
        public void IsEven_ShouldReturnCorrectResult(int number, bool expected)
        {
            var result = _mathUtils.IsEven(number);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
