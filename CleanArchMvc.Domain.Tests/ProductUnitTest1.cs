using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1,"Product Name","Product Description",9.99m,10,"Imagem"); 
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Invalid ID")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 10, "Imagem");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id Value");
        }
        [Fact(DisplayName = "Create Product With Short Name")]
        public void CreateCategory_ShorNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 10, "Imagem");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name, Name is too Short, minimum 3 characters");
        }
        [Fact(DisplayName = "Create Product With Name Null State")]
        public void CreateCategory_NullNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99m, 10, "Imagem");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name. Name is required");
        }
        [Fact(DisplayName = "Create Product With Name empty State")]
        public void CreateCategory_EmptyNameValue_DomainException()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99m, 10, "Imagem");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name. Name is required");
        }
        [Fact(DisplayName = "Create Product With Description Null State")]
        public void CreateCategory_NullDescriptionValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", null, 9.99m, 10, "Imagem");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description. description is required");
        }
        [Fact(DisplayName = "Create Product With Description empty State")]
        public void CreateCategory_EmptyDescriptionValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "", 9.99m, 10, "Imagem");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description. description is required");
        }
        [Fact(DisplayName = "Create Product With Short Description State")]
        public void CreateCategory_ShortDescriptionValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "De", 9.99m, 10, "Imagem");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, description is too Short, minimum 5 characters");
        }
        [Fact(DisplayName = "Create Product With Price under zero State")]
        public void CreateCategory_UnderZeroPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -1, 10, "Imagem");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Price Value");
        }
        [Fact(DisplayName = "Create Product With Stock under zero State")]
        public void CreateCategory_UnderZeroStockValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -1, "Imagem");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Stock Value");
        }
        [Fact(DisplayName = "Create Product With Image High 250 State")]
        public void CreateCategory_High250ImageValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 10, "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, image name is too Long, Maximum 250 characters");
        }
    }
}