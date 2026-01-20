using OnlineMarketplace.Models;
using System.Collections.Generic;

namespace OnlineMarketplace;

public static class Catalog
{
    public static void Print<TCategory>(IEnumerable<Product<TCategory>> products) where TCategory : ICategory
    {
        foreach (var p in products)
            Console.WriteLine($"{p.Title} - ${p.Price}");
    }

    public static void ApplyDiscount<TProduct>(TProduct product, double percentage) where TProduct : ProductBase
    {
        product.Price *= 1 - (percentage / 100.0);
    }
}
