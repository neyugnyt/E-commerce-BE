﻿using AutoMapper;
using AutoMapper.Execution;
using Core.Entiies.Product;
using Infrastructure.Data.DTOs;

namespace E_commerce_API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config) 
        {
            _config = config;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl)) 
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
            return null;
        }
    }
}
