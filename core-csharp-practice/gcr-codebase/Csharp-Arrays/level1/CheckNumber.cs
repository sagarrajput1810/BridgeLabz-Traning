using System;

class CheckNumber
{
    static void Main()
    {
        int[] num = new int[5];
        for (int i = 0; i < 5; i++)
        {
            num[i] = int.Parse(Console.ReadLine());
        }
        for(int i=0; i<5; i++)
        {
            if(num[i] > 0)
            {
                Console.WriteLine("Positive");
            }
            if(num[i] < 0)
            {
                Console.WriteLine("Negative");
            }
            else
            {
                Console.WriteLine("Zero");
            }
        }
    }
}