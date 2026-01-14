using System;
using System.Diagnostics;
using System.Linq;

namespace AlgorithmComparisons
{
    public class SearchComparison
    {
        public static void Run()
        {
            Console.WriteLine("--- 1. Search a Target in a Large Dataset ---");
            // Reduced sizes for demonstration speed, original prompt asked for 1k, 10k, 1M
            int[] sizes = { 1000, 10000, 1000000 };
            
            foreach (int size in sizes)
            {
                Console.WriteLine($"\nDataset Size (N): {size}");
                int[] data = Enumerable.Range(0, size).ToArray();
                int target = size - 1; // Worst case for Linear Search

                // Linear Search
                Stopwatch sw = Stopwatch.StartNew();
                LinearSearch(data, target);
                sw.Stop();
                Console.WriteLine($"Linear Search Time: {sw.Elapsed.TotalMilliseconds:F4} ms");

                // Binary Search (Data is already sorted)
                sw.Restart();
                Array.BinarySearch(data, target);
                sw.Stop();
                Console.WriteLine($"Binary Search Time: {sw.Elapsed.TotalMilliseconds:F4} ms");
            }
        }

        static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target) return i;
            }
            return -1;
        }
    }
}