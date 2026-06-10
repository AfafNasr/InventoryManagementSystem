using Microsoft.Data.Sqlite;

namespace InventoryManagementSystem.Database;

public static class DatabaseInitializer
{
    private const string ConnectionString = "Data Source=inventory.db";

    public static void Initialize()
    {
        using SqliteConnection connection = new(ConnectionString);
        connection.Open();

        string createProductsTableQuery =
        """
        CREATE TABLE IF NOT EXISTS Products (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL UNIQUE,
            Price REAL NOT NULL,
            Quantity INTEGER NOT NULL,
            CreatedAt TEXT NOT NULL,
            UpdatedAt TEXT
        );
        """;

        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = createProductsTableQuery;
        command.ExecuteNonQuery();
    }
}