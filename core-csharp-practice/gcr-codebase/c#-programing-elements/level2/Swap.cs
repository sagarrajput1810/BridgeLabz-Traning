using System;

class Swap{
	static void Main(){
		int num1 = int.Parse(Console.ReadLine());
		int num2 = int.Parse(Console.ReadLine());
		num1 = num1 ^ num2;
		num2 = num1 ^ num2;
		num1 = num1 ^ num2;
		Console.Write("The swapped numbers are "+num1+" and "+num2);
	}
}