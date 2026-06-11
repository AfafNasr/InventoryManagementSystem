using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services;

public interface IInventoryService
{
    string AddProduct(CreateProductDto productDto);

     List<Product> GetAllProducts();

     Product? GetProductByName(string name);

     string UpdateProduct(string currentName, UpdateProductDto updateProductDto);

     string DeleteProduct(string name);
}