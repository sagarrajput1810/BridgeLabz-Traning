using System;
using System.Collections.Generic;

public class StudentRecordList
{
    private class Node
    {
        public int RollNumber;
        public string Name;
        public int Age;
        public string Grade;
        public Node? Next;

        public Node(int rollNumber, string name, int age, string grade)
        {
            RollNumber = rollNumber;
            Name = name;
            Age = age;
            Grade = grade;
        }
    }

    private Node? _head;

    public void AddAtBeginning(int rollNumber, string name, int age, string grade)
    {
        var node = new Node(rollNumber, name, age, grade) { Next = _head };
        _head = node;
    }

    public void AddAtEnd(int rollNumber, string name, int age, string grade)
    {
        var node = new Node(rollNumber, name, age, grade);
        if (_head == null)
        {
            _head = node;
            return;
        }

        var current = _head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = node;
    }

    public bool AddAtPosition(int position, int rollNumber, string name, int age, string grade)
    {
        if (position < 0)
        {
            return false;
        }

        if (position == 0)
        {
            AddAtBeginning(rollNumber, name, age, grade);
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

        var node = new Node(rollNumber, name, age, grade) { Next = current.Next };
        current.Next = node;
        return true;
    }

    public bool DeleteByRollNumber(int rollNumber)
    {
        if (_head == null)
        {
            return false;
        }

        if (_head.RollNumber == rollNumber)
        {
            _head = _head.Next;
            return true;
        }

        var current = _head;
        while (current.Next != null && current.Next.RollNumber != rollNumber)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            return false;
        }

        current.Next = current.Next.Next;
        return true;
    }

    public (int RollNumber, string Name, int Age, string Grade)? SearchByRollNumber(int rollNumber)
    {
        var current = _head;
        while (current != null)
        {
            if (current.RollNumber == rollNumber)
            {
                return (current.RollNumber, current.Name, current.Age, current.Grade);
            }
            current = current.Next;
        }

        return null;
    }

    public bool UpdateGrade(int rollNumber, string newGrade)
    {
        var current = _head;
        while (current != null)
        {
            if (current.RollNumber == rollNumber)
            {
                current.Grade = newGrade;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public List<(int RollNumber, string Name, int Age, string Grade)> DisplayAll()
    {
        var records = new List<(int, string, int, string)>();
        var current = _head;
        while (current != null)
        {
            records.Add((current.RollNumber, current.Name, current.Age, current.Grade));
            current = current.Next;
        }
        return records;
    }
}
