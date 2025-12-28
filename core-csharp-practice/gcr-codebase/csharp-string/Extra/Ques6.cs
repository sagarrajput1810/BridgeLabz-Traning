using System;

class Ques6
{
    static void Main()
    {
        string s = Console.ReadLine();
        string sub = Console.ReadLine();
        Console.WriteLine(CountSubString(s, sub));
    }
    static int CountSubString(string s, string sub)
    {
        int count = 0;
        for(int i = 0; i <= s.Length - sub.Length; i++)
        {
            if(s.Substring(i, sub.Length) == sub)
            {
                count++;
            }
        }
        return count;
    }
}