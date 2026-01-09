using System;
using System.Collections.Generic;

namespace HashMapProblems
{
    /// <summary>
    /// Problem: Given an array and a target sum, find if there exists a pair 
    /// of elements whose sum is equal to the target.
    /// 
    /// Approach: Store visited numbers in a hash map and check if target - current_number exists in the map.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(n)
    /// </summary>
    public class CheckForPairWithGivenSum
    {
        public class PairInfo
        {
            public int First { get; set; }
            public int Second { get; set; }

            public PairInfo(int first, int second)
            {
                First = first;
                Second = second;
            }

            public override string ToString()
            {
                return $"({First}, {Second})";
            }
        }

        /// <summary>
        /// Find a pair with given sum using hash map
        /// </summary>
        public static PairInfo FindPair(int[] arr, int target)
        {
            if (arr == null || arr.Length < 2)
                return null;

            HashSet<int> visited = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int complement = target - arr[i];

                if (visited.Contains(complement))
                {
                    return new PairInfo(complement, arr[i]);
                }

                visited.Add(arr[i]);
            }

            return null;
        }

        /// <summary>
        /// Find all pairs with given sum
        /// </summary>
        public static List<PairInfo> FindAllPairs(int[] arr, int target)
        {
            List<PairInfo> result = new List<PairInfo>();
            if (arr == null || arr.Length < 2)
                return result;

            HashSet<int> visited = new HashSet<int>();
            HashSet<int> pairs = new HashSet<int>(); // To avoid duplicate pairs

            for (int i = 0; i < arr.Length; i++)
            {
                int complement = target - arr[i];

                if (visited.Contains(complement) && !pairs.Contains(Math.Min(arr[i], complement)))
                {
                    result.Add(new PairInfo(complement, arr[i]));
                    pairs.Add(Math.Min(arr[i], complement));
                }

                visited.Add(arr[i]);
            }

            return result;
        }

        /// <summary>
        /// Two pointer approach (works on sorted array) - O(n log n)
        /// </summary>
        public static PairInfo FindPairTwoPointer(int[] arr, int target)
        {
            if (arr == null || arr.Length < 2)
                return null;

            Array.Sort(arr);
            int left = 0, right = arr.Length - 1;

            while (left < right)
            {
                int sum = arr[left] + arr[right];

                if (sum == target)
                    return new PairInfo(arr[left], arr[right]);
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
        public static PairInfo FindPairBruteForce(int[] arr, int target)
        {
            if (arr == null || arr.Length < 2)
                return null;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == target)
                        return new PairInfo(arr[i], arr[j]);
                }
            }

            return null;
        }

        public static void Main()
        {
            Console.WriteLine("=== Check for Pair with Given Sum ===\n");

            // Test case 1
            int[] arr1 = { 3, 2, 8, 1, 5 };
            int target1 = 10;

            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Array: {string.Join(", ", arr1)}");
            Console.WriteLine($"Target: {target1}");
            PairInfo pair1 = FindPair(arr1, target1);
            if (pair1 != null)
            {
                Console.WriteLine($"Pair found: {pair1}");
            }
            else
            {
                Console.WriteLine("Pair not found");
            }

            // Test case 2
            Console.WriteLine("\n--- Test Case 2 ---");
            int[] arr2 = { 1, 5, 7, -1, 5 };
            int target2 = 6;

            Console.WriteLine($"Array: {string.Join(", ", arr2)}");
            Console.WriteLine($"Target: {target2}");
            PairInfo pair2 = FindPair(arr2, target2);
            if (pair2 != null)
            {
                Console.WriteLine($"Pair found: {pair2}");
            }
            else
            {
                Console.WriteLine("Pair not found");
            }

            // Test case 3: Find all pairs
            Console.WriteLine("\n--- Test Case 3: Find All Pairs ---");
            int[] arr3 = { 6, 4, 6, 2, 8, 2 };
            int target3 = 10;

            Console.WriteLine($"Array: {string.Join(", ", arr3)}");
            Console.WriteLine($"Target: {target3}");
            var pairs3 = FindAllPairs(arr3, target3);
            Console.WriteLine($"Pairs found: {pairs3.Count}");
            foreach (var p in pairs3)
            {
                Console.WriteLine($"  {p}");
            }

            // Test case 4: No pair exists
            Console.WriteLine("\n--- Test Case 4: No Pair ---");
            int[] arr4 = { 1, 2, 3 };
            int target4 = 100;

            Console.WriteLine($"Array: {string.Join(", ", arr4)}");
            Console.WriteLine($"Target: {target4}");
            PairInfo pair4 = FindPair(arr4, target4);
            if (pair4 != null)
            {
                Console.WriteLine($"Pair found: {pair4}");
            }
            else
            {
                Console.WriteLine("Pair not found");
            }

            // Compare approaches
            Console.WriteLine("\n--- Comparison of Approaches ---");
            int[] arr5 = { 2, 7, 11, 15, 3 };
            int target5 = 9;

            Console.WriteLine($"Array: {string.Join(", ", arr5)}");
            Console.WriteLine($"Target: {target5}");

            var hashMap = FindPair(arr5, target5);
            var twoPointer = FindPairTwoPointer(arr5, target5);
            var brute = FindPairBruteForce(arr5, target5);

            Console.WriteLine($"Hash Map: {hashMap}");
            Console.WriteLine($"Two Pointer: {twoPointer}");
            Console.WriteLine($"Brute Force: {brute}");
        }
    }
}
