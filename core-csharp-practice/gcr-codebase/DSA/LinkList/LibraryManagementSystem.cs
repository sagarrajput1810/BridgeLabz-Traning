using System;
using System.Collections.Generic;

public class LibraryManagementSystem
{
    private class Node
    {
        public string Title;
        public string Author;
        public string Genre;
        public string BookId;
        public bool IsAvailable;
        public Node? Prev;
        public Node? Next;

        public Node(string title, string author, string genre, string bookId, bool isAvailable)
        {
            Title = title;
            Author = author;
            Genre = genre;
            BookId = bookId;
            IsAvailable = isAvailable;
        }
    }

    private Node? _head;
    private Node? _tail;
    private int _count;

    public void AddAtBeginning(string title, string author, string genre, string bookId, bool isAvailable)
    {
        var node = new Node(title, author, genre, bookId, isAvailable) { Next = _head };
        if (_head != null)
        {
            _head.Prev = node;
        }
        _head = node;
        _tail ??= node;
        _count++;
    }

    public void AddAtEnd(string title, string author, string genre, string bookId, bool isAvailable)
    {
        var node = new Node(title, author, genre, bookId, isAvailable) { Prev = _tail };
        if (_tail != null)
        {
            _tail.Next = node;
        }
        _tail = node;
        _head ??= node;
        _count++;
    }

    public bool AddAtPosition(int position, string title, string author, string genre, string bookId, bool isAvailable)
    {
        if (position < 0 || position > _count)
        {
            return false;
        }
        if (position == 0)
        {
            AddAtBeginning(title, author, genre, bookId, isAvailable);
            return true;
        }
        if (position == _count)
        {
            AddAtEnd(title, author, genre, bookId, isAvailable);
            return true;
        }

        var current = _head;
        for (int i = 0; current != null && i < position - 1; i++)
        {
            current = current.Next;
        }
        if (current == null)
        {
            return false;
        }

        var node = new Node(title, author, genre, bookId, isAvailable)
        {
            Next = current.Next,
            Prev = current
        };
        current.Next!.Prev = node;
        current.Next = node;
        _count++;
        return true;
    }

    public bool RemoveByBookId(string bookId)
    {
        var current = _head;
        while (current != null && !string.Equals(current.BookId, bookId, StringComparison.OrdinalIgnoreCase))
        {
            current = current.Next;
        }
        if (current == null)
        {
            return false;
        }

        if (current.Prev != null)
        {
            current.Prev.Next = current.Next;
        }
        else
        {
            _head = current.Next;
        }

        if (current.Next != null)
        {
            current.Next.Prev = current.Prev;
        }
        else
        {
            _tail = current.Prev;
        }

        _count--;
        return true;
    }

    public List<(string Title, string Author, string Genre, string BookId, bool IsAvailable)> Search(string? title = null, string? author = null)
    {
        var result = new List<(string, string, string, string, bool)>();
        var current = _head;
        while (current != null)
        {
            bool titleMatches = title != null && current.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0;
            bool authorMatches = author != null && current.Author.IndexOf(author, StringComparison.OrdinalIgnoreCase) >= 0;
            if (titleMatches || authorMatches)
            {
                result.Add((current.Title, current.Author, current.Genre, current.BookId, current.IsAvailable));
            }
            current = current.Next;
        }
        return result;
    }

    public bool UpdateAvailability(string bookId, bool isAvailable)
    {
        var current = _head;
        while (current != null)
        {
            if (string.Equals(current.BookId, bookId, StringComparison.OrdinalIgnoreCase))
            {
                current.IsAvailable = isAvailable;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public List<(string Title, string Author, string Genre, string BookId, bool IsAvailable)> DisplayForward()
    {
        var result = new List<(string, string, string, string, bool)>();
        var current = _head;
        while (current != null)
        {
            result.Add((current.Title, current.Author, current.Genre, current.BookId, current.IsAvailable));
            current = current.Next;
        }
        return result;
    }

    public List<(string Title, string Author, string Genre, string BookId, bool IsAvailable)> DisplayReverse()
    {
        var result = new List<(string, string, string, string, bool)>();
        var current = _tail;
        while (current != null)
        {
            result.Add((current.Title, current.Author, current.Genre, current.BookId, current.IsAvailable));
            current = current.Prev;
        }
        return result;
    }

    public int CountBooks() => _count;
}
