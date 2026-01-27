using System;
using System.Linq;

namespace StringUtils
{
    public class StringUtils
    {
        public string Reverse(string str)
        {
            if (str == null)
                return null;

            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public bool IsPalindrome(string str)
        {
            if (str == null)
                return false;

            var normalized = new string(str.Where(char.IsLetterOrDigit).ToArray()).ToLower();
            var reversed = Reverse(normalized);
            return normalized.Equals(reversed);
        }

        public string ToUpperCase(string str)
        {
            if (str == null)
                return null;

            return str.ToUpper();
        }
    }
}
