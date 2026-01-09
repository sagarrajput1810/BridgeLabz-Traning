using System;

class ATM{
	static void Main(string[] args) 
	{
		int [] notes = new int[] { 1, 2, 5, 10, 20, 50, 100, 200, 500};

		// Scenario A: Withdraw Amount
		Console.WriteLine("Enter Amount to Withdraw: ");
		int amount = int.Parse(Console.ReadLine());
		int temp = amount;
		int count = 0;
		for (int i = notes.Length - 1; i >= 0; i--)
		{
			if (amount < 1) { 
				break;
			}
            Console.WriteLine($"{notes[i]} X {amount / notes[i]}");
            count += amount / notes[i];
			amount = amount % notes[i];
		}
		Console.WriteLine("Total Notes Dispensed: " + count);

		// Scenario B: 
		amount = temp;
		count = 0;
		for (int i = notes.Length - 2; i >= 0; i--)
		{
			if (amount < 1)
			{
				break;
			}
			count += amount / notes[i];
			amount = amount % notes[i];   
		}
		Console.WriteLine("Total Notes Dispensed without 500: " + count);

	}
}