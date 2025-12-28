using System;

class FactorialRecursion
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        long result = Factorial(number);
        Console.WriteLine("Factorial is: " + result);
    }

    static long Factorial(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        return n * Factorial(n - 1);
    }
}
