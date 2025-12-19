using System;

class SquareSide
{
    static void Main()
    {
        Console.Write("Enter perimeter: ");
        double perimeter = Convert.ToDouble(Console.ReadLine());

        double side = perimeter / 4;
        Console.WriteLine(perimeter);
    }
}
