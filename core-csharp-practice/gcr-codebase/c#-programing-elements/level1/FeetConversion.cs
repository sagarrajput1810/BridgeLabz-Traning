using System;

class FeetConversion
{
    static void Main()
    {
        Console.Write("Enter distance in feet: ");
        double feet = Convert.ToDouble(Console.ReadLine());

        double yards = feet / 3;
        double miles = yards / 1760;

        Console.WriteLine("Miles: " + miles);
    }
}
