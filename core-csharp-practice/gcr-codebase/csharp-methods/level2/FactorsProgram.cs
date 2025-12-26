// Find factors and calculate sum, sum of squares, and product
using System;

class FactorsProgram {
    static void Main(string[] args) {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] factors = FindFactors(number);

        Console.WriteLine("Factors:");
        foreach (int f in factors)
            Console.Write(f + " ");

        Console.WriteLine("\nSum = " + FindSum(factors));
        Console.WriteLine("Sum of Squares = " + FindSumOfSquares(factors));
        Console.WriteLine("Product = " + FindProduct(factors));
    }

    static int[] FindFactors(int number) {
        int count = 0;

        // Count factors
        for (int i = 1; i <= number; i++)
            if (number % i == 0) count++;

        int[] factors = new int[count];
        int index = 0;

        // Store factors
        for (int i = 1; i <= number; i++)
            if (number % i == 0)
                factors[index++] = i;

        return factors;
    }

    static int FindSum(int[] factors) {
        int sum = 0;
        foreach (int f in factors) sum += f;
        return sum;
    }

    static double FindSumOfSquares(int[] factors) {
        double sum = 0;
        foreach (int f in factors)
            sum += Math.Pow(f, 2);
        return sum;
    }

    static int FindProduct(int[] factors) {
        int product = 1;
        foreach (int f in factors)
            product *= f;
        return product;
    }
}
