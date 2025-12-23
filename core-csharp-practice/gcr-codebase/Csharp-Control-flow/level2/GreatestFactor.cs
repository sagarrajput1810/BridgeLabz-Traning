using System;
class GeatestaFactor
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for(int i = n/2; i >=1 ; i--)
        {
            if(n % i == 0)
            {
                Console.WriteLine(i);
                break;
            }
        }
    }
}