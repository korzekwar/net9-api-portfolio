using Api.Controllers;
using Core;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UnitTests;

public class ProductsControllerTests
{
    private readonly DbContextOptions<AppDbContext> _dbContextOptions;

    public ProductsControllerTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }

    [Fact]
    public async Task GetProduct_WithExistingId_ReturnsOkObjectResultWithProduct()
    {
        var productId = Guid.NewGuid();
        var expectedProduct = new Product { Id = productId, Name = "Produto de Teste", Price = 10.99m };

        await using var context = new AppDbContext(_dbContextOptions);
        context.Products.Add(expectedProduct);
        await context.SaveChangesAsync();

        var controller = new ProductsController(context);

        var result = await controller.GetProduct(productId);

        var actionResult = Assert.IsType<OkObjectResult>(result.Result);

        var actualProduct = Assert.IsType<Product>(actionResult.Value);

        Assert.Equal(expectedProduct.Id, actualProduct.Id);
    }

    [Fact]
    public async Task GetProduct_WithNonExistingId_ReturnsNotFoundResult()
    {
        await using var context = new AppDbContext(_dbContextOptions);
        var controller = new ProductsController(context);
        var nonExistingId = Guid.NewGuid();

        var result = await controller.GetProduct(nonExistingId);

        Assert.IsType<NotFoundResult>(result.Result);
    }
}