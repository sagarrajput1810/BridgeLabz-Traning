using NUnit.Framework;

namespace PasswordValidator.Tests
{
    public class PasswordValidatorTests
    {
        private PasswordValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new PasswordValidator();
        }

        [TestCase("ValidPass1", true)]
        [TestCase("short", false)]
        [TestCase("nouppercase1", false)]
        [TestCase("NODIGIT", false)]
        [TestCase("With Space 1", true)]
        [TestCase(null, false)]
        [TestCase("", false)]
        public void IsValid_ShouldReturnCorrectResult(string password, bool expected)
        {
            var result = _validator.IsValid(password);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
