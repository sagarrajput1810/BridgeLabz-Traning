using System;
using System.Linq;

namespace SearchProblems
{
    public static class ChallengeSolutionProblem
    {
        public static int FirstMissingPositiveLinear(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 1;
            bool[] seen = new bool[nums.Length + 1];
            foreach (int n in nums)
            {
                if (n > 0 && n <= nums.Length)
                {
                    seen[n] = true;
                }
            }
            for (int i = 1; i < seen.Length; i++)
            {
                if (!seen[i]) return i;
            }
            return nums.Length + 1;
        }

        public static int BinarySearchSorted(int[] sortedNums, int target)
        {
            if (sortedNums == null) return -1;
            int left = 0;
            int right = sortedNums.Length - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (sortedNums[mid] == target) return mid;
                if (sortedNums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }
            return -1;
        }

        public static (int firstMissingPositive, int targetIndex) Solve(int[] numbers, int target)
        {
            int firstMissing = FirstMissingPositiveLinear(numbers);
            int[] sortedCopy = numbers?.ToArray() ?? Array.Empty<int>();
            Array.Sort(sortedCopy);
            int foundIndex = BinarySearchSorted(sortedCopy, target);
            return (firstMissing, foundIndex);
        }
    }
}
