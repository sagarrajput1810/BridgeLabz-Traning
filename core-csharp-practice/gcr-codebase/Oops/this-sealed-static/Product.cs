using System;

class Product
{
    public static double discount;

    private string productName;
    private double price;
    private int quantity;
    public readonly int productId;

    public Product(string productName, double price, int quantity, int productId)
    {
        this.productName = productName;
        this.price = price;
        this.quantity = quantity;
        this.productId = productId;
    }

    public void Display()
    {
        Console.WriteLine("Product Name : " + productName);
        Console.WriteLine("Price        : " + price);
        Console.WriteLine("Quantity     : " + quantity);
        Console.WriteLine("Discount     : " + discount);
        Console.WriteLine("Product ID   : " + productId);
        Console.WriteLine("----------------------------");
    }

    static void Main(string[] args)
    {
        // Hard-coded static value
        Product.discount = 10.5; // percentage

        // Hard-coded object creation
        object p1 = new Product("Laptop", 65000.00, 2, 101);
        object p2 = new Product("Wireless Mouse", 1200.00, 5, 102);

        // Type checking and casting
        if (p1 is Product)
        {
            ((Product)p1).Display();
        }

        if (p2 is Product)
        {
            ((Product)p2).Display();
        }
    }
}
