namespace SearchProblems
{
    public static class SearchIn2DSortedMatrixProblem
    {
        public static (int row, int col) Search(int[,] matrix, int target)
        {
            if (matrix == null) return (-1, -1);
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int left = 0;
            int right = rows * cols - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int r = mid / cols;
                int c = mid % cols;
                int value = matrix[r, c];
                if (value == target) return (r, c);
                if (value < target) left = mid + 1;
                else right = mid - 1;
            }
            return (-1, -1);
        }
    }
}
