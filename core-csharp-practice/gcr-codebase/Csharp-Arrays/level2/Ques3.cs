using System;
class Ques3
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[10];
        while(n > 0)
        {
            int digit = n % 10;
            arr[digit]++;
            n = n / 10;
        }
        Array.Sort(arr);
        Console.WriteLine("Largest "+arr[9]);
        Console.WriteLine("Second largest "+arr[8]);
    }
}