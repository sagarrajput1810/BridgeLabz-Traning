using System;

namespace BookShelf
{
    public class CustomLinkedList
    {
        public CustomLinkedListNode? Head { get; private set; }

        public void AddLast(string value)
        {
            var newNode = new CustomLinkedListNode(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                var current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void Remove(string value)
        {
            if (Head == null) return;

            if (Head.Value == value)
            {
                Head = Head.Next;
                return;
            }

            var current = Head;
            while (current.Next != null && current.Next.Value != value)
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }

        public System.Collections.Generic.IEnumerable<string> GetValues()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
    }
}
