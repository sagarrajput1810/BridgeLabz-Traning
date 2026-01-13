namespace SearchProblems
{
    public static class FindPeakElementProblem
    {
        public static int FindIndex(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] < nums[mid + 1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return left;
        }
    }
}
