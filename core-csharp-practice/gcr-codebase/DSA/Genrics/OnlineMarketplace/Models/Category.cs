namespace OnlineMarketplace.Models;

public interface ICategory { }

public class BookCategory : ICategory { public string Genre { get; set; } = "General"; }
public class ClothingCategory : ICategory { public string SizeGuide { get; set; } = "S/M/L"; }
