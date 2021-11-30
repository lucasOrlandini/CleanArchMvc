using CleanArchMvc.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts(); //Retornando uma lista de categorie DTO
        Task<ProductDTO> GetById(int? id); //Retornar um objeto products DTO por ID
        //Task<ProductDTO> GetProductCategory(int? id);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(int? id);
    }
}
