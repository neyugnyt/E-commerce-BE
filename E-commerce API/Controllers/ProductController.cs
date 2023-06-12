using AutoMapper;
using Core.Entiies.Product;
using Core.Interface;
using Core.Specifications;
using E_commerce_API.Helpers;
using Infrastructure.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;

        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;

        public ProductController(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [Cached(600)]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDTO>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            var countSpec = new ProductWithFiltersForCountSpectification(productParams);

            var totalItems = await _productRepository.CountAsync(countSpec);

            var products = await _productRepository.GetAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);
            return Ok(new Pagination<ProductDTO>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [Cached(600)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productRepository.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductDTO>(product);
        }


        [Cached(600)]
        [HttpGet("brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.GetAllAsync());
        }


        [Cached(600)]
        [HttpGet("type")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.GetAllAsync());
        }
    }
}
