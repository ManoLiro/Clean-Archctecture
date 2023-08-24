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
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        IProductRepository _Productrepository;
        public GetProductByIdQueryHandler(IProductRepository productrepository)
        {
            _Productrepository = productrepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _Productrepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new ApplicationException("Error Product Not Found");
            }
            else
            {
                return product;
            }
        }
    }
}
