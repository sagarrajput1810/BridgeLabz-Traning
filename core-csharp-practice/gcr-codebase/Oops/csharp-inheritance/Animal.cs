using System;

// Superclass
class Animal
{
    public string Name;
    public int Age;

    // Constructor
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Virtual method
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

// Subclass Dog
class Dog : Animal
{
    public Dog(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine(Name + " barks");
    }
}

// Subclass Cat
class Cat : Animal
{
    public Cat(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine(Name + " meows");
    }
}

// Subclass Bird
class Bird : Animal
{
    public Bird(string name, int age) : base(name, age) { }

    public override void MakeSound()
    {
        Console.WriteLine(Name + " chirps");
    }
}

class Program
{
    static void Main()
    {
        Animal a1 = new Dog("Buddy", 3);
        Animal a2 = new Cat("Kitty", 2);
        Animal a3 = new Bird("Tweety", 1);

        a1.MakeSound();
        a2.MakeSound();
        a3.MakeSound();
    }
}
