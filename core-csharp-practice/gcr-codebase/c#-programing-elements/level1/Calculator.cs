using System;

class Calculator
{
    static void Main()
    {
        Console.Write("Enter n1: ");
        double n1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter n2: ");
        double n2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Addition: " + (n1 + n2));
        Console.WriteLine("Subtraction: " + (n1 - n2));
        Console.WriteLine("Multiplication: " + (n1 * n2));
        Console.WriteLine("Division: " + (n1 / n2));
    }
}
