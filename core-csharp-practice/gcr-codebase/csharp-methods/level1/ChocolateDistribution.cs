// Divide chocolates among children
using System;

class ChocolateDistribution {
    static void Main(string[] args) {
        Console.Write("Enter chocolates: ");
        int chocolates = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter children: ");
        int children = Convert.ToInt32(Console.ReadLine());

        int[] result = solve(chocolates, children);

        Console.WriteLine("Each child gets = " + result[0]);
        Console.WriteLine("Remaining chocolates = " + result[1]);
    }

    static int[] solve(int number, int divisor) {
        return new int[] { number / divisor, number % divisor };
    }
}
