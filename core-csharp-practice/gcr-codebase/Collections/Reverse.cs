using System;

class Reverse
{
    static void Main(string[] args)
    {

        List<int> arr = new List<int>();
        arr.Add(1);
        arr.Add(2);
        arr.Add(3);
        arr.Add(4);
        arr.Add(5);
        arr.Reverse();
        foreach(int i in arr)
        {
           Console.Write(i+" "); 
        }
        Console.WriteLine();
        LinkedList<int> list = new LinkedList<int>();
        list.AddLast(1);
        list.AddLast(2);
        list.AddLast(3);
        list.AddLast(4);
        list.AddLast(5);
        LinkedList<int> reverse = new LinkedList<int>(list.Reverse());
        foreach(int i in reverse)
        {
            Console.Write($"{i} ");
        }
    }
}