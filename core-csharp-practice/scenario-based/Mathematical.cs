/*
2. Scenario: You are tasked with creating a utility class for mathematical operations.
Implement the following functionalities using separate methods:
● A method to calculate the factorial of a number.
● A method to check if a number is prime.
● A method to find the greatest common divisor (GCD) of two numbers.
● A method to find the nth Fibonacci number.
● Test your methods with various inputs, including edge cases like zero, one, and
negative numbers.*/

using System;
class Mathematical
{
    static void Main()
    {
        Console.WriteLine("1. Factorial");
        Console.WriteLine("2. Check a number if it is prime or not");
        Console.WriteLine("3. find GCD");
        Console.WriteLine("4. Fibonacci value");
        int i = int.Parse(Console.ReadLine());

        switch (i)
        {
            case 1:{
                Console.WriteLine("Enter a Number");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(Factorial(n));}
                break;

            case 2:{
                Console.WriteLine("Enter a Number");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(Prime(n));}
                break;

            case 3:
                Console.WriteLine("Enter first number");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter second number");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("GCD is");
                Console.WriteLine(GreatestCommonD(a, b));
                break;
            case 4:{ 
                Console.WriteLine("Enter a Number");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(Fibonacci(n));}
                break;
        }

    }
    static int Factorial(int n)
    {
        int fact = 1;
        for (int i = 1; i <= n; i++)
        {
            fact = fact * i;
        }
        return fact;
    }
    static bool Prime(int n)
    {
        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                count++;
            }
        }
        if (count == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static int GreatestCommonD(int a, int b)
    {
        int[] arr1 = new int[a];
        int[] arr2 = new int[b];
        int counta = 0;
        int countb = 0;
        for (int i = 1; i <= a; i++)
        {
            if (a % i == 0)
            {
                arr1[counta++] = i;
            }
        }
        for (int i = 1; i <= b; i++)
        {
            if (b % i == 0)
            {
                arr2[countb++] = i;
            }
        }
        int gcd = 1;
        for (int i = 0; i < counta; i++)
        {
            for (int j = 0; j < countb; j++)
            {
                if (arr1[i] == arr2[j])
                {
                    gcd = arr1[i];
                }
            }
        }
        return gcd;
    }

    static int Fibonacci(int n)
    {
        if (n == 0)
        {
            return 0;
        }
        if (n == 1)
        {
            return 1;
        }
        int first = 0;
        int second = 1;
        int res = 0;
        for (int i = 2; i <= n; i++)
        {
            res = first + second;
            first = second;
            //0+1 1+1 2+3
            second = res;

        }
        return res;
    }

}