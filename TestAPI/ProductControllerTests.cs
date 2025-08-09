using AutoMapper;
using Core.Entiies.Product;
using Core.Interface;
using Core.Specifications;
using E_commerce_API.Controllers;
using E_commerce_API.Helpers;
using Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class ProductControllerTests
{
    private readonly Mock<IGenericRepository<Product>> _productRepoMock = new();
    private readonly Mock<IGenericRepository<ProductBrand>> _brandRepoMock = new();
    private readonly Mock<IGenericRepository<ProductType>> _typeRepoMock = new();
    private readonly Mock<IMapper> _mapperMock = new();

    private ProductController CreateController()
    {
        return new ProductController(
            _productRepoMock.Object,
            _brandRepoMock.Object,
            _typeRepoMock.Object,
            _mapperMock.Object
        );
    }

    [Fact]
    public async Task GetProductById_ReturnsMappedProductDTO()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test" };
        var productDto = new ProductDTO { Id = 1, Name = "Test" };

        _productRepoMock.Setup(r => r.GetEntityWithSpec(It.IsAny<ISpecification<Product>>()))
            .ReturnsAsync(product);
        
        _mapperMock.Setup(m => m.Map<Product, ProductDTO>(product))
            .Returns(productDto);

        var controller = CreateController();

        // Act
        var result = await controller.GetProductById(1);

        // Assert
        Assert.Equal(productDto, result.Value);
    }

    [Fact]
    public async Task GetProducts_ReturnsPaginationOfProductDTO()
    {
        // Arrange
        var products = new List<Product> { new Product { Id = 1, Name = "Test" } };
        var productDtos = new List<ProductDTO> { new ProductDTO { Id = 1, Name = "Test" } };
        var productParams = new ProductSpecParams { PageIndex = 1, PageSize = 6 };

        _productRepoMock.Setup(r => r.CountAsync(It.IsAny<ISpecification<Product>>()))
            .ReturnsAsync(1);
        _productRepoMock.Setup(r => r.GetAsync(It.IsAny<ISpecification<Product>>()))
            .ReturnsAsync(products);
        _mapperMock.Setup(m => m.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products))
            .Returns(productDtos);

        var controller = CreateController();

        // Act
        var result = await controller.GetProducts(productParams);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var pagination = Assert.IsType<Pagination<ProductDTO>>(okResult.Value);
        Assert.Single(pagination.Data);
        Assert.Equal(1, pagination.Count);
    }
}