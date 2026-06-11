using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Repositories;

public interface IProductRepository
{
    bool ExistsByName(string name);

    void Add(Product product);

    List<Product> GetAll();

    Product? GetByName(string name);

    void Update(Product product);
}