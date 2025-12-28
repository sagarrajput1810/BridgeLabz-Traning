using System;

class Ques9
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(MaxOccuringChar(s));

    } 
    static char MaxOccuringChar(string s)
    {
        int maxCount = 0;
        char Char = ' ';
        for(int i = 0; i < s.Length; i++)
        {
            int count = 0;
            for(int j = 0; j < s.Length; j++)
            {
                if(s[i] == s[j])
                {
                    count++;
                }
            }
            if(count > maxCount)
            {
                maxCount = count;
                Char = s[i];
            }
        }
        return Char;
    }
}