using InventoryManagementSystem.DTOs;

namespace InventoryManagementSystem.Services;

public interface IInventoryService
{
    string AddProduct(CreateProductDto productDto);
}