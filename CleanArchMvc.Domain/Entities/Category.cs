using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get;private set; }

        public Category(string name)

        {
            ValidateDomain(name);
        }
        public Category(int id,string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name);
        }

        public void update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set;}

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalide Name.Name is required");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalide Name, Name is too Short, minimum 3 characteres");

            Name = name;
        }
    }
}
