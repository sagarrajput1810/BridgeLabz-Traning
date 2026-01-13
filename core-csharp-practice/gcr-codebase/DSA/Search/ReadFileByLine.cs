using System.Collections.Generic;
using System.IO;

namespace SearchProblems
{
    public static class ReadFileByLineProblem
    {
        public static IEnumerable<string> ReadLines(string filePath)
        {
            using var reader = new StreamReader(filePath);
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
