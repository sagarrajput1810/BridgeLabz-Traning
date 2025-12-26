// Random numbers average, min, max
using System;

class RandomStats {
    static void Main(string[] args) {
        int[] numbers = Generate4DigitRandomArray(5);
        double[] result = FindAverageMinMax(numbers);

        Console.WriteLine("Average = " + result[0]);
        Console.WriteLine("Min = " + result[1]);
        Console.WriteLine("Max = " + result[2]);
    }

    static int[] Generate4DigitRandomArray(int size) {
        Random r = new Random();
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
            arr[i] = r.Next(1000, 9999);

        return arr;
    }

    static double[] FindAverageMinMax(int[] numbers) {
        int min = numbers[0], max = numbers[0], sum = 0;

        foreach (int n in numbers) {
            sum += n;
            min = Math.Min(min, n);
            max = Math.Max(max, n);
        }

        return new double[] { (double)sum / numbers.Length, min, max };
    }
}
