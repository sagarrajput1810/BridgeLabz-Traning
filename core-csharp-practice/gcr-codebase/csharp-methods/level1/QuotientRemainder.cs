// Find quotient and remainder
using System;

class QuotientRemainder {
    static void Main(string[] args) {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter divisor: ");
        int divisor = Convert.ToInt32(Console.ReadLine());

        int[] result = Solve(number, divisor);

        Console.WriteLine("Quotient = " + result[0]);
        Console.WriteLine("Remainder = " + result[1]);
    }

    // function to calculate the quotient and remainder
    static int[] Solve(int number, int divisor) {
        return new int[] { number / divisor, number % divisor };
    }
}
