using System;

namespace BookShelf
{
    public class CustomLinkedListNode
    {
        public string Value { get; set; }
        public CustomLinkedListNode? Next { get; set; }

        public CustomLinkedListNode(string value)
        {
            Value = value;
            Next = null;
        }
    }
}
