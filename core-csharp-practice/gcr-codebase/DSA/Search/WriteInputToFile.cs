using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SearchProblems
{
    public static class WriteInputToFileProblem
    {
        public static void WriteLines(IEnumerable<string> inputLines, string filePath)
        {
            using var writer = new StreamWriter(filePath, append: false, Encoding.UTF8);
            if (inputLines == null) return;
            foreach (string line in inputLines)
            {
                writer.WriteLine(line);
            }
        }
    }
}
