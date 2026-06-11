using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Repositories;

namespace InventoryManagementSystem.Services;

public class InventoryService : IInventoryService
{
    private readonly IProductRepository _productRepository;

    public InventoryService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public string AddProduct(CreateProductDto productDto)
    {
        string normalizedName = productDto.Name.Trim();

        if (string.IsNullOrWhiteSpace(normalizedName))
        {
            return "Product name cannot be empty.";
        }

        if (productDto.Price <= 0)
        {
            return "Product price must be greater than zero.";
        }

        if (productDto.Quantity < 0)
        {
            return "Product quantity cannot be negative.";
        }

        if (_productRepository.ExistsByName(normalizedName))
        {
            return "A product with the same name already exists.";
        }

        Product product = new()
        {
            Name = normalizedName,
            Price = productDto.Price,
            Quantity = productDto.Quantity,
            CreatedAt = DateTime.UtcNow
        };

        _productRepository.Add(product);

        return "Product added successfully.";
    }

    public List<Product> GetAllProducts()
{
    return _productRepository.GetAll();
}
}