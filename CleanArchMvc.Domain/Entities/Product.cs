using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
   public sealed class Product : Entity //Não pode ser herdadas
    {
        public string Name{ get; private set; }
        public string Description { get; private set; }
        public decimal Price{ get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public Product(string name, string description, decimal price, int stock, string image)//construtor
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "invalid Id value"); // Precisa ter um Id
            Id = id;

            ValidateDomain(name, description, price, stock, image);
        }
        public void Update (string name, string description, decimal price, int stock, string image, int categoryId) //construtor
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        
        }


        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), // nome não pode ser nem null nem vazio
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3 , //Não pode ter apenas 3 caracteres
                "invalid name, too short, minimum 3 characteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), // nome não pode ser nem null nem vazio
               "Invalid description. Description is required");

            DomainExceptionValidation.When(description.Length <5,
                "Invalid description. too short, minimum 5 characteres");

            DomainExceptionValidation.When(price < 0, "Invalid price values");

            DomainExceptionValidation.When(stock < 0,"Invalid stock values");

            DomainExceptionValidation.When(image?.Length > 250,  //use ? que é null condicional para não deixar a imagem nula.
                "Invalid image. too long, maximum 250 characteres");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        
        public Category Category { get; private set; } // Relaciona categoria com produto.
        public int CategoryId { get; private set; }
    }
}
