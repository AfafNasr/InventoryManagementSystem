namespace InventoryManagementSystem.Helpers;

public static class InputHelper
{
    public static string ReadRequiredString(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }

            Console.WriteLine("Input cannot be empty. Please try again.");
        }
    }

    public static decimal ReadPositiveDecimal(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a valid positive number.");
        }
    }

    public static int ReadNonNegativeInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a valid non-negative number.");
        }
    }
}