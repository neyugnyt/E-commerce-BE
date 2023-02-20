﻿using Core.Entiies.Product;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var item = await _productRepository.GetProductAsync();
            return Ok(item);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> GetProductById(int id)
        {
            var item = await _productRepository.GetProductByIdAsync(id);
            return Ok(item);
        }
    }
}
