using System;
class Ques8
{
    static void Main()
    {
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        Console.WriteLine(CompareStrings(s,t));

    }
    static string CompareStrings(string s1, string s2)
    {
        int l = Math.Min(s1.Length, s2.Length);
        for(int i = 0; i < l; i++)
        {
            if(s1[i] - s2[i] < 0)
            {
                return s2;
            }else if(s1[i] - s2[i] > 0)
            {
                return s1;
            }
        }
        return "Equal";
    }
}