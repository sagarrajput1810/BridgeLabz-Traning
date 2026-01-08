using System;

interface ITaxable
{
    double CalculateTax();
    string GetTaxDetails();
}

abstract class Product
{
    private int productId;
    private string name;
    protected double price;

    protected Product(int id, string name, double price)
    {
        this.productId = id;
        this.name = name;
        this.price = price;
    }

    public abstract double CalculateDiscount();

    public double GetFinalPrice(double tax, double discount)
    {
        return price + tax - discount;
    }
}

class Electronics : Product, ITaxable
{
    public Electronics(int id, string name, double price)
        : base(id, name, price) { }

    public override double CalculateDiscount()
    {
        return price * 0.10;
    }

    public double CalculateTax()
    {
        return price * 0.18;
    }

    public string GetTaxDetails()
    {
        return "GST 18%";
    }
}

class ECommercePlatform
{
    static void Main()
    {
        Product p = new Electronics(1, "Laptop", 60000);
        ITaxable tax = (ITaxable)p;

        double finalPrice = p.GetFinalPrice(tax.CalculateTax(), p.CalculateDiscount());
        Console.WriteLine("Final Price: " + finalPrice);
    }
}
