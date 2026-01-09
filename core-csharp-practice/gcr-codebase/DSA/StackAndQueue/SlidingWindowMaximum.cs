using System;
using System.Collections.Generic;

namespace StackAndQueueProblems
{
    /// <summary>
    /// Problem: Given an array and a window size k, find the maximum element 
    /// in each sliding window of size k.
    /// 
    /// Approach: Use a deque (double-ended queue) to maintain indices of useful 
    /// elements in each window.
    /// 
    /// Time Complexity: O(n)
    /// Space Complexity: O(k)
    /// </summary>
    public class SlidingWindowMaximum
    {
        /// <summary>
        /// Find maximum in each sliding window using deque
        /// </summary>
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 0)
                return new int[0];

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            Deque<int> deque = new Deque<int>(); // Stores indices

            for (int i = 0; i < n; i++)
            {
                // Remove indices that are outside the current window
                while (deque.Count > 0 && deque.Front() < i - k + 1)
                {
                    deque.RemoveFront();
                }

                // Remove indices of smaller elements (they can't be max in current window)
                while (deque.Count > 0 && nums[deque.Back()] <= nums[i])
                {
                    deque.RemoveBack();
                }

                // Add current element index
                deque.AddBack(i);

                // Add first element of window to result
                if (i >= k - 1)
                {
                    result[i - k + 1] = nums[deque.Front()];
                }
            }

            return result;
        }

        /// <summary>
        /// Brute force approach - O(n*k)
        /// </summary>
        public static int[] MaxSlidingWindowBruteForce(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 0)
                return new int[0];

            int n = nums.Length;
            int[] result = new int[n - k + 1];

            for (int i = 0; i <= n - k; i++)
            {
                int max = nums[i];
                for (int j = i; j < i + k; j++)
                {
                    max = Math.Max(max, nums[j]);
                }
                result[i] = max;
            }

            return result;
        }

        /// <summary>
        /// Using PriorityQueue (Max Heap) approach - O(n log n)
        /// </summary>
        public static int[] MaxSlidingWindowUsingHeap(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 0)
                return new int[0];

            int n = nums.Length;
            int[] result = new int[n - k + 1];
            
            // Max heap with custom comparer (stores value, index)
            var maxHeap = new PriorityQueue<(int value, int index), int>();
            
            for (int i = 0; i < k; i++)
            {
                maxHeap.Enqueue((nums[i], i), -nums[i]);
            }

            result[0] = maxHeap.Peek().value;

            for (int i = k; i < n; i++)
            {
                // Add new element
                maxHeap.Enqueue((nums[i], i), -nums[i]);

                // Remove elements outside current window
                while (maxHeap.Count > 0 && maxHeap.Peek().index < i - k + 1)
                {
                    maxHeap.Dequeue();
                }

                result[i - k + 1] = maxHeap.Peek().value;
            }

            return result;
        }

        public static void Main()
        {
            Console.WriteLine("=== Sliding Window Maximum ===\n");

            // Test case 1
            int[] nums1 = { 1, 3, 1, 2, 0, 5 };
            int k1 = 3;
            int[] result1 = MaxSlidingWindow(nums1, k1);

            Console.WriteLine("Test Case 1:");
            Console.WriteLine($"Array: {string.Join(", ", nums1)}");
            Console.WriteLine($"Window Size: {k1}");
            Console.WriteLine($"Result: {string.Join(", ", result1)}");

            // Test case 2
            Console.WriteLine("\n--- Test Case 2 ---");
            int[] nums2 = { 1 };
            int k2 = 1;
            int[] result2 = MaxSlidingWindow(nums2, k2);

            Console.WriteLine($"Array: {string.Join(", ", nums2)}");
            Console.WriteLine($"Window Size: {k2}");
            Console.WriteLine($"Result: {string.Join(", ", result2)}");

            // Test case 3
            Console.WriteLine("\n--- Test Case 3 ---");
            int[] nums3 = { 9, 11, 3, 5, 7, 8, 4 };
            int k3 = 3;
            int[] result3 = MaxSlidingWindow(nums3, k3);

            Console.WriteLine($"Array: {string.Join(", ", nums3)}");
            Console.WriteLine($"Window Size: {k3}");
            Console.WriteLine($"Result: {string.Join(", ", result3)}");

            // Compare all three approaches
            Console.WriteLine("\n--- Comparison of Approaches ---");
            int[] nums4 = { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k4 = 3;

            int[] dequeResult = MaxSlidingWindow(nums4, k4);
            int[] bruteResult = MaxSlidingWindowBruteForce(nums4, k4);
            int[] heapResult = MaxSlidingWindowUsingHeap(nums4, k4);

            Console.WriteLine($"Array: {string.Join(", ", nums4)}, Window: {k4}");
            Console.WriteLine($"Deque: {string.Join(", ", dequeResult)}");
            Console.WriteLine($"BruteForce: {string.Join(", ", bruteResult)}");
            Console.WriteLine($"Heap: {string.Join(", ", heapResult)}");

            // Test case 4: All same elements
            Console.WriteLine("\n--- Test Case 4: All Same ---");
            int[] nums5 = { 5, 5, 5, 5, 5 };
            int k5 = 3;
            int[] result5 = MaxSlidingWindow(nums5, k5);

            Console.WriteLine($"Array: {string.Join(", ", nums5)}");
            Console.WriteLine($"Window Size: {k5}");
            Console.WriteLine($"Result: {string.Join(", ", result5)}");
        }
    }

    /// <summary>
    /// Simple Deque implementation
    /// </summary>
    public class Deque<T>
    {
        private LinkedList<T> items;

        public Deque()
        {
            items = new LinkedList<T>();
        }

        public int Count => items.Count;

        public void AddFront(T value)
        {
            items.AddFirst(value);
        }

        public void AddBack(T value)
        {
            items.AddLast(value);
        }

        public T Front()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Deque is empty");
            return items.First.Value;
        }

        public T Back()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Deque is empty");
            return items.Last.Value;
        }

        public void RemoveFront()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Deque is empty");
            items.RemoveFirst();
        }

        public void RemoveBack()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Deque is empty");
            items.RemoveLast();
        }
    }
}
