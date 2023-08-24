using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        IProductRepository _Productrepository;
        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _Productrepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _Productrepository.GetProductsAsync();
            if(products == null)
            {
                throw new ApplicationException("Error Products Not Found");
            }
            else
            {
                return products;
            }
        }
    }
}
