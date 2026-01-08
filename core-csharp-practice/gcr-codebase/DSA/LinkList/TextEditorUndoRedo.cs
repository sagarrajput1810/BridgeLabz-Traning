using System;
using System.Collections.Generic;

public class TextEditorHistory
{
    private class Node
    {
        public string Content;
        public Node? Prev;
        public Node? Next;

        public Node(string content)
        {
            Content = content;
        }
    }

    private readonly int _limit;
    private Node? _head;
    private Node? _tail;
    private Node? _current;
    private int _count;

    public TextEditorHistory(int limit = 10)
    {
        _limit = Math.Max(1, limit);
    }

    public void AddState(string content)
    {
        var node = new Node(content);

        if (_current != null && _current.Next != null)
        {
            // discard redo states after new change
            _current.Next.Prev = null;
            _current.Next = null;
            _tail = _current;
            _count = CountNodes();
        }

        if (_tail == null)
        {
            _head = _tail = node;
        }
        else
        {
            _tail.Next = node;
            node.Prev = _tail;
            _tail = node;
        }

        _current = _tail;
        _count++;
        TrimHistoryIfNeeded();
    }

    public string? Undo()
    {
        if (_current?.Prev == null)
        {
            return _current?.Content;
        }
        _current = _current.Prev;
        return _current.Content;
    }

    public string? Redo()
    {
        if (_current?.Next == null)
        {
            return _current?.Content;
        }
        _current = _current.Next;
        return _current.Content;
    }

    public string? CurrentState() => _current?.Content;

    public List<string> ListForward()
    {
        var result = new List<string>();
        var node = _head;
        while (node != null)
        {
            result.Add(node.Content);
            node = node.Next;
        }
        return result;
    }

    public List<string> ListReverse()
    {
        var result = new List<string>();
        var node = _tail;
        while (node != null)
        {
            result.Add(node.Content);
            node = node.Prev;
        }
        return result;
    }

    private int CountNodes()
    {
        int count = 0;
        var node = _head;
        while (node != null)
        {
            count++;
            node = node.Next;
        }
        return count;
    }

    private void TrimHistoryIfNeeded()
    {
        while (_count > _limit && _head != null)
        {
            _head = _head.Next;
            if (_head != null)
            {
                _head.Prev = null;
            }
            _count--;
        }
    }
}
