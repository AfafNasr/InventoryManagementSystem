namespace InventoryManagementSystem.Views;

public static class MenuView
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("===== Inventory Management System =====");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. View All Products");
        Console.WriteLine("3. Exit");
        Console.Write("Choose an option: ");
    }

    public static string? ReadUserChoice()
    {
        return Console.ReadLine();
    }
}