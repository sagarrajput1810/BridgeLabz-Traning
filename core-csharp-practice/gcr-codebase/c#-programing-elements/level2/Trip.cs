using System;

class Trip{
	static void Main(){
		int side1 = int.Parse(Console.ReadLine());
		int side2 = int.Parse(Console.ReadLine());
		int side3 = int.Parse(Console.ReadLine());
		double p = 5000.0;
		Console.Write(" The total number of rounds the athlete will run is "+p/(side1+side2+side3)+" to complete 5 km");
	}
}