// Check number is positive, negative or zero

using System;

class NumberCheck {
    static void Main(string[] args) {
        Console.Write("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int result = CheckNumber(number);
        Console.WriteLine("Result = " + result);
    }

    // Method returns -1, 0, or 1
    static int CheckNumber(int num) {
        if (num > 0) return 1;
        else if (num < 0) return -1;
        else return 0;
    }
}
