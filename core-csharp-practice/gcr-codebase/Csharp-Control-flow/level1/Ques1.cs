using System;

class Ques1{
	static void Main(){
		int n = int.Parse(Console.ReadLine());
		if(n%5 == 0)
		Console.Write(" Is the number "+n+" divisible by 5? Yes");
		else
		Console.Write(" Is the number "+n+" divisible by 5? No");
	}
}