using System;
using System.Reflection;

namespace ReflectionPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            string className = "ReflectionPractice.Student";

            try
            {
                Type type = Type.GetType(className);

                if (type == null)
                {
                    Console.WriteLine("Class not found.");
                    return;
                }

                Console.WriteLine($"\nInformation for class: {type.Name}");

                Console.WriteLine("\nConstructors:");
                foreach (var constructor in type.GetConstructors())
                {
                    Console.WriteLine(constructor);
                }

                Console.WriteLine("\nMethods:");
                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    Console.WriteLine(method);
                }

                Console.WriteLine("\nFields:");
                foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static))
                {
                    Console.WriteLine(field);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
