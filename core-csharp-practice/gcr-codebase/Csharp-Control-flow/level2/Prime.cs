using System;

class Prime {
    static void Main(string[] args) { 
        int n = int.Parse(Console.ReadLine());
        bool isPrime = true;
        for(int i = 2; i<=n/2; i++)
        {
            if(n % i == 0)
            {
                isPrime = false;
            }
        }
        if(isPrime && n > 1)
        {
            Console.WriteLine("Prime");
        }
        else
        {
            Console.WriteLine("Not Prime");
        }
    }
}