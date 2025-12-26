// Euclidean distance and line equation
using System;

class DistanceAndLine {
    static void Main(string[] args) {
        Console.Write("Enter x1 y1: ");
        double x1 = Convert.ToDouble(Console.ReadLine());
        double y1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter x2 y2: ");
        double x2 = Convert.ToDouble(Console.ReadLine());
        double y2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Distance = " + FindDistance(x1, y1, x2, y2));

        double[] line = FindLineEquation(x1, y1, x2, y2);
        Console.WriteLine("Equation: y = " + line[0] + "x + " + line[1]);
    }

    static double FindDistance(double x1, double y1, double x2, double y2) {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    static double[] FindLineEquation(double x1, double y1, double x2, double y2) {
        double m = (y2 - y1) / (x2 - x1);
        double b = y1 - m * x1;
        return new double[] { m, b };
    }
}
