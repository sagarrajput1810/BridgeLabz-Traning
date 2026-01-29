using System;

class Queue
{
    private class Node
    {
        public int Data;
        public Node next;
        public Node(int data)
        {
            Data = data;
        }
    }

    Node Head;

    public void Enqueue(int data)
    {
        Node currentNode = new Node(data);
        if(Head == null)
        {
            Head = currentNode;
        }
        else
        {
            Node temp = Head;
            while(temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = currentNode;
        }
    }

    public int Dequeue()
    {
        if(Head == null)
        {
            return -1;
        }
        Node temp = Head;
        Head = Head.next;
        return temp.Data;
    }

    Node Reverse(Node head)
    {
        if(head.next == null)
        {
            Head = head;
            return head;
        }
        Node node = Reverse(head.next);
        node.next = head;
        return head;
    }

    static void Main()
    {
        Queue queue = new Queue();
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Reverse(queue.Head);
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
        Console.WriteLine(queue.Dequeue());
    }
}