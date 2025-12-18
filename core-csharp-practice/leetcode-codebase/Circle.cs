using System;

class Circle{
    static void Main()
    {
		Console.Write("Enter radius: ");
		int r = int.Parse(Console.ReadLine());
		Console.WriteLine(3.14 * r * r);
	}
}