using System;

class PrimeChecker
{
    static void Main(string[] args)
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());

        bool result = IsPrime(number);

        if (result)
            Console.WriteLine("Prime Number");
        else
            Console.WriteLine("Not a Prime Number");
    }

    static bool IsPrime(int n)
    {
        if (n <= 1)
            return false;

        for (int i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }
}
