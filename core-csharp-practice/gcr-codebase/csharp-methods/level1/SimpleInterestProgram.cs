// Calculate Simple Interest using method

using System;

class SimpleInterestProgram {
    static void Main(string[] args) {
        Console.Write("Enter Principal: ");
        double principal = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Rate: ");
        double rate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter Time: ");
        double time = Convert.ToDouble(Console.ReadLine());

        double si = CalculateSimpleInterest(principal, rate, time);

        Console.WriteLine("Simple intrest : " + si);
    }

    // Method to calculate Simple Interest
    static double CalculateSimpleInterest(double p, double r, double t) {
        return (p * r * t) / 100;
    }
}
