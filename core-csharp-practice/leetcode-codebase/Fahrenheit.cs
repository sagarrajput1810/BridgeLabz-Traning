using System;

class Fahrenheit{
    static void Main()
    {
		Console.Write("Enter temprature: ");
		int a = int.Parse(Console.ReadLine());
		Console.WriteLine((a * 1.8) + 32);
	}
}