// Harshad and digit frequency
using System;

// This program calculates Harshad numbers and digit frequency for a given number
class HarshadNumber {
    static void Main(string[] args) {
        Console.Write("Enter number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int[] digits = GetDigits(number);

        Console.WriteLine("Sum of Digits = " + SumDigits(digits));
        Console.WriteLine("Sum of Squares = " + SumSquares(digits));
        Console.WriteLine("Harshad Number = " + IsHarshad(number, digits));

        int[,] freq = DigitFrequency(digits);
        Console.WriteLine("Digit Frequency:");
        for (int i = 0; i < 10; i++)
            if (freq[i, 1] > 0)
                Console.WriteLine(freq[i, 0] + " -> " + freq[i, 1]);
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

    static int SumDigits(int[] digits) {
        int sum = 0;
        foreach (int d in digits) sum += d;
        return sum;
    }

    static double SumSquares(int[] digits) {
        double sum = 0;
        foreach (int d in digits) sum += Math.Pow(d, 2);
        return sum;
    }

    static bool IsHarshad(int number, int[] digits) {
        return number % SumDigits(digits) == 0;
    }

    static int[,] DigitFrequency(int[] digits) {
        int[,] freq = new int[10, 2];
        for (int i = 0; i < 10; i++) freq[i, 0] = i;

        foreach (int d in digits)
            freq[d, 1]++;

        return freq;
    }
}
