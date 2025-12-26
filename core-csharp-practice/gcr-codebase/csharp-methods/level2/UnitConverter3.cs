using System;

class UnitConverter3 {
    static void Main(string[] args) {
        Console.WriteLine("Unit Converter (Temperature, Weight, Volume)");
        Console.WriteLine("Choose conversion type:");
        Console.WriteLine("1. Fahrenheit to Celsius");
        Console.WriteLine("2. Celsius to Fahrenheit");
        Console.WriteLine("3. Pounds to Kilograms");
        Console.WriteLine("4. Kilograms to Pounds");
        Console.WriteLine("5. Gallons to Liters");
        Console.WriteLine("6. Liters to Gallons");

        Console.Write("Enter your choice (1-6): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value to convert: ");
        double value = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (choice) {
            case 1:
                result = FahrenheitToCelsius(value);
                Console.WriteLine(value + " °F = " + result.ToString("F2") + " °C");
                break;
            case 2:
                result = CelsiusToFahrenheit(value);
                Console.WriteLine(value + " °C = " + result.ToString("F2") + " °F");
                break;
            case 3:
                result = PoundsToKg(value);
                Console.WriteLine(value + " pounds = " + result.ToString("F2") + " kg");
                break;
            case 4:
                result = KgToPounds(value);
                Console.WriteLine(value + " kg = " + result.ToString("F2") + " pounds");
                break;
            case 5:
                result = GallonsToLiters(value);
                Console.WriteLine(value + " gallons = " + result.ToString("F2") + " liters");
                break;
            case 6:
                result = LitersToGallons(value);
                Console.WriteLine(value + " liters = " + result.ToString("F2") + " gallons");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    // Conversion methods (classic syntax for C# 5)
    static double FahrenheitToCelsius(double f) { 
        return (f - 32) * 5.0 / 9.0; 
    }
    static double CelsiusToFahrenheit(double c) { 
        return (c * 9.0 / 5.0) + 32; 
    }
    static double PoundsToKg(double p) { 
        return p * 0.453592; 
    }
    static double KgToPounds(double kg) { 
        return kg * 2.20462; 
    }
    static double GallonsToLiters(double g) { 
        return g * 3.78541; 
    }
    static double LitersToGallons(double l) { 
        return l * 0.264172; 
    }
}
