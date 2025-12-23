using System;

class Armstrong {
	static void Main(string[] args) { 
		int n = int.Parse(Console.ReadLine());
		int originalNumber = n;
		int sum = 0;
		int digits = n.ToString().Length;
		while(n > 0)
		{
			int digit = n % 10;
			sum += (int)Math.Pow(digit, digits);
			n /= 10;
		}
		if(sum == originalNumber)
		{
			Console.WriteLine("Armstrong");
		}
		else
		{
			Console.WriteLine("Not Armstrong");
		}
	}
}