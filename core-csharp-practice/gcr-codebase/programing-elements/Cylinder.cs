using System;
class Cylinder{
	static void Main(){
		Console.Write("Enter radius: ");
		int r = int.Parse(Console.ReadLine());
		Console.Write("Enter height: ");
		int h = int.Parse(Console.ReadLine());
		Console.WriteLine(3.14 * r* r * h);
	}
}