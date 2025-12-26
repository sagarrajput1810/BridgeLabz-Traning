// Digit-based number properties
using System;

class NumberChecker {
    static void Main(string[] args) {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigits(number);

        Console.WriteLine("Digit Count = " + digits.Length);
        Console.WriteLine("Duck Number = " + IsDuck(digits));
        Console.WriteLine("Armstrong Number = " + IsArmstrong(number, digits));

        int[] large = FindLargestTwo(digits);
        int[] small = FindSmallestTwo(digits);

        Console.WriteLine("Largest = " + large[0] + ", Second Largest = " + large[1]);
        Console.WriteLine("Smallest = " + small[0] + ", Second Smallest = " + small[1]);
    }

    static int[] GetDigits(int number) {
        int temp = number, count = 0;
        while (temp != 0) { count++; temp /= 10; }

        int[] digits = new int[count];
        for (int i = 0; i < count; i++) {
            digits[i] = number % 10;
            number /= 10;
        }
        return digits;
    }

    static bool IsDuck(int[] digits) {
        foreach (int d in digits)
            if (d != 0) return true;
        return false;
    }

    static bool IsArmstrong(int number, int[] digits) {
        int sum = 0;
        foreach (int d in digits)
            sum += (int)Math.Pow(d, digits.Length);
        return sum == number;
    }

    static int[] FindLargestTwo(int[] arr) {
        int first = Int32.MinValue, second = Int32.MinValue;
        foreach (int n in arr) {
            if (n > first) { second = first; first = n; }
            else if (n > second && n != first) second = n;
        }
        return new int[] { first, second };
    }

    static int[] FindSmallestTwo(int[] arr) {
        int first = Int32.MaxValue, second = Int32.MaxValue;
        foreach (int n in arr) {
            if (n < first) { second = first; first = n; }
            else if (n < second && n != first) second = n;
        }
        return new int[] { first, second };
    }
}
