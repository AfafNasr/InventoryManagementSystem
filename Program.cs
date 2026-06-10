using InventoryManagementSystem.Controllers;
using InventoryManagementSystem.Database;
using InventoryManagementSystem.Repositories;
using InventoryManagementSystem.Services;

DatabaseInitializer.Initialize();

IProductRepository productRepository = new SqliteProductRepository();
IInventoryService inventoryService = new InventoryService(productRepository);

InventoryController inventoryController = new(inventoryService);

inventoryController.Run();