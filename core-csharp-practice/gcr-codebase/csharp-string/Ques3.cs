using System;
using System.Buffers;

class Ques3
{
    static void Main()
    {
        string s = Console.ReadLine();
        char[] charArray = StringToCharArray(s);
        Console.WriteLine(charArray);
    }

    static char[] StringToCharArray(string s)
    {
        char[]  arr = new char[s.Length];
        for(int i = 0; i < s.Length; i++)
        {
            arr[i] = s[i];
        }
        return arr;
    }
}