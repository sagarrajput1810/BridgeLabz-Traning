using System;
using System.Collections.Generic;

namespace StackAndQueueProblems
{
    /// <summary>
    /// Problem: For each day in a stock price array, calculate the span 
    /// (number of consecutive days the price was less than or equal to the current day's price).
    /// 
    /// Approach: Use a stack to keep track of indices of prices in descending order.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(n)
    /// </summary>
    public class StockSpanProblem
    {
        /// <summary>
        /// Calculate stock span for each day
        /// </summary>
        public static int[] CalculateSpan(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return new int[0];

            int n = prices.Length;
            int[] span = new int[n];
            Stack<int> stack = new Stack<int>(); // Stack stores indices

            for (int i = 0; i < n; i++)
            {
                // Pop elements from stack while the price at top of stack is less than current price
                while (stack.Count > 0 && prices[stack.Peek()] <= prices[i])
                {
                    stack.Pop();
                }

                // If stack becomes empty, span is i+1
                // Otherwise, span is current index - index at top of stack
                span[i] = (stack.Count == 0) ? i + 1 : i - stack.Peek();

                // Push current index to stack
                stack.Push(i);
            }

            return span;
        }

        /// <summary>
        /// Brute force approach - O(n^2) for comparison
        /// </summary>
        public static int[] CalculateSpanBruteForce(int[] prices)
        {
            if (prices == null || prices.Length == 0)
                return new int[0];

            int n = prices.Length;
            int[] span = new int[n];

            for (int i = 0; i < n; i++)
            {
                span[i] = 1; // Current day always counts
                
                // Count consecutive days backwards where price <= current price
                for (int j = i - 1; j >= 0 && prices[j] <= prices[i]; j--)
                {
                    span[i]++;
                }
            }

            return span;
        }

        public static void PrintSpans(int[] prices, int[] spans)
        {
            Console.WriteLine("Day\tPrice\tSpan");
            for (int i = 0; i < prices.Length; i++)
            {
                Console.WriteLine($"{i + 1}\t{prices[i]}\t{spans[i]}");
            }
        }

        public static void Main()
        {
            Console.WriteLine("=== Stock Span Problem ===\n");

            // Test case 1
            int[] prices1 = { 100, 80, 60, 70, 60, 75, 85 };
            int[] span1 = CalculateSpan(prices1);

            Console.WriteLine("Test Case 1:");
            Console.WriteLine("Prices: " + string.Join(", ", prices1));
            Console.WriteLine("Spans: " + string.Join(", ", span1));
            PrintSpans(prices1, span1);

            // Test case 2
            Console.WriteLine("\n--- Test Case 2 ---");
            int[] prices2 = { 10, 4, 5, 90, 120, 80 };
            int[] span2 = CalculateSpan(prices2);

            Console.WriteLine("Prices: " + string.Join(", ", prices2));
            Console.WriteLine("Spans: " + string.Join(", ", span2));
            PrintSpans(prices2, span2);

            // Test case 3: All increasing
            Console.WriteLine("\n--- Test Case 3: All Increasing ---");
            int[] prices3 = { 1, 2, 3, 4, 5 };
            int[] span3 = CalculateSpan(prices3);

            Console.WriteLine("Prices: " + string.Join(", ", prices3));
            Console.WriteLine("Spans: " + string.Join(", ", span3));
            PrintSpans(prices3, span3);

            // Test case 4: All decreasing
            Console.WriteLine("\n--- Test Case 4: All Decreasing ---");
            int[] prices4 = { 5, 4, 3, 2, 1 };
            int[] span4 = CalculateSpan(prices4);

            Console.WriteLine("Prices: " + string.Join(", ", prices4));
            Console.WriteLine("Spans: " + string.Join(", ", span4));
            PrintSpans(prices4, span4);

            // Verify both approaches give same result
            Console.WriteLine("\n--- Verification (Brute Force vs Optimized) ---");
            int[] prices5 = { 100, 80, 60, 70, 60, 75, 85 };
            int[] spanOptimized = CalculateSpan(prices5);
            int[] spanBruteForce = CalculateSpanBruteForce(prices5);

            Console.WriteLine("Optimized: " + string.Join(", ", spanOptimized));
            Console.WriteLine("BruteForce: " + string.Join(", ", spanBruteForce));
            Console.WriteLine("Results Match: " + 
                string.Join(", ", spanOptimized).Equals(string.Join(", ", spanBruteForce)));
        }
    }
}
