using System;

class SI{
	static void Main(){
		Console.Write("Enter principle: ");
		int p = int.Parse(Console.ReadLine());
		Console.Write("Enter rate: ");
		int r = int.Parse(Console.ReadLine());
		Console.Write("Enter time: ");
		int t = int.Parse(Console.ReadLine());
		Console.WriteLine((p*r*t) / 100);
	}
}