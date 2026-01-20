using OnlineMarketplace.Models;

class Program
{
    static void Main()
    {
        var book = new Product<BookCategory>("B001", "C# in Depth", 40.0, new BookCategory { Genre = "Programming" });
        var tshirt = new Product<ClothingCategory>("C001", "T-Shirt", 20.0, new ClothingCategory { SizeGuide = "S/M/L" });

        var books = new[] { book };
        Catalog.Print(books);

        Catalog.ApplyDiscount(book, 10);
        Console.WriteLine($"After discount: ${book.Price}");
    }
}
