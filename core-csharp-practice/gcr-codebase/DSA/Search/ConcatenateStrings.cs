using System.Collections.Generic;
using System.Text;

namespace SearchProblems
{
    public static class ConcatenateStringsProblem
    {
        public static string Concatenate(IEnumerable<string> parts)
        {
            if (parts == null) return string.Empty;
            var sb = new StringBuilder();
            foreach (string part in parts)
            {
                sb.Append(part);
            }
            return sb.ToString();
        }
    }
}
