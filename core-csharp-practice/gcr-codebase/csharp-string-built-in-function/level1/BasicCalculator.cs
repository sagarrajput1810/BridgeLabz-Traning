using System;

class BasicCalculator
{
    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Choose operation (+ - * /): ");
        char op = Console.ReadLine()[0];

        double result = Calculate(a, b, op);
        Console.WriteLine("Result: " + result);
    }

    static double Calculate(double x, double y, char operation)
    {
        if (operation == '+')
            return Add(x, y);
        else if (operation == '-')
            return Subtract(x, y);
        else if (operation == '*')
            return Multiply(x, y);
        else if (operation == '/')
            return Divide(x, y);

        return 0;
    }

    static double Add(double a, double b) { return a + b; }
    static double Subtract(double a, double b) { return a - b; }
    static double Multiply(double a, double b) { return a * b; }
    static double Divide(double a, double b) { return a / b; }
}
