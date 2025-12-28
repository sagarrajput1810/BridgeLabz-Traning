using System;

class TemperatureConverter
{
    static void Main(string[] args)
    {
        Console.Write("Enter temperature: ");
        double temp = double.Parse(Console.ReadLine());

        Console.Write("Convert to (C/F): ");
        char choice = Char.ToUpper(Console.ReadLine()[0]);

        if (choice == 'C')
            Console.WriteLine("Temperature in Celsius: " + FahrenheitToCelsius(temp));
        else if (choice == 'F')
            Console.WriteLine("Temperature in Fahrenheit: " + CelsiusToFahrenheit(temp));
    }

    static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5 / 9;
    }

    static double CelsiusToFahrenheit(double c)
    {
        return (c * 9 / 5) + 32;
    }
}
