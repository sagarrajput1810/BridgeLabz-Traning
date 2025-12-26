// Find youngest and tallest
using System;

class FriendsComparison {
    static void Main(string[] args) {
        string[] names = { "Amar", "Akbar", "Anthony" };
        int[] ages = new int[3];
        double[] heights = new double[3];

        for (int i = 0; i < 3; i++) {
            Console.Write("Enter age of " + names[i] + ": ");
            ages[i] = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter height: ");
            heights[i] = Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine("Youngest: " + names[FindYoungest(ages)]);
        Console.WriteLine("Tallest: " + names[FindTallest(heights)]);
    }

    static int FindYoungest(int[] ages) {
        int min = 0;
        for (int i = 1; i < ages.Length; i++)
            if (ages[i] < ages[min]) min = i;
        return min;
    }

    static int FindTallest(double[] heights) {
        int max = 0;
        for (int i = 1; i < heights.Length; i++)
            if (heights[i] > heights[max]) max = i;
        return max;
    }
}
