using System;

class Person
{
    private string name;
    private int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Copy constructor
    public Person(Person p)
    {
        this.name = p.name;
        this.age = p.age;
    }

    public void Display()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
    }

    static void Main()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();

        Console.Write("Enter age: ");
        int age = int.Parse(Console.ReadLine());

        Person p1 = new Person(name, age);
        Person p2 = new Person(p1);

        p2.Display();
    }
}

