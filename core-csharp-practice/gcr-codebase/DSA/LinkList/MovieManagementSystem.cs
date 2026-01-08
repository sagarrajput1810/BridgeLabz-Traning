using System;
using System.Collections.Generic;

public class MovieManagementSystem
{
    private class Node
    {
        public string Title;
        public string Director;
        public int Year;
        public double Rating;
        public Node? Prev;
        public Node? Next;

        public Node(string title, string director, int year, double rating)
        {
            Title = title;
            Director = director;
            Year = year;
            Rating = rating;
        }
    }

    private Node? _head;
    private Node? _tail;

    public void AddAtBeginning(string title, string director, int year, double rating)
    {
        var node = new Node(title, director, year, rating) { Next = _head };
        if (_head != null)
        {
            _head.Prev = node;
        }
        _head = node;
        _tail ??= node;
    }

    public void AddAtEnd(string title, string director, int year, double rating)
    {
        var node = new Node(title, director, year, rating) { Prev = _tail };
        if (_tail != null)
        {
            _tail.Next = node;
        }
        _tail = node;
        _head ??= node;
    }

    public bool AddAtPosition(int position, string title, string director, int year, double rating)
    {
        if (position < 0)
        {
            return false;
        }
        if (position == 0)
        {
            AddAtBeginning(title, director, year, rating);
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

        var node = new Node(title, director, year, rating)
        {
            Next = current.Next,
            Prev = current
        };

        if (current.Next != null)
        {
            current.Next.Prev = node;
        }
        else
        {
            _tail = node;
        }

        current.Next = node;
        return true;
    }

    public bool RemoveByTitle(string title)
    {
        var current = _head;
        while (current != null && !string.Equals(current.Title, title, StringComparison.OrdinalIgnoreCase))
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

        return true;
    }

    public List<(string Title, string Director, int Year, double Rating)> SearchByDirector(string director)
    {
        var results = new List<(string, string, int, double)>();
        var current = _head;
        while (current != null)
        {
            if (string.Equals(current.Director, director, StringComparison.OrdinalIgnoreCase))
            {
                results.Add((current.Title, current.Director, current.Year, current.Rating));
            }
            current = current.Next;
        }
        return results;
    }

    public List<(string Title, string Director, int Year, double Rating)> SearchByRating(double rating)
    {
        var results = new List<(string, string, int, double)>();
        var current = _head;
        while (current != null)
        {
            if (Math.Abs(current.Rating - rating) < 0.0001)
            {
                results.Add((current.Title, current.Director, current.Year, current.Rating));
            }
            current = current.Next;
        }
        return results;
    }

    public bool UpdateRating(string title, double newRating)
    {
        var current = _head;
        while (current != null)
        {
            if (string.Equals(current.Title, title, StringComparison.OrdinalIgnoreCase))
            {
                current.Rating = newRating;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public List<(string Title, string Director, int Year, double Rating)> DisplayForward()
    {
        var list = new List<(string, string, int, double)>();
        var current = _head;
        while (current != null)
        {
            list.Add((current.Title, current.Director, current.Year, current.Rating));
            current = current.Next;
        }
        return list;
    }

    public List<(string Title, string Director, int Year, double Rating)> DisplayReverse()
    {
        var list = new List<(string, string, int, double)>();
        var current = _tail;
        while (current != null)
        {
            list.Add((current.Title, current.Director, current.Year, current.Rating));
            current = current.Prev;
        }
        return list;
    }
}
