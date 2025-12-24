using System;
class Ques5
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        int ans = 0;
        while(num > 0)
        {
            int rem = num %10;
            ans = ans * 10 + rem;
            num /= 10;
        }
        Console.WriteLine("Reversed number is: " + ans);
    }
}