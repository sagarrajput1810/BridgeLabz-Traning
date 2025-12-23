using System;

class Ques5{
	static void Main(){
		int age = int.Parse(Console.ReadLine());
		if(age >= 18)
			Console.Write("The person's age is "+age+" and can vote.");
		else
			Console.Write("The person's age is "+age+" and cannot vote.");
	}
}