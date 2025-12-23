using System;

class CountDigitInteger
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an integer:");
        int number = Convert.ToInt32(Console.ReadLine());
        int count = CountDigits(number);
        Console.WriteLine($"The number of digits in {number} is: {count}");
    }

    static int CountDigits(int num)
    {
        if (num == 0) return 1; // Special case for 0

        int count = 0;
        num = Math.Abs(num); // Handle negative numbers

        while (num > 0)
        {
            num /= 10;
            count++;
        }

        return count;
    }
}