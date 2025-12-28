using System;
class Ques10
{
    static void Main()
    {
        string s = Console.ReadLine();
        char c = Console.ReadLine()[0];
        Console.WriteLine(RemoveChar(s, c));
    }
    static string RemoveChar(string s, char c)
    {
        string result = "";
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] != c)
            {
                result += s[i];
            }
        }
        return result;
    }
}