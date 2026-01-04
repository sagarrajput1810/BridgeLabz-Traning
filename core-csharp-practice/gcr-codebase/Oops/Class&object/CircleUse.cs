using System;

class Circle
{
    double radius;

    public Circle(double rad)
    {
        radius = rad;
    }

    public double Area()
    {
        return Math.PI * radius * radius;
    }

    public double Parameter()
    {
        return 2 * Math.PI * radius;
    }
}
class CircleUse
{
    static void Main()
    {
        Circle circle = new Circle(10);
        Console.WriteLine("Circle Area is "+circle.Area());
        Console.WriteLine("Circle Parameter is "+circle.Parameter());
    }
}