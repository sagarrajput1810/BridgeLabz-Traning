using System;

class Ques6{
	static void Main(){
		int n = int.Parse(Console.ReadLine());
		if(n > 0)
			Console.Write("positive");
		else if(n < 0)
			Console.Write("negative");
		else
			Console.Write("zero");
	}
}