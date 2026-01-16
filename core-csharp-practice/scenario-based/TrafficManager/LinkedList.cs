using System;

namespace TrafficManager
{
    public class Queue
    {
        private class Node
        {
            public int Data;
            public Node? Next;

            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node? Head;
        private Node? Tail;

        public void AddCar(int data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                // Tail should never be null if Head is not null in this logic
                if (Tail != null)
                {
                    Tail.Next = newNode;
                    Tail = newNode;
                }
            }
        }

        public int RemoveCar()
        {
            if (Head == null)
            {
                Console.WriteLine("Queue is Empty");
                return -1; 
            }

            int data = Head.Data;
            Head = Head.Next;
            
            if (Head == null)
            {
                Tail = null;
            }
            return data;
        }

        public void DisplayCar()
        {
            if (Head == null)
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            Node? temp = Head;
            Console.WriteLine("Cars in Queue:");
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }
}
