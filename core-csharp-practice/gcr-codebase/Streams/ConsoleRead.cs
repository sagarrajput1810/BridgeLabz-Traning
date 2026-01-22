using System;
using System.IO;

class ConsoleRead
{
    public static void Main()
    {
        try
        {
            using StreamWriter writer = new StreamWriter("user.txt");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Age: ");
            string age = Console.ReadLine()!;

            Console.Write("Favorite Language: ");
            string lang = Console.ReadLine()!;

            writer.WriteLine($"Name: {name}");
            writer.WriteLine($"Age: {age}");
            writer.WriteLine($"Language: {lang}");

            Console.WriteLine("Saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
