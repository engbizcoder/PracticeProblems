var products = new List<Product>
{
    new(1, "Laptop", 1, 101, 1200.50),
    new(2, "Mouse", 1, 101, 25.75),
    new(3, "Keyboard", 1, 102, 45.00),
    new(4, "Monitor", 1, 102, 300.99),
    new(5, "Smartphone", 2, 103, 999.99), // Supplied by MobileMart (New York)
    new(6, "Tablet", 2, 103, 450.00),    // Supplied by MobileMart (New York)
    new(7, "Desk Lamp", 3, 104, 35.20),
    new(8, "Office Chair", 3, 104, 150.75),
    new(9, "Desk", 3, 104, 200.50),
    new(10, "Printer", 4, 105, 300.00)   // Supplied by PrintHub (San Francisco)
};

var suppliers = new List<Supplier>
{
    new(101, "TechWorld", "New York"),
    new(102, "GadgetPro", "San Francisco"),
    new(103, "MobileMart", "New York"), // Another supplier in New York
    new(104, "OfficeDepot", "Seattle"),
    new(105, "PrintHub", "San Francisco") // Another supplier in San Francisco
};

var categories = new List<Category>
{
    new(1, "Electronics"),
    new(2, "Mobile Devices"),
    new(3, "Office Supplies"),
    new(4, "Printers & Accessories")
};

// Products group by categories
#region Task1

/*var categoricalProducts =
    (from c in categories
    join p in products on c.CategoryId equals p.CategoryId
        into groupedProductCategory
    select new CategoryWithProducts(c.CategoryName, groupedProductCategory.OrderBy(s => s.ProductName))).ToList();
foreach (var categoricalProduct in categoricalProducts)
{
    Console.WriteLine($"Category: {categoricalProduct?.CategoryName}");
    foreach (var product in categoricalProduct?.GroupedProductCategory ?? Enumerable.Empty<Product>())
    {
        Console.WriteLine($"\t Product: {product.ProductName}, Price: {product.Price}");
    }
}*/

#endregion

// Supplier-city product summary
#region Task2

var cityProducts =
    from s in suppliers
    join p in products on s.SupplierId equals p.SupplierId
        into supplierProductGroup
    select new CityBasedProduct(s.City, supplierProductGroup?.Count() ?? 0);
foreach (var cityProduct in cityProducts ?? [])
{
    Console.WriteLine($"City: {cityProduct.City}, Total Products: {cityProduct.Count}");
}

#endregion

internal record Product(int ProductId, string ProductName, int CategoryId, int SupplierId, double Price);
internal record Category(int CategoryId, string CategoryName);
internal record Supplier(int SupplierId, string SupplierName, string City);

internal record CategoryWithProducts(string CategoryName, IEnumerable<Product> GroupedProductCategory);

internal record CityBasedProduct(string City, int Count);