using System;
using System.Collections.Generic;

public class TaskSchedulerCircular
{
    private class Node
    {
        public int TaskId;
        public string TaskName;
        public int Priority;
        public DateTime DueDate;
        public Node? Next;

        public Node(int taskId, string taskName, int priority, DateTime dueDate)
        {
            TaskId = taskId;
            TaskName = taskName;
            Priority = priority;
            DueDate = dueDate;
        }
    }

    private Node? _head;
    private Node? _tail;
    private Node? _current;

    public void AddAtBeginning(int taskId, string taskName, int priority, DateTime dueDate)
    {
        var node = new Node(taskId, taskName, priority, dueDate);
        if (_head == null)
        {
            _head = _tail = node;
            node.Next = node;
            _current = _head;
            return;
        }

        node.Next = _head;
        _tail!.Next = node;
        _head = node;
    }

    public void AddAtEnd(int taskId, string taskName, int priority, DateTime dueDate)
    {
        var node = new Node(taskId, taskName, priority, dueDate);
        if (_tail == null)
        {
            _head = _tail = node;
            node.Next = node;
            _current = _head;
            return;
        }

        node.Next = _head;
        _tail.Next = node;
        _tail = node;
    }

    public bool AddAtPosition(int position, int taskId, string taskName, int priority, DateTime dueDate)
    {
        if (position < 0 || _head == null && position > 0)
        {
            return false;
        }
        if (_head == null || position == 0)
        {
            AddAtBeginning(taskId, taskName, priority, dueDate);
            return true;
        }

        var current = _head;
        for (int i = 0; current != null && i < position - 1; i++)
        {
            current = current.Next;
            if (current == _head)
            {
                return false;
            }
        }

        var node = new Node(taskId, taskName, priority, dueDate) { Next = current!.Next };
        current.Next = node;
        if (current == _tail)
        {
            _tail = node;
        }
        return true;
    }

    public bool RemoveByTaskId(int taskId)
    {
        if (_head == null)
        {
            return false;
        }

        Node? current = _head;
        Node? previous = null;

        do
        {
            if (current!.TaskId == taskId)
            {
                if (previous == null)
                {
                    if (_head == _tail)
                    {
                        _head = _tail = _current = null;
                        return true;
                    }
                    _head = _head!.Next;
                    _tail!.Next = _head;
                }
                else
                {
                    previous.Next = current.Next;
                    if (current == _tail)
                    {
                        _tail = previous;
                    }
                }

                if (_current == current)
                {
                    _current = current.Next == current ? null : current.Next;
                }
                return true;
            }
            previous = current;
            current = current.Next;
        } while (current != _head);

        return false;
    }

    public (int TaskId, string TaskName, int Priority, DateTime DueDate)? ViewCurrentTask()
    {
        if (_current == null)
        {
            return null;
        }
        var node = _current;
        _current = _current.Next;
        return (node.TaskId, node.TaskName, node.Priority, node.DueDate);
    }

    public List<(int TaskId, string TaskName, int Priority, DateTime DueDate)> DisplayAllFromHead()
    {
        var result = new List<(int, string, int, DateTime)>();
        if (_head == null)
        {
            return result;
        }

        var current = _head;
        do
        {
            result.Add((current!.TaskId, current.TaskName, current.Priority, current.DueDate));
            current = current.Next;
        } while (current != _head);

        return result;
    }

    public List<(int TaskId, string TaskName, int Priority, DateTime DueDate)> SearchByPriority(int priority)
    {
        var result = new List<(int, string, int, DateTime)>();
        if (_head == null)
        {
            return result;
        }

        var current = _head;
        do
        {
            if (current!.Priority == priority)
            {
                result.Add((current.TaskId, current.TaskName, current.Priority, current.DueDate));
            }
            current = current.Next;
        } while (current != _head);

        return result;
    }
}
