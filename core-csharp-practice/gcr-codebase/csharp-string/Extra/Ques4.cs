using System;
class Ques4
{
    static void Main()
    {
        string s = Console.ReadLine();
        Console.WriteLine(RemoveDuplicates(s));
    }

    static string RemoveDuplicates(string s)
    {
        string result = "";
        for(int i = 0; i< s.Length; i++)
        {
            if(!IsPresent(result, s[i]))
            {
                result += s[i];
            }
        }
        return result;
    }
    static bool IsPresent(string s, char c)
    {
        for(int i = 0; i <s.Length; i++)
        {
            if(s[i] == c)
            {
                return true;
            }
        }
        return false;
    }
}