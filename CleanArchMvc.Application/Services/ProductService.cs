using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Handlers;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        //IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductService(/*IProductRepository productRepository*/ IMediator mediator, IMapper mapper)
        {
            //_productRepository = productRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            //var ProductEntity = await _productRepository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(ProductEntity);

            var productsQUERY = new GetProductsQuery();

            if(productsQUERY == null)
            {
                throw new Exception("Entity Could not be loaded.");
            }
            var result = await _mediator.Send(productsQUERY);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }



        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);    
        }

        public async Task DeleteById(int? id)
        {
            var productRemoveIdQuery = new ProductDeleteCommand(id.Value);
            if (productRemoveIdQuery == null)
                throw new Exception("Error, Entity could not be loaded");
            await _mediator.Send(productRemoveIdQuery);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
                throw new Exception("Error, Entity could not be loaded");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);
            if (productByIdQuery == null)
                throw new Exception("Error, Entity could not be loaded");

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
