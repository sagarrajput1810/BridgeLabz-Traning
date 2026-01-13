using System;

namespace SearchProblems
{
    public static class FirstSentenceContainingProblem
    {
        public static string? Find(string[] sentences, string word)
        {
            if (sentences == null || string.IsNullOrEmpty(word)) return null;
            foreach (string sentence in sentences)
            {
                if (sentence != null && sentence.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return sentence;
                }
            }
            return null;
        }
    }
}
