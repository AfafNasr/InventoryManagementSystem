using InventoryManagementSystem.Models;
using Microsoft.Data.Sqlite;

namespace InventoryManagementSystem.Repositories;

public class SqliteProductRepository : IProductRepository
{
    private const string ConnectionString = "Data Source=inventory.db";

    private static Product MapToProduct(SqliteDataReader reader)
{
    return new Product
    {
        Id = reader.GetInt32(0),
        Name = reader.GetString(1),
        Price = reader.GetDecimal(2),
        Quantity = reader.GetInt32(3),
        CreatedAt = DateTime.Parse(reader.GetString(4)),
        UpdatedAt = reader.IsDBNull(5)
            ? null
            : DateTime.Parse(reader.GetString(5))
    };
}


    public bool ExistsByName(string name)
    {
        using SqliteConnection connection = new(ConnectionString);
        connection.Open();

        const string query =
        """
        SELECT COUNT(1)
        FROM Products
        WHERE LOWER(Name) = LOWER(@name);
        """;

        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = query;
        command.Parameters.AddWithValue("@name", name.Trim());

        long count = (long)command.ExecuteScalar()!;

        return count > 0;
    }

    public void Add(Product product)
    {
        using SqliteConnection connection = new(ConnectionString);
        connection.Open();

        const string query =
        """
        INSERT INTO Products (Name, Price, Quantity, CreatedAt, UpdatedAt)
        VALUES (@name, @price, @quantity, @createdAt, @updatedAt);
        """;

        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = query;

        command.Parameters.AddWithValue("@name", product.Name);
        command.Parameters.AddWithValue("@price", product.Price);
        command.Parameters.AddWithValue("@quantity", product.Quantity);
        command.Parameters.AddWithValue("@createdAt", product.CreatedAt.ToString("O"));
        command.Parameters.AddWithValue("@updatedAt", DBNull.Value);

        command.ExecuteNonQuery();
    }
    public List<Product> GetAll()
{
    List<Product> products = [];

    using SqliteConnection connection = new(ConnectionString);
    connection.Open();

    const string query =
    """
    SELECT Id, Name, Price, Quantity, CreatedAt, UpdatedAt
    FROM Products
    ORDER BY Name;
    """;

    using SqliteCommand command = connection.CreateCommand();
    command.CommandText = query;

    using SqliteDataReader reader = command.ExecuteReader();

    while (reader.Read())
    {
        products.Add(MapToProduct(reader));
    }

    return products;
}

public Product? GetByName(string name)
{
    using SqliteConnection connection = new(ConnectionString);
    connection.Open();

    const string query =
    """
    SELECT Id, Name, Price, Quantity, CreatedAt, UpdatedAt
    FROM Products
    WHERE LOWER(Name) = LOWER(@name)
    LIMIT 1;
    """;

    using SqliteCommand command = connection.CreateCommand();
    command.CommandText = query;
    command.Parameters.AddWithValue("@name", name.Trim());

    using SqliteDataReader reader = command.ExecuteReader();

    if (!reader.Read())
    {
        return null;
    }

    return MapToProduct(reader);
}

public void Update(Product product)
{
    using SqliteConnection connection = new(ConnectionString);
    connection.Open();

    const string query =
    """
    UPDATE Products
    SET Name = @name,
        Price = @price,
        Quantity = @quantity,
        UpdatedAt = @updatedAt
    WHERE Id = @id;
    """;

    using SqliteCommand command = connection.CreateCommand();
    command.CommandText = query;

    command.Parameters.AddWithValue("@id", product.Id);
    command.Parameters.AddWithValue("@name", product.Name);
    command.Parameters.AddWithValue("@price", product.Price);
    command.Parameters.AddWithValue("@quantity", product.Quantity);
    command.Parameters.AddWithValue("@updatedAt", DateTime.UtcNow.ToString("O"));

    command.ExecuteNonQuery();
}

}