using System;
using System.Collections.Generic;
using System.Linq;

namespace HashMapProblems
{
    /// <summary>
    /// Problem: Given an array, find all subarrays whose elements sum up to zero.
    /// 
    /// Approach: Use a hash map to store the cumulative sum and its frequency. 
    /// If a sum repeats, a zero-sum subarray exists.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(n)
    /// </summary>
    public class FindAllSubarraysWithZeroSum
    {
        public class SubarrayInfo
        {
            public int StartIndex { get; set; }
            public int EndIndex { get; set; }
            public int[] Elements { get; set; }

            public SubarrayInfo(int start, int end, int[] elements)
            {
                StartIndex = start;
                EndIndex = end;
                Elements = elements;
            }

            public override string ToString()
            {
                return $"[{StartIndex}-{EndIndex}]: {string.Join(", ", Elements)}";
            }
        }

        /// <summary>
        /// Find all subarrays with sum 0
        /// </summary>
        public static List<SubarrayInfo> FindZeroSumSubarrays(int[] arr)
        {
            List<SubarrayInfo> result = new List<SubarrayInfo>();
            if (arr == null || arr.Length == 0)
                return result;

            // Dictionary to store cumsum and list of indices where it occurs
            Dictionary<int, List<int>> cumulativeSumMap = new Dictionary<int, List<int>>();
            cumulativeSumMap[0] = new List<int> { -1 }; // Handle subarray starting from index 0

            int cumulativeSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                cumulativeSum += arr[i];

                if (cumulativeSumMap.ContainsKey(cumulativeSum))
                {
                    // We found subarrays with sum 0
                    foreach (int prevIndex in cumulativeSumMap[cumulativeSum])
                    {
                        int startIdx = prevIndex + 1;
                        int endIdx = i;
                        int[] elements = arr.Skip(startIdx).Take(endIdx - startIdx + 1).ToArray();
                        result.Add(new SubarrayInfo(startIdx, endIdx, elements));
                    }

                    cumulativeSumMap[cumulativeSum].Add(i);
                }
                else
                {
                    cumulativeSumMap[cumulativeSum] = new List<int> { i };
                }
            }

            return result;
        }

        /// <summary>
        /// Brute force approach - O(n^2) or O(n^3)
        /// </summary>
        public static List<SubarrayInfo> FindZeroSumSubarraysBruteForce(int[] arr)
        {
            List<SubarrayInfo> result = new List<SubarrayInfo>();
            if (arr == null || arr.Length == 0)
                return result;

            for (int i = 0; i < arr.Length; i++)
            {
                int sum = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    sum += arr[j];
                    if (sum == 0)
                    {
                        int[] elements = arr.Skip(i).Take(j - i + 1).ToArray();
                        result.Add(new SubarrayInfo(i, j, elements));
                    }
                }
            }

            return result;
        }

        public static void Main()
        {
            Console.WriteLine("=== Find All Subarrays with Zero Sum ===\n");

            // Test case 1
            int[] arr1 = { 15, -2, 2, -8, 1, 7, -10, 20 };
            var result1 = FindZeroSumSubarrays(arr1);

            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Array: {string.Join(", ", arr1)}");
            Console.WriteLine($"Zero-sum subarrays found: {result1.Count}");
            foreach (var subarray in result1)
            {
                Console.WriteLine($"  {subarray}");
            }

            // Test case 2
            Console.WriteLine("\n--- Test Case 2 ---");
            int[] arr2 = { 1, 2, -3, 2 };
            var result2 = FindZeroSumSubarrays(arr2);

            Console.WriteLine($"Array: {string.Join(", ", arr2)}");
            Console.WriteLine($"Zero-sum subarrays found: {result2.Count}");
            foreach (var subarray in result2)
            {
                Console.WriteLine($"  {subarray}");
            }

            // Test case 3
            Console.WriteLine("\n--- Test Case 3 ---");
            int[] arr3 = { 1, 1, -2, -1, 1 };
            var result3 = FindZeroSumSubarrays(arr3);

            Console.WriteLine($"Array: {string.Join(", ", arr3)}");
            Console.WriteLine($"Zero-sum subarrays found: {result3.Count}");
            foreach (var subarray in result3)
            {
                Console.WriteLine($"  {subarray}");
            }

            // Test case 4: No zero-sum subarray
            Console.WriteLine("\n--- Test Case 4: No Zero-Sum ---");
            int[] arr4 = { 1, 2, 3, 4 };
            var result4 = FindZeroSumSubarrays(arr4);

            Console.WriteLine($"Array: {string.Join(", ", arr4)}");
            Console.WriteLine($"Zero-sum subarrays found: {result4.Count}");

            // Verify both approaches
            Console.WriteLine("\n--- Verification (Optimized vs Brute Force) ---");
            int[] arr5 = { 2, 1, -3, 1, 2 };
            var optimized = FindZeroSumSubarrays(arr5);
            var bruteForce = FindZeroSumSubarraysBruteForce(arr5);

            Console.WriteLine($"Array: {string.Join(", ", arr5)}");
            Console.WriteLine($"Optimized found: {optimized.Count} subarrays");
            Console.WriteLine($"Brute Force found: {bruteForce.Count} subarrays");
            Console.WriteLine($"Results Match: {optimized.Count == bruteForce.Count}");
        }
    }
}
