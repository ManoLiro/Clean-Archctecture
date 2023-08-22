using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }
        public Product(int id,string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidationDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image,int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }


        public void ValidationDomain(string name,string description,decimal price,int stock,string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
               "Invalid Name. Name is required");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid Name, Name is too Short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
               "Invalid description. description is required");
            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, description is too Short, minimum 5 characters");

            DomainExceptionValidation.When(price < 0,
             "Invalid Price Value");

            DomainExceptionValidation.When(stock < 0,
                "Invalid Stock Value");

            DomainExceptionValidation.When(image?.Length > 250,
               "Invalid image name, image name is too Long, Maximum 250 characters");


            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
