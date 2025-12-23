using System;

class IsHarshadNumber
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an integer:");
        int number = Convert.ToInt32(Console.ReadLine());
        bool isHarshad = CheckHarshadNumber(number);
        if (isHarshad)
        {
            Console.WriteLine($"{number} is a Harshad number.");
        }
        else
        {
            Console.WriteLine($"{number} is not a Harshad number.");
        }
    }
}