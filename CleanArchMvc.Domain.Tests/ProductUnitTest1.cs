using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;


namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjetoValidState()
        {
            Action action = () => new Product (1, "Product Name", "Product Description", 9.99m, 99, "product image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "product image"); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "product image"); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("invalid name, too short, minimum 3 characteres");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "product image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo o ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg ggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image. too long, maximum 250 characteres");
        }

        [Fact]
        public void CreateProduct_WithNullImageNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, null); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, null); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithEmpytyImageName_DomainException()
        {
            Action action = () => new Product(1, "Product name", "Product Description", 9.99m, 99, ""); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InavalidPriceValue_ExceptionDomain()
        {
            Action action = () => new Product(1, "Product name", "Product Description", -9.99m, 99, ""); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Theory]//usando atributo theory pois to passando um parametro, que seria o "int value"
        [InlineData(-5)]//valor do parâmetro
        public void CreateProduct_InavalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Pro", "Product Description", 9.99m, value, "product image"); //Minha ação, aonde vou sar uma expressão lambda aonde vou criar uma instancia da entidade Category.
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
