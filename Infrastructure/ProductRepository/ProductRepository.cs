using Azure;
using Core.Entiies.Product;
using Core.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products
                                 .Include(p => p.ProductBrand)
                                 .Include(p => p.ProductType)
                                 .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                                        .Include(p => p.ProductBrand)
                                        .Include(p => p.ProductType)
                                        .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
