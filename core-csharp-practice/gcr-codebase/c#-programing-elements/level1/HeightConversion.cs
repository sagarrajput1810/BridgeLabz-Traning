using System;

class HeightConversion
{
    static void Main()
    {
        Console.Write("Enter height in cm: ");
        double cm = Convert.ToDouble(Console.ReadLine());

        double inches = cm / 2.54;
        double feet = inches / 12;

        Console.WriteLine(
            "Your Height in cm is " + cm + " while in feet is " + feet + " and inches is " + inches
        );
    }
}
