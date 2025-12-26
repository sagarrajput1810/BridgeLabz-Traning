using System;

class NumberAnalysis {
    static void Main(string[] args) {
        int[] nums = new int[5];

        for (int i = 0; i < 5; i++) {
            Console.Write("Enter number: ");
            nums[i] = Convert.ToInt32(Console.ReadLine());

            if (IsPositive(nums[i])) {
                if (IsEven(nums[i]))
                    Console.WriteLine("Positive Even");
                else
                    Console.WriteLine("Positive Odd");
            } else {
                Console.WriteLine("Negative");
            }
        }

        int compare = Compare(nums[0], nums[4]);
        Console.WriteLine("Comparison Result = " + compare);
    }

    // Old-style method bodies (compatible with C# 5)
    static bool IsPositive(int n) {
        return n >= 0;
    }

    static bool IsEven(int n) {
        return n % 2 == 0;
    }

    static int Compare(int a, int b) {
        if (a > b) return 1;
        if (a == b) return 0;
        return -1;
    }
}
