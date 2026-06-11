using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Helpers;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Views;

public static class ProductView
{
    public static CreateProductDto ReadCreateProduct()
    {
        Console.WriteLine();
        Console.WriteLine("----- Add Product -----");

        string name = InputHelper.ReadRequiredString("Product name: ");
        decimal price = InputHelper.ReadPositiveDecimal("Product price: ");
        int quantity = InputHelper.ReadNonNegativeInt("Product quantity: ");

        return new CreateProductDto
        {
            Name = name,
            Price = price,
            Quantity = quantity
        };
    }

    public static void DisplayProducts(List<Product> products)
{
    const int lowStockThreshold = 5;

    Console.WriteLine();
    Console.WriteLine("========== Products List ==========");

    if (products.Count == 0)
    {
        Console.WriteLine("No products found in the inventory.");
        return;
    }

    int totalProducts = products.Count;
    List<Product> outOfStockProducts = products
    .Where(product => product.Quantity == 0)
    .ToList();

List<Product> lowStockProducts = products
    .Where(product => product.Quantity > 0 &&
                      product.Quantity <= lowStockThreshold)
    .ToList();

    Console.WriteLine();
    Console.WriteLine("----- Inventory Summary -----");
   Console.WriteLine($"Total Products: {totalProducts}");

Console.WriteLine();

Console.WriteLine($"In Stock Products: {products.Count - lowStockProducts.Count - outOfStockProducts.Count}");

Console.WriteLine($"Low Stock Products: {lowStockProducts.Count}");

Console.WriteLine($"Out Of Stock Products: {outOfStockProducts.Count}");

    if (outOfStockProducts.Count > 0)
{
    Console.WriteLine();
    Console.WriteLine("OUT OF STOCK");

    foreach (Product product in outOfStockProducts)
    {
        Console.WriteLine($"- {product.Name}");
    }
}
if (lowStockProducts.Count > 0)
{
    Console.WriteLine();
    Console.WriteLine("LOW STOCK WARNING");

    foreach (Product product in lowStockProducts)
    {
        Console.WriteLine($"- {product.Name} (Qty: {product.Quantity})");
    }
}

    Console.WriteLine();
    Console.WriteLine(new string('-', 105));
    Console.WriteLine(
        $"{ "ID",-5} { "Name",-25} { "Price",-12} { "Quantity",-10} { "Created At",-22} { "Updated At",-22}"
    );
    Console.WriteLine(new string('-', 105));

    foreach (Product product in products)
    {
        string updatedAt = product.UpdatedAt.HasValue
            ? product.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm")
            : "N/A";

        Console.WriteLine(
            $"{product.Id,-5} {product.Name,-25} {product.Price,-12:C} {product.Quantity,-10} {product.CreatedAt:yyyy-MM-dd HH:mm}       {updatedAt,-22}"
        );
    }

    Console.WriteLine(new string('-', 105));
}
public static UpdateProductDto ReadUpdateProduct(Product product)
{
    Console.WriteLine();
    Console.WriteLine("----- Edit Product -----");
    Console.WriteLine("Press Enter without typing anything to keep the current value.");
    Console.WriteLine();

    Console.WriteLine($"Current name: {product.Name}");
    string? newName = InputHelper.ReadOptionalString("New name: ");

    Console.WriteLine($"Current price: {product.Price:C}");
    decimal? newPrice = InputHelper.ReadOptionalPositiveDecimal("New price: ");

    Console.WriteLine($"Current quantity: {product.Quantity}");
    int? newQuantity = InputHelper.ReadOptionalNonNegativeInt("New quantity: ");

    return new UpdateProductDto
    {
        Name = newName,
        Price = newPrice,
        Quantity = newQuantity
    };
}
public static void DisplayProduct(Product product)
{
    Console.WriteLine();
    Console.WriteLine("----- Product Details -----");
    Console.WriteLine($"ID: {product.Id}");
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price:C}");
    Console.WriteLine($"Quantity: {product.Quantity}");
    Console.WriteLine($"Created At: {product.CreatedAt:yyyy-MM-dd HH:mm}");

    string updatedAt = product.UpdatedAt.HasValue
        ? product.UpdatedAt.Value.ToString("yyyy-MM-dd HH:mm")
        : "N/A";

    Console.WriteLine($"Updated At: {updatedAt}");
}
public static string ReadProductNameToDelete()
{
    Console.WriteLine();
    Console.WriteLine("----- Delete Product -----");

    return InputHelper.ReadRequiredString("Enter product name to delete: ");
}
public static bool ConfirmDelete(Product product)
{
    Console.WriteLine();
    Console.WriteLine("You are about to delete this product:");
    DisplayProduct(product);

    return InputHelper.ReadConfirmation("Are you sure you want to delete this product? (y/n): ");
}

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}