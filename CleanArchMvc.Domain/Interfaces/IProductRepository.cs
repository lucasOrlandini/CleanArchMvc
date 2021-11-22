using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
   public interface IProductRepository //Utilizadas para acessar os repositorios
    {
        Task<IEnumerable<Product>> GetProductsAsync(); //Retornando uma lista de Produtos  //Task define que pe assincrona.
        Task<Product> GetByIdAsync(int? id); //Uso o Id e ela retorna um produto
        Task<Product> GetProductCategoryAsync(int? id); //retornando pelo id de uma categoria.
        Task<Product> CreateAsync(Product product); 
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}
