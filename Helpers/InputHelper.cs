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

    public static string? ReadOptionalString(string message)
{
    Console.Write(message);
    string? input = Console.ReadLine();

    return string.IsNullOrWhiteSpace(input)
        ? null
        : input.Trim();
}

public static decimal? ReadOptionalPositiveDecimal(string message)
{
    while (true)
    {
        Console.Write(message);
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        if (decimal.TryParse(input, out decimal value) && value > 0)
        {
            return value;
        }

        Console.WriteLine("Please enter a valid positive number, or press Enter to keep the current value.");
    }
}

public static int? ReadOptionalNonNegativeInt(string message)
{
    while (true)
    {
        Console.Write(message);
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        if (int.TryParse(input, out int value) && value >= 0)
        {
            return value;
        }

        Console.WriteLine("Please enter a valid non-negative number, or press Enter to keep the current value.");
    }
}
}