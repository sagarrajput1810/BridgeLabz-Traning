using System;

namespace Annotations
{
    // Parent class
    public class Animal
    {
        // Virtual method to be overridden
        public virtual void MakeSound()
        {
            Console.WriteLine("Some generic animal sound");
        }
    }

    // Child class
    public class Dog : Animal
    {
        // Overriding the method
        public override void MakeSound()
        {
            Console.WriteLine("Bark");
        }
    }

    public class Exercise1
    {
        public static void Run()
        {
            Console.WriteLine("--- Exercise 1: Method Overriding ---");
            // Instantiate Dog and call MakeSound()
            Dog myDog = new Dog();
            myDog.MakeSound(); // Output: Bark
            Console.WriteLine();
        }
    }
}
