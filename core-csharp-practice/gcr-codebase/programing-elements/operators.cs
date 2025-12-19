using System;
class Operators{
	static void Main(){
		int a = int.Parse(Console.ReadLine());
		int b = int.Parse(Console.ReadLine());
		// Arithmatic operator
		Console.WriteLine("Addition: "+(a+b));
		Console.WriteLine("Substraction: "+(a-b));
		Console.WriteLine("Multiplication: "+(a*b));
		Console.WriteLine("Division: "+(a/b));
		Console.WriteLine("Modular: "+(a%b));
		Console.WriteLine("Increment: "+ a++);
		Console.WriteLine("Decrement: "+ a--);
		// Relational Operator
		Console.WriteLine("Equals to: "+(a == b));
		Console.WriteLine("Not equal to: "+(a != b));
		Console.WriteLine("Greater then: "+(a > b));
		Console.WriteLine("Lesser then: "+(a < b));
		Console.WriteLine("Greater then or equal to: "+(a >= b));
		Console.WriteLine("Greater then or equal to: "+(a <= b));
		// logical operator
		// Console.WriteLine("Logical AND: "+(a && b));
		// Console.WriteLine("Logical NOT: "+(!a));
		// Type Operator
		object obj = "Hello";
		Console.WriteLine("is operator: "+ obj is string);
		// Console.WriteLine("typeof operator: "+ typeof(a));
		// Type Casting
		float c = (float) a;
		Console.WriteLine("int to float: "+ c);
		
	}
}