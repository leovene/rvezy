using Microsoft.AspNetCore.Mvc;
using RVezy.WebAPI.Controllers;
using RVezy.WebAPI.Services;

namespace RVezy.Tests;

public class CSVControllerTests
{
    private readonly CSVController _controller;

    public CSVControllerTests()
    {
        // Arrange
        _controller = new CSVController(new CSVParseService());
    }

    [Fact]
    public void GetAll_ReturnsOkResult()
    {
        // Act
        var result = _controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetById_WithValidId_ReturnsOkResult()
    {
        // Arrange
        var id = 1;

        // Act
        var result = _controller.GetById(id);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetById_WithInvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        var id = 1000;

        // Act
        var result = _controller.GetById(id);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void GetByPropertyType_ReturnsOkResult()
    {
        // Arrange
        var propertyType = "House";

        // Act
        var result = _controller.GetByPropertyType(propertyType);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
