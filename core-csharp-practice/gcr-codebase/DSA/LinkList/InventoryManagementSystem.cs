using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryManagementSystem
{
    private class Node
    {
        public string ItemName;
        public string ItemId;
        public int Quantity;
        public decimal Price;
        public Node? Next;

        public Node(string itemName, string itemId, int quantity, decimal price)
        {
            ItemName = itemName;
            ItemId = itemId;
            Quantity = quantity;
            Price = price;
        }
    }

    private Node? _head;

    public void AddAtBeginning(string itemName, string itemId, int quantity, decimal price)
    {
        var node = new Node(itemName, itemId, quantity, price) { Next = _head };
        _head = node;
    }

    public void AddAtEnd(string itemName, string itemId, int quantity, decimal price)
    {
        var node = new Node(itemName, itemId, quantity, price);
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

    public bool AddAtPosition(int position, string itemName, string itemId, int quantity, decimal price)
    {
        if (position < 0)
        {
            return false;
        }
        if (position == 0)
        {
            AddAtBeginning(itemName, itemId, quantity, price);
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

        var node = new Node(itemName, itemId, quantity, price) { Next = current.Next };
        current.Next = node;
        return true;
    }

    public bool RemoveByItemId(string itemId)
    {
        if (_head == null)
        {
            return false;
        }
        if (string.Equals(_head.ItemId, itemId, StringComparison.OrdinalIgnoreCase))
        {
            _head = _head.Next;
            return true;
        }

        var current = _head;
        while (current.Next != null && !string.Equals(current.Next.ItemId, itemId, StringComparison.OrdinalIgnoreCase))
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

    public bool UpdateQuantity(string itemId, int newQuantity)
    {
        var current = _head;
        while (current != null)
        {
            if (string.Equals(current.ItemId, itemId, StringComparison.OrdinalIgnoreCase))
            {
                current.Quantity = newQuantity;
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public List<(string ItemName, string ItemId, int Quantity, decimal Price)> Search(string? itemId = null, string? itemName = null)
    {
        var result = new List<(string, string, int, decimal)>();
        var current = _head;
        while (current != null)
        {
            bool idMatches = itemId != null && string.Equals(current.ItemId, itemId, StringComparison.OrdinalIgnoreCase);
            bool nameMatches = itemName != null && current.ItemName.IndexOf(itemName, StringComparison.OrdinalIgnoreCase) >= 0;
            if (idMatches || nameMatches)
            {
                result.Add((current.ItemName, current.ItemId, current.Quantity, current.Price));
            }
            current = current.Next;
        }
        return result;
    }

    public decimal CalculateTotalValue()
    {
        decimal total = 0;
        var current = _head;
        while (current != null)
        {
            total += current.Price * current.Quantity;
            current = current.Next;
        }
        return total;
    }

    public List<(string ItemName, string ItemId, int Quantity, decimal Price)> DisplayAll()
    {
        var result = new List<(string, string, int, decimal)>();
        var current = _head;
        while (current != null)
        {
            result.Add((current.ItemName, current.ItemId, current.Quantity, current.Price));
            current = current.Next;
        }
        return result;
    }

    public void SortBy(string key, bool ascending = true)
    {
        var items = DisplayAll();
        IOrderedEnumerable<(string ItemName, string ItemId, int Quantity, decimal Price)> ordered;
        if (string.Equals(key, "price", StringComparison.OrdinalIgnoreCase))
        {
            ordered = ascending
                ? items.OrderBy(i => i.Price).ThenBy(i => i.ItemName)
                : items.OrderByDescending(i => i.Price).ThenBy(i => i.ItemName);
        }
        else
        {
            ordered = ascending
                ? items.OrderBy(i => i.ItemName, StringComparer.OrdinalIgnoreCase)
                : items.OrderByDescending(i => i.ItemName, StringComparer.OrdinalIgnoreCase);
        }

        _head = null;
        foreach (var item in ordered)
        {
            AddAtEnd(item.ItemName, item.ItemId, item.Quantity, item.Price);
        }
    }
}
