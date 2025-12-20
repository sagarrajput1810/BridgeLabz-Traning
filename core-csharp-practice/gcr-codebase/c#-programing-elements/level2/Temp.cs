using System;

class Temp{
	static void Main(){
		int t = int.Parse(Console.ReadLine());
		Console.Write("The "+t+" Fahrenheit is " +((t - 32) * 5.0/9)+" Celsius");
	}
}