using System;

class Bacche{
	static void Main(){
		int a = int.Parse(Console.ReadLine());
		int c = int.Parse(Console.ReadLine());
		Console.Write(" The number of chocolates each child gets is "+(a/c)+" and the number of remaining chocolates is " + (a%c));
	}
}