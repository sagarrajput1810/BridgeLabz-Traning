using SmartWarehouse.Models;
using SmartWarehouse;

class Program
{
    static void Main()
    {
        var storage = new Storage<WarehouseItem>();

        storage.Add(new Electronics("E001", "Laptop"));
        storage.Add(new Groceries("G001", "Milk", "2026-02-01"));
        storage.Add(new Furniture("F001", "Chair"));

        storage.DisplayAll();
    }
}
