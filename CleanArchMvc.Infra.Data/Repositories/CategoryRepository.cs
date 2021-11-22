using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository //Estou herdando a interface
    {

        ApplicationDbContext _categoryContext; //representa meu contexto.
        public CategoryRepository(ApplicationDbContext  context) //injetando meu contexto
        {
            _categoryContext = context; //Usar todos os recursos que tem no context, posso acessar o banco de dados tb.    
        }

        public async Task<Category> Create(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> GetById(int? id) //Está retornando uma categoria pelo seu ID.
        {
            return await _categoryContext.Categories.FindAsync(id); //Está indo la em categorias depois buscando o id dessa categoria.
        }

        public async Task<IEnumerable<Category>> GetCategories() //Uma lista de categoria
        {
            return await _categoryContext.Categories.ToListAsync(); //Vou retornar uma lista de categoria.
        }

        public async Task<Category> Remove(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
