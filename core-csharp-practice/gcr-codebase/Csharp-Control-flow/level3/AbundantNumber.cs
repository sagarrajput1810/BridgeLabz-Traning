using System;

class AbundantNumber
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        for(int i = 1; i <= n/2; i++)
        {
            if(n % i == 0)
            {
                sum += i;
            }
        }
        if( sum > n)
        {
            Console.WriteLine("Abundant Number");
        }
        else
        {
            Console.WriteLine("Not an Abundant Number");
        }
    }
}