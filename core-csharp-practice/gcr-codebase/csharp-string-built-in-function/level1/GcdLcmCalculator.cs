using System;

class GcdLcmCalculator
{
    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        int gcd = FindGCD(a, b);
        int lcm = FindLCM(a, b, gcd);

        Console.WriteLine("GCD: " + gcd);
        Console.WriteLine("LCM: " + lcm);
    }

    static int FindGCD(int x, int y)
    {
        while (y != 0)
        {
            int temp = y;
            y = x % y;
            x = temp;
        }
        return x;
    }

    static int FindLCM(int x, int y, int gcd)
    {
        return (x * y) / gcd;
    }
}
