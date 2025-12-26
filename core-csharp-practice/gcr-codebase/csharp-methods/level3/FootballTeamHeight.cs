// Find shortest, tallest and mean height
using System;

class FootballTeamHeight {
    static void Main(string[] args) {
        int[] heights = GenerateHeights(11);

        Console.WriteLine("Heights:");
        foreach (int h in heights)
            Console.Write(h + " ");

        Console.WriteLine("\nShortest = " + FindShortest(heights));
        Console.WriteLine("Tallest = " + FindTallest(heights));
        Console.WriteLine("Mean Height = " + FindMean(heights));
    }

    static int[] GenerateHeights(int size) {
        Random r = new Random();
        int[] arr = new int[size];

        for (int i = 0; i < size; i++)
            arr[i] = r.Next(150, 251); // 3-digit height

        return arr;
    }

    static int FindShortest(int[] arr) {
        int min = arr[0];
        foreach (int h in arr)
            if (h < min) min = h;
        return min;
    }

    static int FindTallest(int[] arr) {
        int max = arr[0];
        foreach (int h in arr)
            if (h > max) max = h;
        return max;
    }

    static double FindMean(int[] arr) {
        int sum = 0;
        foreach (int h in arr) sum += h;
        return (double)sum / arr.Length;
    }
}
