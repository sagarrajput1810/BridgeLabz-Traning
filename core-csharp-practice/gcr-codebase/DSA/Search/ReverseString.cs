using System.Text;

namespace SearchProblems
{
    public static class ReverseStringProblem
    {
        public static string Reverse(string input)
        {
            if (input == null) return string.Empty;
            var sb = new StringBuilder(input.Length);
            for (int i = input.Length - 1; i >= 0; i--)
            {
                sb.Append(input[i]);
            }
            return sb.ToString();
        }
    }
}
