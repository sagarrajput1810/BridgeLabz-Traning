using System;
class Factors
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for(int i = 1; i <= n/2; i++)
        {
            if(n % i == 0)
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine(n);
    }
}