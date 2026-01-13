namespace SearchProblems
{
    public static class FirstAndLastOccurrenceProblem
    {
        public static (int first, int last) Find(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0) return (-1, -1);
            int first = FindBound(nums, target, true);
            int last = FindBound(nums, target, false);
            return (first, last);
        }

        private static int FindBound(int[] nums, int target, bool searchLeft)
        {
            int left = 0;
            int right = nums.Length - 1;
            int result = -1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target)
                {
                    result = mid;
                    if (searchLeft)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return result;
        }
    }
}
