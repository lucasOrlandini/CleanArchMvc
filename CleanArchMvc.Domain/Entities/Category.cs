using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public  sealed class Category : Entity //Garantido que essa classe não poderá ser herdada.
    {
        
        public string Name { get; private set; }

        public Category(string name) // permitir uma maneira de criar objetos 
        {
            ValidateDomain(name);


        }
        public Category(int  id, string name)
        {
            DomainExceptionValidation.When(id < 0,"Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name) // Receber o nome e fazer a atualização.
        {
            ValidateDomain(name);

        }


        public ICollection<Product> Products { get; private set; } // Pode ter um ou mais produtos
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "invalid name.Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name , too short, minimum 3 charecteres");

            Name = name;
        }

    }
}
