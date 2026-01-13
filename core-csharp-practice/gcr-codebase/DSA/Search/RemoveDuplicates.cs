using System.Collections.Generic;
using System.Text;

namespace SearchProblems
{
    public static class RemoveDuplicatesProblem
    {
        public static string RemoveDuplicates(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            var seen = new HashSet<char>();
            var sb = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (seen.Add(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
