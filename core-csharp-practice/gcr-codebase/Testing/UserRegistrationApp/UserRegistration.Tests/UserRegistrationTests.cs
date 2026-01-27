using NUnit.Framework;
using System;

namespace UserRegistration.Tests
{
    public class UserRegistrationTests
    {
        private UserRegistration _registration;

        [SetUp]
        public void Setup()
        {
            _registration = new UserRegistration();
        }

        [Test]
        public void RegisterUser_ValidInputs_ShouldNotThrowException()
        {
            Assert.DoesNotThrow(() => _registration.RegisterUser("testuser", "test@example.com", "password123"));
        }

        [TestCase(null, "test@example.com", "password123")]
        [TestCase(" ", "test@example.com", "password123")]
        [TestCase("testuser", "invalid-email", "password123")]
        [TestCase("testuser", null, "password123")]
        [TestCase("testuser", "test@example.com", "short")]
        [TestCase("testuser", "test@example.com", null)]
        public void RegisterUser_InvalidInputs_ShouldThrowArgumentException(string username, string email, string password)
        {
            Assert.Throws<ArgumentException>(() => _registration.RegisterUser(username, email, password));
        }
    }
}
