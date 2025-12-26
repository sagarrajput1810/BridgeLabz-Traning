// Sum of n natural numbers

using System;

class SumNatural {
    static void Main(string[] args) {
        Console.Write("Enter n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int sum = CalculateSum(n);
        Console.WriteLine("Sum = " + sum);
    }

    // Method using loop to cal culate the sum of n natural nuber
    static int CalculateSum(int n) {
        int sum = 0;
        for (int i = 1; i <= n; i++)
            sum += i;
        return sum;
    }
}
