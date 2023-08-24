using CleanArchMvc.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Commands
{
    public class ProductDeleteCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public ProductDeleteCommand(int id)
        {
            Id = id;
        }
    }
}
