using System;
class Average{
	static void Main()
	{
		int a=int.Parse(Console.ReadLine());
		int b=int.Parse(Console.ReadLine());
		int c=int.Parse(Console.ReadLine());
		double avg=(a+b+c)/3.0;
		Console.Write(avg);
	}
}