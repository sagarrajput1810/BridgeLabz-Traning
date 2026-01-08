using System;

class HomeAutomation
{
	static void Main(string[] args)
	{
		bool[] arr = new bool[4];

		while (true)
		{
			Console.WriteLine("\nSelect Value:");
			Console.WriteLine("1. Light");
			Console.WriteLine("2. Fan");
			Console.WriteLine("3. AC");
			Console.WriteLine("4. Exit");

			int value = int.Parse(Console.ReadLine());

			if (value == 4)
				break;

			if (value < 1 || value > 3)
			{
				Console.WriteLine("Invalid Input");
				continue;
			}

			arr[value] = !arr[value]; // toggle

			switch (value)
			{
				case 1:
					Device light = new Appliance("Light");
					if (arr[value]) light.TurnOn();
					else light.TurnOff();
					break;

				case 2:
					Device fan = new Appliance("Fan");
					if (arr[value]) fan.TurnOn();
					else fan.TurnOff();
					break;

				case 3:
					Device ac = new Appliance("AC");
					if (arr[value]) ac.TurnOn();
					else ac.TurnOff();
					break;
			}
		}
	}
}

abstract class Device
{
	public string Name { get; set; }

	public Device(string name)
	{
		Name = name;
	}

	public abstract void TurnOn();
	public abstract void TurnOff();
}

class Appliance : Device
{
	public Appliance(string name) : base(name) { }

	public override void TurnOn()
	{
		Console.WriteLine($"{Name} is turned ON");
	}

	public override void TurnOff()
	{
		Console.WriteLine($"{Name} is turned OFF");
	}
}
