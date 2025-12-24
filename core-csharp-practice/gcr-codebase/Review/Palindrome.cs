using System;
class Palindrome
{
    static void Main()
    {
        int min = int.Parse(Console.ReadLine());
        int max = int.Parse(Console.ReadLine());
        for(int i = min; i <= max; i++)
        {
            int rev = 0;
            int m = i;
            while (m > 0)
            {
                int rem = m %10;
                rev = rev*10 + rem;
                m /=10;
            }
            if(rev == i)
            {
                Console.WriteLine(i);
            }
        }
    }
}