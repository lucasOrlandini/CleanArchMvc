using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="OIOIOIO")]
        public void CreateCategory_WithValidParameters_ResultObjetoValidState()
        {
            Action action = () => new Category (1, "Category Name"); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();

        }
        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name"); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id Value");
        }
        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca"); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name , too short, minimum 3 charecteres"); 
        }
        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, ""); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("invalid name.Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
