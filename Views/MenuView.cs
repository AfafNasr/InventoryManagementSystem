namespace InventoryManagementSystem.Views;

public static class MenuView
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== Inventory Management System =====");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. View All Products");
        Console.WriteLine("3. Edit Product");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("5. Search Product");
        Console.WriteLine("6. Exit");
        Console.Write("Choose an option: ");
    }

    public static string? ReadUserChoice()
    {
        return Console.ReadLine();
    }
}