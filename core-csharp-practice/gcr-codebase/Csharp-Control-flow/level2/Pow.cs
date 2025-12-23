using System;
class Pow
{
    static void Main(string[] args)
    {
        int power = int.Parse(Console.ReadLine());
        int number = int.Parse(Console.ReadLine());
        int count = 0;
        for(int i = number; i <=power; i *= number)
        {
            count++;
        }
        Console.WriteLine(count);
    }
}