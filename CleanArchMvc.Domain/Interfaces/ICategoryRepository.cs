using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Interfaces
{
   public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories(); //Retornando uma lista de categoria  //Task define que pe assincrona.
        Task<Category> GetById(int? id); //Uso o Id e ela retorna uma categoria
        Task<Category> Create(Category category); 
        Task<Category> Update(Category category);
        Task<Category> Remove(Category category);


    }
}
