using System;

interface IDiscountable
{
    double ApplyDiscount();
    string GetDiscountDetails();
}

abstract class FoodItem
{
    protected string itemName;
    protected double price;
    protected int quantity;

    protected FoodItem(string name, double price, int qty)
    {
        itemName = name;
        this.price = price;
        quantity = qty;
    }

    public abstract double CalculateTotalPrice();
}

class VegItem : FoodItem
{
    public VegItem(string name, double price, int qty)
        : base(name, price, qty) { }

    public override double CalculateTotalPrice()
    {
        return price * quantity;
    }
}

class OnlineFoodDeliverySystem
{
    static void Main()
    {
        FoodItem food = new VegItem("Paneer", 200, 2);
        Console.WriteLine("Total: " + food.CalculateTotalPrice());
    }
}
