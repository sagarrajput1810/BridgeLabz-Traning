using System;
class Ques4
{
    static void Main()
    {
        string num = Console.ReadLine();
        int[] arr = new int[num.Length];
        for(int i =0; i<num.Length; i++)
        {
            arr[i] = int.Parse(num[i].ToString());
        }
        Array.Sort(arr);
        Console.WriteLine("Largest "+arr[arr.Length - 1]);
        Console.WriteLine("Second largest "+arr[arr.Length - 2]);
    }
}