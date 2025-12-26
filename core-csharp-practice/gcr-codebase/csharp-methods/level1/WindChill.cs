// Calculate wind chill temperature
using System;

class WindChill {
    static void Main(string[] args) {
        Console.Write("Enter temperature: ");
        double temp = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter wind speed: ");
        double speed = Convert.ToDouble(Console.ReadLine());

        double result = CalculateWindChill(temp, speed);
        Console.WriteLine("Wind Chill = " + result);
    }

    static double CalculateWindChill(double temperature, double windSpeed) {
        return 35.74 + 0.6215 * temperature +
               (0.4275 * temperature - 35.75) * Math.Pow(windSpeed, 0.16);
    }
}
