namespace SmartWarehouse.Models;

public abstract class WarehouseItem
{
    public string Id { get; set; }
    public string Name { get; set; }

    protected WarehouseItem(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString() => $"{Name} (Id: {Id})";
}

public class Electronics : WarehouseItem
{
    public Electronics(string id, string name) : base(id, name) { }
}

public class Groceries : WarehouseItem
{
    public string ExpiryDate { get; set; } = string.Empty;
    public Groceries(string id, string name, string expiry) : base(id, name) { ExpiryDate = expiry; }
    public override string ToString() => $"{Name} (Id: {Id}) - Expires: {ExpiryDate}";
}

public class Furniture : WarehouseItem
{
    public Furniture(string id, string name) : base(id, name) { }
}
