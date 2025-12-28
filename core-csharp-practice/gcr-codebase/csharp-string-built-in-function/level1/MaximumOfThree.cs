using System;

class MaximumOfThree
{
    static void Main(string[] args)
    {
        int a = ReadNumber("Enter first number: ");
        int b = ReadNumber("Enter second number: ");
        int c = ReadNumber("Enter third number: ");

        int max = FindMaximum(a, b, c);
        Console.WriteLine("Maximum number is: " + max);
    }

    static int ReadNumber(string message)
    {
        Console.Write(message);
        return int.Parse(Console.ReadLine());
    }

    static int FindMaximum(int x, int y, int z)
    {
        int max = x;

        if (y > max)
            max = y;

        if (z > max)
            max = z;

        return max;
    }
}
