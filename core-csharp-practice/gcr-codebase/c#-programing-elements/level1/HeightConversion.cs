using System;

class HeightConversion
{
    static void Main()
    {
        int height = int.Parse(Console.ReadLine());
		Console.Write("Your Height in cm is "+ height+" while in feet is " + (height / (12 * 2.54)) + " and inches is " + (height / 2.54));
    }
}
