// Find smallest and largest of 3 numbers
using System;

class MinMax {
    static void Main(string[] args) {
        Console.Write("Enter number 1: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter number 2: ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter number 3: ");
        int c = Convert.ToInt32(Console.ReadLine());

        int[] result = FindMinMax(a, b, c);
        Console.WriteLine("Smallest = " + result[0]);
        Console.WriteLine("Largest = " + result[1]);
    }

    // funtion to calculate the min as well ax max and return the arr of min and max
    static int[] FindMinMax(int n1, int n2, int n3) {
        int smallest = Math.Min(n1, Math.Min(n2, n3));
        int largest = Math.Max(n1, Math.Max(n2, n3));
        return new int[] { smallest, largest };
    }
}
