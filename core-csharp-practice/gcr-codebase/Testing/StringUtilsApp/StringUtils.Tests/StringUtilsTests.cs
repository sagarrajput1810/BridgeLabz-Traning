using NUnit.Framework;
using StringUtils;

namespace StringUtils.Tests
{
    public class StringUtilsTests
    {
        private StringUtils _stringUtils;

        [SetUp]
        public void Setup()
        {
            _stringUtils = new StringUtils();
        }

        [Test]
        public void Reverse_ShouldReverseString()
        {
            var result = _stringUtils.Reverse("hello");
            Assert.That(result, Is.EqualTo("olleh"));
        }

        [Test]
        public void Reverse_NullString_ShouldReturnNull()
        {
            var result = _stringUtils.Reverse(null);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void IsPalindrome_ShouldReturnTrueForPalindrome()
        {
            var result = _stringUtils.IsPalindrome("madam");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPalindrome_ShouldReturnFalseForNonPalindrome()
        {
            var result = _stringUtils.IsPalindrome("hello");
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsPalindrome_MixedCase_ShouldReturnTrue()
        {
            var result = _stringUtils.IsPalindrome("Madam");
            Assert.That(result, Is.True);
        }
        
        [Test]
        public void IsPalindrome_WithSpacesAndPunctuation_ShouldReturnTrue()
        {
            var result = _stringUtils.IsPalindrome("A man, a plan, a canal: Panama");
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPalindrome_NullString_ShouldReturnFalse()
        {
            var result = _stringUtils.IsPalindrome(null);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ToUpperCase_ShouldConvertStringToUpperCase()
        {
            var result = _stringUtils.ToUpperCase("hello");
            Assert.That(result, Is.EqualTo("HELLO"));
        }

        [Test]
        public void ToUpperCase_NullString_ShouldReturnNull()
        {
            var result = _stringUtils.ToUpperCase(null);
            Assert.That(result, Is.Null);
        }
    }
}
