using System;

class TriangleArea
{
    static void Main()
    {
        Console.Write("Enter base: ");
        double baseOfTraingle = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter heightOfTriangle: ");
        double heightOfTriangle = Convert.ToDouble(Console.ReadLine());

        double area = 0.5 * baseOfTraingle * heightOfTriangle;
        Console.WriteLine("Area of Triangle is " + area);
    }
}
