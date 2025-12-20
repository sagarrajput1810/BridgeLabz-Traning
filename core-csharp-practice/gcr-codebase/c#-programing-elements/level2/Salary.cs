using System;

class Salary{
	static void Main(){
		int salary = int.Parse(Console.ReadLine());
		int bonus = int.Parse(Console.ReadLine());
		Console.Write("The salary is INR "+salary+ " and bonus is INR " + bonus + ". Hence Total Income is INR " + (salary+bonus));
	}
}