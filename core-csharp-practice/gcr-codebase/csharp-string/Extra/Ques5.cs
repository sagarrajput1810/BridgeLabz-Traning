using System;

class Ques5
{
    static void Main()
    {
        string [] s = Console.ReadLine().Split(" ");
        int max = 0;
        string longest = "";        
        for(int i = 0; i  < s.Length; i++)
        {
            if(s[i].Length > max)
            {
                max = s[i].Length;
                longest = s[i];
            }
        }
        Console.WriteLine(longest);
    }
}