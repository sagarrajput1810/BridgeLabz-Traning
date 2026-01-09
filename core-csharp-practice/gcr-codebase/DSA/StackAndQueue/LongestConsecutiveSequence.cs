using System;
using System.Collections.Generic;
using System.Linq;

namespace HashMapProblems
{
    /// <summary>
    /// Problem: Given an unsorted array, find the length of the longest consecutive elements sequence.
    /// 
    /// Approach: Use a hash map to store elements and check for consecutive elements efficiently.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(n)
    /// </summary>
    public class LongestConsecutiveSequence
    {
        /// <summary>
        /// Find longest consecutive sequence using hash set
        /// </summary>
        public static int FindLongestConsecutiveLength(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            HashSet<int> numSet = new HashSet<int>(nums);
            int longestStreak = 0;

            foreach (int num in numSet)
            {
                // Only start counting if this is the beginning of a sequence
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum++;
                        currentStreak++;
                    }

                    longestStreak = Math.Max(longestStreak, currentStreak);
                }
            }

            return longestStreak;
        }

        /// <summary>
        /// Find longest consecutive sequence and return the actual sequence
        /// </summary>
        public static List<int> FindLongestConsecutiveSequence(int[] nums)
        {
            List<int> result = new List<int>();
            if (nums == null || nums.Length == 0)
                return result;

            HashSet<int> numSet = new HashSet<int>(nums);
            int longestStreak = 0;
            int startNum = 0;

            foreach (int num in numSet)
            {
                // Only start counting if this is the beginning of a sequence
                if (!numSet.Contains(num - 1))
                {
                    int currentNum = num;
                    int currentStreak = 1;

                    while (numSet.Contains(currentNum + 1))
                    {
                        currentNum++;
                        currentStreak++;
                    }

                    if (currentStreak > longestStreak)
                    {
                        longestStreak = currentStreak;
                        startNum = num;
                    }
                }
            }

            // Build the result sequence
            for (int i = 0; i < longestStreak; i++)
            {
                result.Add(startNum + i);
            }

            return result;
        }

        /// <summary>
        /// Sorting approach - O(n log n)
        /// </summary>
        public static int FindLongestConsecutiveSorted(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            Array.Sort(nums);
            int longestStreak = 1;
            int currentStreak = 1;

            for (int i = 1; i < nums.Length; i++)
            {
                // Skip duplicates
                if (nums[i] == nums[i - 1])
                    continue;

                // Check if consecutive
                if (nums[i] == nums[i - 1] + 1)
                {
                    currentStreak++;
                }
                else
                {
                    longestStreak = Math.Max(longestStreak, currentStreak);
                    currentStreak = 1;
                }
            }

            return Math.Max(longestStreak, currentStreak);
        }

        /// <summary>
        /// Brute force approach - O(n^2) or worse
        /// </summary>
        public static int FindLongestConsecutiveBruteForce(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;

            int longestStreak = 1;

            foreach (int num in nums)
            {
                int currentNum = num;
                int currentStreak = 1;

                while (Array.Contains(nums, currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
            }

            return longestStreak;
        }

        public static void Main()
        {
            Console.WriteLine("=== Longest Consecutive Sequence ===\n");

            // Test case 1
            int[] nums1 = { 100, 4, 200, 1, 3, 2 };
            int length1 = FindLongestConsecutiveLength(nums1);
            var seq1 = FindLongestConsecutiveSequence(nums1);

            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Array: {string.Join(", ", nums1)}");
            Console.WriteLine($"Longest consecutive length: {length1}");
            Console.WriteLine($"Sequence: {string.Join(", ", seq1)}");

            // Test case 2
            Console.WriteLine("\n--- Test Case 2 ---");
            int[] nums2 = { 9, 1,4, 7, 3, 2, 8, 5, 6 };
            int length2 = FindLongestConsecutiveLength(nums2);
            var seq2 = FindLongestConsecutiveSequence(nums2);

            Console.WriteLine($"Array: {string.Join(", ", nums2)}");
            Console.WriteLine($"Longest consecutive length: {length2}");
            Console.WriteLine($"Sequence: {string.Join(", ", seq2)}");

            // Test case 3
            Console.WriteLine("\n--- Test Case 3 ---");
            int[] nums3 = { 10, 5, 1, 2, 3, 7, 8, 9 };
            int length3 = FindLongestConsecutiveLength(nums3);
            var seq3 = FindLongestConsecutiveSequence(nums3);

            Console.WriteLine($"Array: {string.Join(", ", nums3)}");
            Console.WriteLine($"Longest consecutive length: {length3}");
            Console.WriteLine($"Sequence: {string.Join(", ", seq3)}");

            // Test case 4: Single element
            Console.WriteLine("\n--- Test Case 4: Single Element ---");
            int[] nums4 = { 42 };
            int length4 = FindLongestConsecutiveLength(nums4);

            Console.WriteLine($"Array: {string.Join(", ", nums4)}");
            Console.WriteLine($"Longest consecutive length: {length4}");

            // Test case 5: Duplicates
            Console.WriteLine("\n--- Test Case 5: With Duplicates ---");
            int[] nums5 = { 1, 1, 1, 2, 2, 3, 4, 4, 5 };
            int length5 = FindLongestConsecutiveLength(nums5);
            var seq5 = FindLongestConsecutiveSequence(nums5);

            Console.WriteLine($"Array: {string.Join(", ", nums5)}");
            Console.WriteLine($"Longest consecutive length: {length5}");
            Console.WriteLine($"Sequence: {string.Join(", ", seq5)}");

            // Compare approaches
            Console.WriteLine("\n--- Comparison of Approaches ---");
            int[] nums6 = { 9, 1,4, 7, 3, 2, 8, 5, 6 };

            int hashSet = FindLongestConsecutiveLength(nums6);
            int sorted = FindLongestConsecutiveSorted(nums6);
            int brute = FindLongestConsecutiveBruteForce(nums6);

            Console.WriteLine($"Array: {string.Join(", ", nums6)}");
            Console.WriteLine($"Hash Set approach: {hashSet}");
            Console.WriteLine($"Sorting approach: {sorted}");
            Console.WriteLine($"Brute Force approach: {brute}");
        }
    }
}
