using System;

namespace SearchProblems
{
    public static class CountWordOccurrencesProblem
    {
        public static int Count(string filePath, string word)
        {
            if (word == null) return 0;
            int total = 0;
            foreach (string line in ReadFileByLineProblem.ReadLines(filePath))
            {
                int start = 0;
                while (true)
                {
                    int index = line.IndexOf(word, start, StringComparison.OrdinalIgnoreCase);
                    if (index < 0) break;
                    total++;
                    start = index + word.Length;
                }
            }
            return total;
        }
    }
}
