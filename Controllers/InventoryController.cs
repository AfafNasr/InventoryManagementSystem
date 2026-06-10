using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Views;

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
                    ProductView.ShowMessage("Goodbye!");
                    return;

                default:
                    ProductView.ShowMessage("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void AddProduct()
    {
        CreateProductDto productDto = ProductView.ReadCreateProduct();

        string result = _inventoryService.AddProduct(productDto);

        ProductView.ShowMessage(result);
    }
}