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

public Product? GetProductByName(string name)
{
    if (string.IsNullOrWhiteSpace(name))
    {
        return null;
    }

    return _productRepository.GetByName(name.Trim());
}

public string UpdateProduct(string currentName, UpdateProductDto updateProductDto)
{
    string normalizedCurrentName = currentName.Trim();

    if (string.IsNullOrWhiteSpace(normalizedCurrentName))
    {
        return "Product name cannot be empty.";
    }

    Product? existingProduct = _productRepository.GetByName(normalizedCurrentName);

    if (existingProduct is null)
    {
        return "Product was not found.";
    }

    string updatedName = updateProductDto.Name?.Trim() ?? existingProduct.Name;
    decimal updatedPrice = updateProductDto.Price ?? existingProduct.Price;
    int updatedQuantity = updateProductDto.Quantity ?? existingProduct.Quantity;

    if (string.IsNullOrWhiteSpace(updatedName))
    {
        return "Updated product name cannot be empty.";
    }

    if (updatedPrice <= 0)
    {
        return "Updated product price must be greater than zero.";
    }

    if (updatedQuantity < 0)
    {
        return "Updated product quantity cannot be negative.";
    }

    bool isNameChanged = !string.Equals(
        existingProduct.Name,
        updatedName,
        StringComparison.OrdinalIgnoreCase
    );

    if (isNameChanged && _productRepository.ExistsByName(updatedName))
    {
        return "Another product with the same name already exists.";
    }

    existingProduct.Name = updatedName;
    existingProduct.Price = updatedPrice;
    existingProduct.Quantity = updatedQuantity;
    existingProduct.UpdatedAt = DateTime.UtcNow;

    _productRepository.Update(existingProduct);

    return "Product updated successfully.";
}
}