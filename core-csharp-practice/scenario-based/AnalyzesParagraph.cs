using System;

class AnalyzesParagraph
{
    static void Main()
    {
        string s = Console.ReadLine();

        if (s.Length == 0)
        {
            Console.WriteLine("Empty String");
            return;
        }

        Console.WriteLine("1. Count Words");
        Console.WriteLine("2. Longest Word");
        Console.WriteLine("3. Change Word");

        int value = int.Parse(Console.ReadLine());

        switch (value)
        {
            case 1:
                Console.WriteLine(Count(s));
                break;

            case 2:
                Console.WriteLine(Longest(s));
                break;

            case 3:
                Console.WriteLine("Enter replaceable word");
                string replace = Console.ReadLine();

                Console.WriteLine("Enter changed word");
                string word = Console.ReadLine();

                Console.WriteLine(ChangeWord(s, replace, word));
                break;

            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }

    static int Count(string s)
    {
        string[] arr = s.Split(' ');
        return arr.Length;
    }

    static string Longest(string s)
    {
        string[] arr = s.Split(' ');
        int max = 0;
        string longest = "";

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i].Length > max)
            {
                max = arr[i].Length;
                longest = arr[i];
            }
        }
        return longest;
    }

    static string ChangeWord(string s, string sub, string word)
    {
        string[] sentence = s.Split(' ');
        string changed = "";

        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == sub)
                changed += word;
            else
                changed += sentence[i];

            if (i < sentence.Length - 1)
                changed += " ";
        }
        return changed;
    }
}
