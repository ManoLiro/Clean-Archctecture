using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1,"Category Name"); 
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Category With Invalid ID")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id Value");
        }
        [Fact(DisplayName = "Create Category With Short Name")]
        public void CreateCategory_ShorNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalide Name, Name is too Short, minimum 3 characteres");
        }
        [Fact(DisplayName = "Create Category With Null State")]
        public void CreateCategory_NullNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalide Name.Name is required");
        }
        [Fact(DisplayName = "Create Category With empty State")]
        public void CreateCategory_EmptyNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalide Name.Name is required");
        }
    }
}