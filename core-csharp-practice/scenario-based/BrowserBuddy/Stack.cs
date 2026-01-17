// Stack.cs
using System;
using System.Collections.Generic;

public class Stack<T>
{
    private List<T> elements;

    public Stack()
    {
        elements = new List<T>();
    }

    public void Push(T item)
    {
        elements.Add(item);
        Console.WriteLine($"Pushed item onto stack: {item}");
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        T item = elements[elements.Count - 1];
        elements.RemoveAt(elements.Count - 1);
        Console.WriteLine($"Popped item from stack: {item}");
        return item;
    }

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        return elements[elements.Count - 1];
    }

    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    public int Count
    {
        get { return elements.Count; }
    }
}
