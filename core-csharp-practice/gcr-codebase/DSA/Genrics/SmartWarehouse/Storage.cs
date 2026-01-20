using System.Collections.Generic;
using SmartWarehouse.Models;

namespace SmartWarehouse;

public class Storage<T> where T : WarehouseItem
{
    private readonly List<T> items = new();

    public void Add(T item) => items.Add(item);

    public IEnumerable<T> GetAll() => items;

    public void DisplayAll()
    {
        Console.WriteLine("Stored items:");
        foreach (var i in items)
            Console.WriteLine("- " + i);
    }
}
