namespace SearchProblems
{
    public static class FindRotationPointProblem
    {
        public static int FindIndex(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;
            int left = 0;
            int right = nums.Length - 1;
            if (nums[left] <= nums[right]) return 0;

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > nums[right])
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
