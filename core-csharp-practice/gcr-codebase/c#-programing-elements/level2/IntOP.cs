using System;

class IntOP{
	static void Main(){
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());
		int c = int.Parse(Console.ReadLine());
		Console.Write("The results of Int Operations are " +(a + b * c)+", " + (a*b + c) + ", and " + (c+a/b));
	}
}