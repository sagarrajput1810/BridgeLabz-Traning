using System;

class NthElement
{
    static void Main()
    {
        LinkedList<char> head = new LinkedList<char>();
        head.AddLast('A');
        head.AddLast('B');
        head.AddLast('C');
        head.AddLast('D');
        head.AddLast('E');
        int k = 2;
        LinkedList<char> reverse = new LinkedList<char>(head.Reverse());
        var node = reverse.First;
        for(int i =0; i < k-1; i++)
        {
            node = node.Next;
        }
        Console.WriteLine(node.Value);
    }
}