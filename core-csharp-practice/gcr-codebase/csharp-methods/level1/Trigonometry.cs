// Calculate sin, cos, tan using Math class
using System;

class Trigonometry {
    static void Main(string[] args) {
        Console.Write("Enter angle in degrees: ");
        double angle = Convert.ToDouble(Console.ReadLine());

        double[] result = CalculateTrigonometricFunctions(angle);

        Console.WriteLine("Sin = " + result[0]);
        Console.WriteLine("Cos = " + result[1]);
        Console.WriteLine("Tan = " + result[2]);
    }

    // function to calculate the trignometric values of differnet value
    static double[] CalculateTrigonometricFunctions(double angle) {
        double radian = angle * Math.PI / 180;
        return new double[] {
            Math.Sin(radian),
            Math.Cos(radian),
            Math.Tan(radian)
        };
    }
}
