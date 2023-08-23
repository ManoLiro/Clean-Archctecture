using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IMapper _mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDTO)
        {
            var ProductEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(ProductEntity);
        }

        public async Task DeleteById(int? id)
        {
            var ProductEntity = _productRepository.GetByIdAsync(id).Result;
            await _productRepository.RemoveAsync(ProductEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var ProductEntity = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(ProductEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var ProductEntity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(ProductEntity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var ProductEntity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(ProductEntity);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var ProductEntity = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(ProductEntity);
        }
    }
}
