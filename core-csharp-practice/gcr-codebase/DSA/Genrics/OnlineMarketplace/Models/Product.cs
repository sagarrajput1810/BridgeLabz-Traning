namespace OnlineMarketplace.Models;

public abstract class ProductBase
{
    public string Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }

    protected ProductBase(string id, string title, double price)
    {
        Id = id;
        Title = title;
        Price = price;
    }
}

public class Product<TCategory> : ProductBase where TCategory : ICategory
{
    public TCategory Category { get; set; }

    public Product(string id, string title, double price, TCategory category) : base(id, title, price)
    {
        Category = category;
    }
}
