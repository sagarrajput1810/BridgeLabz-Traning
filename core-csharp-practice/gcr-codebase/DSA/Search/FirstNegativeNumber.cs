namespace SearchProblems
{
    public static class FirstNegativeNumberProblem
    {
        public static int? Find(int[] nums)
        {
            if (nums == null) return null;
            foreach (int n in nums)
            {
                if (n < 0) return n;
            }
            return null;
        }
    }
}
