using System;
class Multiple
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for(int i = 1; i <= 100; i++)
        {
            if(i % n == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}