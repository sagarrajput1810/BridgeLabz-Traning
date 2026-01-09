using System;
using System.Collections.Generic;

namespace HashMapProblems
{
    /// <summary>
    /// Problem: Given an array and a target sum, find two indices such that 
    /// their values add up to the target.
    /// 
    /// Approach: Use a hash map to store the index of each element as you iterate. 
    /// Check if target - current_element exists in the map.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(n)
    /// </summary>
    public class TwoSumProblem
    {
        public class SolutionIndices
        {
            public int Index1 { get; set; }
            public int Index2 { get; set; }

            public SolutionIndices(int idx1, int idx2)
            {
                Index1 = idx1;
                Index2 = idx2;
            }

            public override string ToString()
            {
                return $"[{Index1}, {Index2}]";
            }
        }

        /// <summary>
        /// Find two indices that add up to target using hash map
        /// </summary>
        public static SolutionIndices TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
                return null;

            Dictionary<int, int> numIndexMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                if (numIndexMap.ContainsKey(complement))
                {
                    return new SolutionIndices(numIndexMap[complement], i);
                }

                // Store only the first occurrence of each number
                if (!numIndexMap.ContainsKey(nums[i]))
                {
                    numIndexMap[nums[i]] = i;
                }
            }

            return null;
        }

        /// <summary>
        /// Find all pairs of indices that add up to target
        /// </summary>
        public static List<SolutionIndices> TwoSumAll(int[] nums, int target)
        {
            List<SolutionIndices> result = new List<SolutionIndices>();
            if (nums == null || nums.Length < 2)
                return result;

            Dictionary<int, List<int>> numIndexMap = new Dictionary<int, List<int>>();

            // Build the map
            for (int i = 0; i < nums.Length; i++)
            {
                if (!numIndexMap.ContainsKey(nums[i]))
                {
                    numIndexMap[nums[i]] = new List<int>();
                }
                numIndexMap[nums[i]].Add(i);
            }

            // Find all pairs
            HashSet<int> visitedComplements = new HashSet<int>();

            foreach (var kvp in numIndexMap)
            {
                int num = kvp.Key;
                List<int> indices = kvp.Value;
                int complement = target - num;

                // Avoid duplicate pairs
                if (visitedComplements.Contains(complement))
                    continue;

                if (numIndexMap.ContainsKey(complement))
                {
                    if (num == complement)
                    {
                        // Same number, need at least 2 occurrences
                        if (indices.Count >= 2)
                        {
                            result.Add(new SolutionIndices(indices[0], indices[1]));
                        }
                    }
                    else
                    {
                        // Different numbers
                        result.Add(new SolutionIndices(indices[0], numIndexMap[complement][0]));
                    }

                    visitedComplements.Add(num);
                }
            }

            return result;
        }

        /// <summary>
        /// Two pointer approach (works on sorted array) - O(n log n)
        /// </summary>
        public static SolutionIndices TwoSumTwoPointer(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
                return null;

            // Create array of (value, original_index) and sort
            var indexed = new (int value, int originalIndex)[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                indexed[i] = (nums[i], i);
            }

            Array.Sort(indexed, (a, b) => a.value.CompareTo(b.value));

            int left = 0, right = indexed.Length - 1;

            while (left < right)
            {
                int sum = indexed[left].value + indexed[right].value;

                if (sum == target)
                {
                    return new SolutionIndices(
                        indexed[left].originalIndex,
                        indexed[right].originalIndex
                    );
                }
                else if (sum < target)
                    left++;
                else
                    right--;
            }

            return null;
        }

        /// <summary>
        /// Brute force approach - O(n^2)
        /// </summary>
        public static SolutionIndices TwoSumBruteForce(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
                return null;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new SolutionIndices(i, j);
                    }
                }
            }

            return null;
        }

        public static void Main()
        {
            Console.WriteLine("=== Two Sum Problem ===\n");

            // Test case 1
            int[] nums1 = { 2, 7, 11, 15 };
            int target1 = 9;

            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Array: {string.Join(", ", nums1)}");
            Console.WriteLine($"Target: {target1}");
            var result1 = TwoSum(nums1, target1);
            if (result1 != null)
            {
                Console.WriteLine($"Indices: {result1}");
                Console.WriteLine($"Values: {nums1[result1.Index1]} + {nums1[result1.Index2]} = {target1}");
            }
            else
            {
                Console.WriteLine("No solution found");
            }

            // Test case 2
            Console.WriteLine("\n--- Test Case 2 ---");
            int[] nums2 = { 3, 2, 4 };
            int target2 = 6;

            Console.WriteLine($"Array: {string.Join(", ", nums2)}");
            Console.WriteLine($"Target: {target2}");
            var result2 = TwoSum(nums2, target2);
            if (result2 != null)
            {
                Console.WriteLine($"Indices: {result2}");
                Console.WriteLine($"Values: {nums2[result2.Index1]} + {nums2[result2.Index2]} = {target2}");
            }
            else
            {
                Console.WriteLine("No solution found");
            }

            // Test case 3: No solution
            Console.WriteLine("\n--- Test Case 3: No Solution ---");
            int[] nums3 = { 1, 2, 3 };
            int target3 = 100;

            Console.WriteLine($"Array: {string.Join(", ", nums3)}");
            Console.WriteLine($"Target: {target3}");
            var result3 = TwoSum(nums3, target3);
            if (result3 != null)
            {
                Console.WriteLine($"Indices: {result3}");
            }
            else
            {
                Console.WriteLine("No solution found");
            }

            // Test case 4: Duplicates
            Console.WriteLine("\n--- Test Case 4: With Duplicates ---");
            int[] nums4 = { 3, 3 };
            int target4 = 6;

            Console.WriteLine($"Array: {string.Join(", ", nums4)}");
            Console.WriteLine($"Target: {target4}");
            var result4 = TwoSum(nums4, target4);
            if (result4 != null)
            {
                Console.WriteLine($"Indices: {result4}");
                Console.WriteLine($"Values: {nums4[result4.Index1]} + {nums4[result4.Index2]} = {target4}");
            }
            else
            {
                Console.WriteLine("No solution found");
            }

            // Test case 5: Find all pairs
            Console.WriteLine("\n--- Test Case 5: Find All Pairs ---");
            int[] nums5 = { 1, 5, 7, -1, 5 };
            int target5 = 6;

            Console.WriteLine($"Array: {string.Join(", ", nums5)}");
            Console.WriteLine($"Target: {target5}");
            var results5 = TwoSumAll(nums5, target5);
            Console.WriteLine($"Pairs found: {results5.Count}");
            foreach (var pair in results5)
            {
                Console.WriteLine($"  Indices: {pair}, Values: {nums5[pair.Index1]} + {nums5[pair.Index2]} = {target5}");
            }

            // Compare approaches
            Console.WriteLine("\n--- Comparison of Approaches ---");
            int[] nums6 = { 2, 7, 11, 15, 3 };
            int target6 = 9;

            Console.WriteLine($"Array: {string.Join(", ", nums6)}");
            Console.WriteLine($"Target: {target6}");

            var hashMap = TwoSum(nums6, target6);
            var twoPointer = TwoSumTwoPointer(nums6, target6);
            var brute = TwoSumBruteForce(nums6, target6);

            Console.WriteLine($"Hash Map: {hashMap}");
            Console.WriteLine($"Two Pointer: {twoPointer}");
            Console.WriteLine($"Brute Force: {brute}");
        }
    }
}
