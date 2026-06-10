using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Helpers;

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

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}