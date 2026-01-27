using Xunit;
using RegexPractice;
using System.Collections.Generic;
using System.Linq; // Added for OrderBy // Added for List<string>

namespace RegexPractice.Tests
{
    public class RegexProblemsTests
    {
        [Theory]
        [InlineData("user_123", true)]   // Valid: letters, numbers, underscore, correct length
        [InlineData("UserNamE", true)]   // Valid: mixed case, correct length
        [InlineData("a_b_c_d_e", true)]  // Valid: multiple underscores
        [InlineData("u1234567890123", true)] // Valid: 14 chars
        [InlineData("u12345678901234", true)] // Valid: 15 chars
        [InlineData("abcdefghij", true)] // Valid: 10 chars
        [InlineData("us", false)]        // Invalid: too short (less than 5)
        [InlineData("123user", false)]   // Invalid: starts with a number
        [InlineData("_user", false)]     // Invalid: starts with underscore
        [InlineData("user-name", false)] // Invalid: contains hyphen
        [InlineData("user name", false)] // Invalid: contains space
        [InlineData("u123456789012345", false)] // Invalid: too long (16 chars)
        [InlineData("", false)]          // Invalid: empty
        [InlineData(null, false)]        // Invalid: null
        public void ValidateUsername_ShouldReturnCorrectResult(string username, bool expected)
        {
            // Act
            bool actual = RegexProblems.ValidateUsername(username);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("AB1234", true)]   // Valid
        [InlineData("XY9876", true)]   // Valid
        [InlineData("AA0000", true)]   // Valid
        [InlineData("A12345", false)]  // Invalid: starts with one letter
        [InlineData("AB123", false)]   // Invalid: too few digits
        [InlineData("ABC1234", false)] // Invalid: too many letters
        [InlineData("AB12345", false)] // Invalid: too many digits
        [InlineData("ab1234", false)]  // Invalid: lowercase letters
        [InlineData("", false)]        // Invalid: empty
        [InlineData(null, false)]      // Invalid: null
        public void ValidateLicensePlate_ShouldReturnCorrectResult(string licensePlate, bool expected)
        {
            // Act
            bool actual = RegexProblems.ValidateLicensePlate(licensePlate);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("#FFA500", true)]   // Valid
        [InlineData("#ff4500", true)]   // Valid
        [InlineData("#000000", true)]   // Valid
        [InlineData("#FFFFFF", true)]   // Valid
        [InlineData("#123456", true)]   // Valid
        [InlineData("#abcDEF", true)]   // Valid
        [InlineData("#123", false)]     // Invalid: too short
        [InlineData("#12345", false)]   // Invalid: too short
        [InlineData("#1234567", false)] // Invalid: too long
        [InlineData("FFA500", false)]   // Invalid: missing '#'
        [InlineData("#GG4500", false)]  // Invalid: invalid hex character
        [InlineData("", false)]         // Invalid: empty
        [InlineData(null, false)]       // Invalid: null
        public void ValidateHexColorCode_ShouldReturnCorrectResult(string hexColorCode, bool expected)
        {
            // Act
            bool actual = RegexProblems.ValidateHexColorCode(hexColorCode);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Contact us at support@example.com and info@company.org", new string[] { "support@example.com", "info@company.org" })]
        [InlineData("No emails here.", new string[] { })]
        [InlineData("My email is test@test.com.", new string[] { "test@test.com" })]
        [InlineData("Multiple emails: a@b.com, c@d.org, e@f.net.", new string[] { "a@b.com", "c@d.org", "e@f.net" })]
        [InlineData("Email with subdomain: user@sub.domain.co.uk.", new string[] { "user@sub.domain.co.uk" })]
        [InlineData(null, new string[] { })]
        [InlineData("", new string[] { })]
        public void ExtractEmails_ShouldReturnCorrectResults(string text, string[] expected)
        {
            // Act
            List<string> actual = RegexProblems.ExtractEmails(text);

            // Assert
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x)); // OrderBy to handle potential order differences
        }

        [Theory]
        [InlineData("The Eiffel Tower is in Paris and the Statue of Liberty is in New York.", new string[] { "Eiffel", "Tower", "Paris", "Statue", "Liberty", "New", "York" })]
        [InlineData("this is a sentence with No Capitalized Words.", new string[] { "No", "Capitalized", "Words" })]
        [InlineData("SingleWord", new string[] { "SingleWord" })]
        [InlineData("word", new string[] { })]
        [InlineData("WORD", new string[] { "WORD" })] // This behavior might be debatable depending on exact definition of "capitalized word". Assuming first letter capitalized, rest lowercase.
        [InlineData("leading Capitalized word.", new string[] { "Capitalized" })] // "leading" is lowercase.
        [InlineData("A short sentence.", new string[] { "A" })]
        [InlineData(null, new string[] { })]
        [InlineData("", new string[] { })]
        public void ExtractCapitalizedWords_ShouldReturnCorrectResults(string text, string[] expected)
        {
            // Act
            List<string> actual = RegexProblems.ExtractCapitalizedWords(text);

            // Assert
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }

        [Theory]
        [InlineData("The events are scheduled for 12/05/2023, 15/08/2024, and 29/02/2020.", new string[] { "12/05/2023", "15/08/2024", "29/02/2020" })]
        [InlineData("Invalid dates: 32/01/2023, 00/12/2023, 01/13/2023.", new string[] { })]
        [InlineData("Edge dates: 01/01/0001 and 31/12/1999.", new string[] { "01/01/0001", "31/12/1999" })]
        [InlineData(null, new string[] { })]
        [InlineData("", new string[] { })]
        public void ExtractDates_ShouldReturnCorrectResults(string text, string[] expected)
        {
            // Act
            List<string> actual = RegexProblems.ExtractDates(text);

            // Assert
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }

        [Theory]
        [InlineData("Visit https://www.google.com and http://example.org for more info.", new string[] { "https://www.google.com", "http://example.org" })]
        [InlineData("Trailing punctuation: https://example.com/path.", new string[] { "https://example.com/path" })]
        [InlineData("Wrapped (https://example.com) and [http://test.org].", new string[] { "https://example.com", "http://test.org" })]
        [InlineData("No links here.", new string[] { })]
        [InlineData(null, new string[] { })]
        public void ExtractLinks_ShouldReturnCorrectResults(string text, string[] expected)
        {
            // Act
            List<string> actual = RegexProblems.ExtractLinks(text);

            // Assert
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }

        [Theory]
        [InlineData("This  is   an  example.", "This is an example.")]
        [InlineData("Already single spaces.", "Already single spaces.")]
        [InlineData(" Leading   and  trailing  ", " Leading and trailing ")]
        [InlineData("", "")]
        [InlineData(null, "")]
        public void ReplaceMultipleSpaces_ShouldReturnCorrectResult(string input, string expected)
        {
            // Act
            string actual = RegexProblems.ReplaceMultipleSpaces(input);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("This is a damn bad example with some stupid words.", new string[] { "damn", "stupid" }, "This is a **** bad example with some **** words.")]
        [InlineData("This is a Damn bad example.", new string[] { "damn" }, "This is a **** bad example.")]
        [InlineData("The class is classic.", new string[] { "ass" }, "The class is classic.")]
        [InlineData("No bad words here.", new string[] { }, "No bad words here.")]
        [InlineData("Text stays same when list is null.", null, "Text stays same when list is null.")]
        [InlineData(null, new string[] { "damn" }, "")]
        public void CensorBadWords_ShouldReturnCorrectResults(string text, string[] badWords, string expected)
        {
            // Act
            string actual = RegexProblems.CensorBadWords(text, badWords);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("192.168.1.1", true)]
        [InlineData("0.0.0.0", true)]
        [InlineData("255.255.255.255", true)]
        [InlineData("256.0.0.1", false)]
        [InlineData("192.168.1", false)]
        [InlineData("192.168.1.1.1", false)]
        [InlineData("192.168.01.1", false)]
        [InlineData("abc.def.ghi.jkl", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ValidateIPv4_ShouldReturnCorrectResult(string ipAddress, bool expected)
        {
            // Act
            bool actual = RegexProblems.ValidateIPv4(ipAddress);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("4111111111111111", true)]
        [InlineData("5111111111111111", true)]
        [InlineData("4111 1111 1111 1111", true)]
        [InlineData("5111-1111-1111-1111", true)]
        [InlineData("6111111111111111", false)]
        [InlineData("411111111111111", false)]
        [InlineData("51111111111111111", false)]
        [InlineData("4abc111111111111", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ValidateCreditCardNumber_ShouldReturnCorrectResult(string cardNumber, bool expected)
        {
            // Act
            bool actual = RegexProblems.ValidateCreditCardNumber(cardNumber);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("I love Java, Python, and JavaScript, but I haven't tried Go yet.", new string[] { "Java", "Python", "JavaScript", "Go" })]
        [InlineData("i love python and go.", new string[] { "python", "go" })]
        [InlineData("I like Golang.", new string[] { })]
        [InlineData(null, new string[] { })]
        public void ExtractProgrammingLanguages_ShouldReturnCorrectResults(string text, string[] expected)
        {
            // Act
            List<string> actual = RegexProblems.ExtractProgrammingLanguages(text);

            // Assert
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }

        [Theory]
        [InlineData("The price is $45.99, and the discount is $ 10.50.", new string[] { "$45.99", "$10.50" })]
        [InlineData("Totals: $5 and $ 100.00.", new string[] { "$5", "$100.00" })]
        [InlineData("No money here.", new string[] { })]
        [InlineData(null, new string[] { })]
        public void ExtractCurrencyValues_ShouldReturnCorrectResults(string text, string[] expected)
        {
            // Act
            List<string> actual = RegexProblems.ExtractCurrencyValues(text);

            // Assert
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }

        [Theory]
        [InlineData("This is is a repeated repeated word test.", new string[] { "is", "repeated" })]
        [InlineData("This This is a test test test.", new string[] { "This", "test" })]
        [InlineData("No repeats here.", new string[] { })]
        [InlineData(null, new string[] { })]
        public void FindRepeatingWords_ShouldReturnCorrectResults(string text, string[] expected)
        {
            // Act
            List<string> actual = RegexProblems.FindRepeatingWords(text);

            // Assert
            Assert.Equal(expected.OrderBy(x => x), actual.OrderBy(x => x));
        }

        [Theory]
        [InlineData("123-45-6789", true)]
        [InlineData("123456789", false)]
        [InlineData("12-345-6789", false)]
        [InlineData("123-456-789", false)]
        [InlineData("123-45-678", false)]
        [InlineData("", false)]
        [InlineData(null, false)]
        public void ValidateSSN_ShouldReturnCorrectResult(string ssn, bool expected)
        {
            // Act
            bool actual = RegexProblems.ValidateSSN(ssn);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
