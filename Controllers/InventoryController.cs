using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Views;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Helpers;

namespace InventoryManagementSystem.Controllers;

public class InventoryController
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    public void Run()
    {
        while (true)
        {
            MenuView.DisplayMainMenu();

            string? choice = MenuView.ReadUserChoice();

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;

                 case "2":
                     ViewAllProducts();
                     break;

                case "3":
                      EditProduct();
                      break;

                case "4":
                DeleteProduct();
                break;

               case "5":
               ProductView.ShowMessage("Goodbye!");
               return;
            }
        }
    }

    private void AddProduct()
    {
        CreateProductDto productDto = ProductView.ReadCreateProduct();

        string result = _inventoryService.AddProduct(productDto);

        ProductView.ShowMessage(result);
    }

    private void ViewAllProducts()
{
    List<Product> products = _inventoryService.GetAllProducts();

    ProductView.DisplayProducts(products);
}

private void EditProduct()
{
    string productName = InputHelper.ReadRequiredString("Enter product name to edit: ");

    Product? product = _inventoryService.GetProductByName(productName);

    if (product is null)
    {
        ProductView.ShowMessage("Product was not found.");
        return;
    }

    ProductView.DisplayProduct(product);

    UpdateProductDto updateProductDto = ProductView.ReadUpdateProduct(product);

    string result = _inventoryService.UpdateProduct(productName, updateProductDto);

    ProductView.ShowMessage(result);
}

private void DeleteProduct()
{
    string productName = ProductView.ReadProductNameToDelete();

    Product? product = _inventoryService.GetProductByName(productName);

    if (product is null)
    {
        ProductView.ShowMessage("Product was not found.");
        return;
    }

    bool confirmed = ProductView.ConfirmDelete(product);

    if (!confirmed)
    {
        ProductView.ShowMessage("Delete operation cancelled.");
        return;
    }

    string result = _inventoryService.DeleteProduct(productName);

    ProductView.ShowMessage(result);
}
}