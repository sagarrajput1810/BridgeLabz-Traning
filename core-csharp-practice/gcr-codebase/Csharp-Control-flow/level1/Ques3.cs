using System;

class Ques3{
	static void Main(){
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());
		int c = int.Parse(Console.ReadLine());
		if(a > b && a > c){
			Console.Write("the first number is the largest");
		}else if(b > a && b > c){
			Console.Write("the second number is the largest");
		}else {
			Console.Write("the third number is the largest");
		}
	}
}