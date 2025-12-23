using System;

class Ques2{
	static void Main(){
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());
		int c = int.Parse(Console.ReadLine());
		if( a > b &&  a > c){
			Console.Write("Is the first number the smallest? No");
		}
		else
			Console.Write("Is the first number the smallest? Yes");
	}
}