using System;

class Ques1
{
    static bool CompareString(string s1, string s2)
    {
        if(s1.Length != s2.Length)
        {
            return false;
        }
        for(int i = 0; i < s1.Length; i++)
        {
            if(s1[i] != s2[i])
            {
                return false;
            }
        }
        return true;
    }
    static void Main()
    {
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();
        Console.WriteLine(CompareString(s1, s2));
    }

    
}