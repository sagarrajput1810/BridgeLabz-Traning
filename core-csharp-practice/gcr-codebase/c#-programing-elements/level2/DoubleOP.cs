using System;

class IntOP{
	static void Main(){
		double a = double.Parse(Console.ReadLine());
		double b = double.Parse(Console.ReadLine());
		double c = double.Parse(Console.ReadLine());
		Console.Write("The results of double Operations are " +(a + b * c)+", " + (a*b + c) + ", and " + (c+a/b));
	}
}