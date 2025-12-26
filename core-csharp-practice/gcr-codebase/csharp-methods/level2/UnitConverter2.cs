using System;

class UnitConverter2 {
    static void Main(string[] args) {
        Console.WriteLine("Length Unit Converter (Yards, Feet, Inches, Meters, Centimeters)");
        Console.WriteLine("Choose conversion type:");
        Console.WriteLine("1. Yards to Feet");
        Console.WriteLine("2. Feet to Yards");
        Console.WriteLine("3. Meters to Inches");
        Console.WriteLine("4. Inches to Meters");
        Console.WriteLine("5. Inches to Centimeters");

        Console.Write("Enter your choice (1-5): ");
        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter value to convert: ");
        double value = Convert.ToDouble(Console.ReadLine());

        double result = 0;

        switch (choice) {
            case 1:
                result = ConvertYardsToFeet(value);
                Console.WriteLine(value + " yards = " + result.ToString("F2") + " feet");
                break;
            case 2:
                result = ConvertFeetToYards(value);
                Console.WriteLine(value + " feet = " + result.ToString("F2") + " yards");
                break;
            case 3:
                result = ConvertMetersToInches(value);
                Console.WriteLine(value + " meters = " + result.ToString("F2") + " inches");
                break;
            case 4:
                result = ConvertInchesToMeters(value);
                Console.WriteLine(value + " inches = " + result.ToString("F2") + " meters");
                break;
            case 5:
                result = ConvertInchesToCentimeters(value);
                Console.WriteLine(value + " inches = " + result.ToString("F2") + " centimeters");
                break;
            default:
                Console.WriteLine("Invalid choice!");
                break;
        }
    }

    // Conversion methods (classic syntax for C# 5)
    static double ConvertYardsToFeet(double yards) { 
        return yards * 3; 
    }
    static double ConvertFeetToYards(double feet) { 
        return feet * 0.333333; 
    }
    static double ConvertMetersToInches(double meters) { 
        return meters * 39.3701; 
    }
    static double ConvertInchesToMeters(double inches) { 
        return inches * 0.0254; 
    }
    static double ConvertInchesToCentimeters(double inches) { 
        return inches * 2.54; 
    }
}
