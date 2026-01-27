using NUnit.Framework;
using System;

namespace DateFormatter.Tests
{
    public class DateFormatterTests
    {
        private DateFormatter _formatter;

        [SetUp]
        public void Setup()
        {
            _formatter = new DateFormatter();
        }

        [Test]
        public void FormatDate_ValidDate_ShouldReturnFormattedDate()
        {
            var result = _formatter.FormatDate("2024-01-27");
            Assert.That(result, Is.EqualTo("27-01-2024"));
        }

        [Test]
        public void FormatDate_InvalidDate_ShouldThrowFormatException()
        {
            Assert.Throws<FormatException>(() => _formatter.FormatDate("27-01-2024"));
        }

        [Test]
        public void FormatDate_InvalidDateString_ShouldThrowFormatException()
        {
            Assert.Throws<FormatException>(() => _formatter.FormatDate("not a date"));
        }
    }
}
