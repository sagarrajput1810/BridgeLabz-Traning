using System;
class Calculator
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        char op = Console.ReadLine()[0];
        int b = int.Parse(Console.ReadLine());
        switch(op)
        {
            case '+':
                Console.WriteLine(a + b);
                break;
            case '-':
                Console.WriteLine(a - b);
                break;
            case '*':
                Console.WriteLine(a * b);
                break;
            case '/':
                if(b != 0)
                {
                    Console.WriteLine(a / b);
                }
                else
                {
                    Console.WriteLine("Division by zero is not allowed.");
                }
                break;
            default:
                Console.WriteLine("Invalid operator");
                break;
        }
    }
}