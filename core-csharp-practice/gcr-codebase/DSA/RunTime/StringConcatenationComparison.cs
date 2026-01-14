using System;
using System.Diagnostics;
using System.Text;

namespace AlgorithmComparisons
{
    public class StringConcatenationComparison
    {
        public static void Run()
        {
            Console.WriteLine("\n--- 3. String Concatenation Performance ---");
            int[] sizes = { 1000, 10000 }; 

            foreach (int size in sizes)
            {
                Console.WriteLine($"\nOperations Count (N): {size}");

                // String Concatenation
                Stopwatch sw = Stopwatch.StartNew();
                string s = "";
                for (int i = 0; i < size; i++)
                {
                    s += "a";
                }
                sw.Stop();
                Console.WriteLine($"String (Immutable) Time: {sw.Elapsed.TotalMilliseconds:F4} ms");

                // StringBuilder
                sw.Restart();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < size; i++)
                {
                    sb.Append("a");
                }
                sw.Stop();
                Console.WriteLine($"StringBuilder (Mutable) Time: {sw.Elapsed.TotalMilliseconds:F4} ms");
            }
        }
    }
}
