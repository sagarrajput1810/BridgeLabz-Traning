using System;

namespace TrafficManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nSelect Value");
                Console.WriteLine("1. Add Car");
                Console.WriteLine("2. Remove Car");
                Console.WriteLine("3. Display Car");
                Console.WriteLine("4. Exit");
                
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    switch (value)
                    {
                        case 1:
                            Console.WriteLine("Enter Car Number: ");
                            if (int.TryParse(Console.ReadLine(), out int carNumber))
                            {
                                queue.AddCar(carNumber);
                                Console.WriteLine($"Car {carNumber} added.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid Car Number");
                            }
                            break;
                        case 2:
                            int removedCar = queue.RemoveCar();
                            if (removedCar != -1)
                            {
                                Console.WriteLine($"Car is remove {removedCar}");
                            }
                            break;
                        case 3:
                            queue.DisplayCar();
                            break;
                        case 4:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Enter a valid Value");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid Value");
                }
            }
        }
    }
}