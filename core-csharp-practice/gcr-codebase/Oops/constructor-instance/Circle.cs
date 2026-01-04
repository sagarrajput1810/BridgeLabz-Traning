using System;

class Circle
{
    private double radius;

    // Default constructor
    public Circle() : this(0)
    {
    }

    // Parameterized constructor
    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double CalculateArea()
    {
        return 3.14 * radius * radius;
    }

    static void Main()
    {
        Console.Write("Enter radius: ");
        double r = double.Parse(Console.ReadLine());

        Circle c = new Circle(r);
        Console.WriteLine("Area: " + c.CalculateArea());
    }
}
