using System;
using System.Diagnostics;

namespace AlgorithmComparisons
{
    public class FibonacciComparison
    {
        public static void Run()
        {
            Console.WriteLine("\n--- 5. Recursive vs Iterative Fibonacci Computation ---");
            int[] inputs = { 10, 30, 40 };

            foreach (int n in inputs)
            {
                Console.WriteLine($"\nFibonacci Input (N): {n}");

                // Recursive
                Stopwatch sw = Stopwatch.StartNew();
                long resRec = FibonacciRecursive(n);
                sw.Stop();
                Console.WriteLine($"Recursive Time: {sw.Elapsed.TotalMilliseconds:F4} ms (Result: {resRec})");

                // Iterative
                sw.Restart();
                long resIter = FibonacciIterative(n);
                sw.Stop();
                Console.WriteLine($"Iterative Time: {sw.Elapsed.TotalMilliseconds:F4} ms (Result: {resIter})");
            }
        }

        static long FibonacciRecursive(int n)
        {
            if (n <= 1) return n;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }

        static long FibonacciIterative(int n)
        {
            if (n <= 1) return n;
            long a = 0, b = 1, sum;
            for (int i = 2; i <= n; i++)
            {
                sum = a + b;
                a = b;
                b = sum;
            }
            return b;
        }
    }
}
