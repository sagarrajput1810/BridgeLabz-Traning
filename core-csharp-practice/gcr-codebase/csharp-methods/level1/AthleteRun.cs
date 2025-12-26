// Calculate number of rounds to complete 5 km

using System;

class AthleteRun {
    static void Main(string[] args) {
        Console.Write("Enter side 1: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 2: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter side 3: ");
        double c = Convert.ToDouble(Console.ReadLine());

        double rounds = CalculateRounds(a, b, c);
        Console.WriteLine("Number of rounds = " + rounds);
    }

    // Method to calculate rounds
    static double CalculateRounds(double s1, double s2, double s3) {
        double perimeter = s1 + s2 + s3;
        return 5000 / perimeter;
    }
}
