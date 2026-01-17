// DoublyLinkedList.cs
using System;

public class DoublyLinkedList
{
    private Node head;
    private Node tail;
    private Node current; // Represents the current page in history

    public DoublyLinkedList()
    {
        head = null;
        tail = null;
        current = null;
    }

    public void Add(string url)
    {
        Node newNode = new Node(url);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
            current = newNode;
        }
        else
        {
            // If we add a new page while not at the tail (e.g., after going "back"),
            // we need to cut off the "forward" history.
            if (current != tail)
            {
                current.Next = newNode;
                newNode.Prev = current;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            current = newNode;
        }
        Console.WriteLine($"Navigated to: {url}");
    }

    public string Back()
    {
        if (current != null && current.Prev != null)
        {
            current = current.Prev;
            Console.WriteLine($"Going back to: {current.Data}");
            return current.Data;
        }
        Console.WriteLine("Cannot go back further.");
        return GetCurrentUrl(); // Stay on current page if cannot go back
    }

    public string Forward()
    {
        if (current != null && current.Next != null)
        {
            current = current.Next;
            Console.WriteLine($"Going forward to: {current.Data}");
            return current.Data;
        }
        Console.WriteLine("Cannot go forward further.");
        return GetCurrentUrl(); // Stay on current page if cannot go forward
    }

    public string GetCurrentUrl()
    {
        return current?.Data ?? "No history";
    }

    public bool CanGoBack => current != null && current.Prev != null;
    public bool CanGoForward => current != null && current.Next != null;
}
