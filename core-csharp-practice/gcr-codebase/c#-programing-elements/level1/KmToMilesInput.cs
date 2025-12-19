using System;

class KmToMilesInput
{
    static void Main()
    {
        Console.Write("Enter distance in km: ");
        double km = Convert.ToDouble(Console.ReadLine());

        double miles = km / 1.6;
        Console.WriteLine(km);
    }
}
