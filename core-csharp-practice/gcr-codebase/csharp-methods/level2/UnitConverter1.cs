using System;

class UnitConverter1 {
    static void Main(string[] args) {
        Console.WriteLine("Length Unit Converter");
        Console.WriteLine("Choose conversion type:");
        Console.WriteLine("1. Kilometers to Miles");
        Console.WriteLine("2. Miles to Kilometers");
        Console.WriteLine("3. Meters to Feet");
        Console.WriteLine("4. Feet to Meters");

        Console.Write("Enter your choice (1-4): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value to convert: ");
        double value = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (choice) {
            case 1:
                result = ConvertKmToMiles(value);
                Console.WriteLine(value + " km = " + result.ToString("F2") + " miles");
                break;
            case 2:
                result = ConvertMilesToKm(value);
                Console.WriteLine(value + " miles = " + result.ToString("F2") + " km");
                break;
            case 3:
                result = ConvertMetersToFeet(value);
                Console.WriteLine(value + " meters = " + result.ToString("F2") + " feet");
                break;
            case 4:
                result = ConvertFeetToMeters(value);
                Console.WriteLine(value + " feet = " + result.ToString("F2") + " meters");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    // Methods written in old-style syntax
    static double ConvertKmToMiles(double km) { 
        return km * 0.621371; 
    }
    static double ConvertMilesToKm(double miles) { 
        return miles * 1.60934; 
    }
    static double ConvertMetersToFeet(double meters) { 
        return meters * 3.28084; 
    }
    static double ConvertFeetToMeters(double feet) { 
        return feet * 0.3048; 
    }
}
