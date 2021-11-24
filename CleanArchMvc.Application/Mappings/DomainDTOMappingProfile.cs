using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainDTOMappingProfile : Profile  //Herdar classe profile
    {
        public DomainDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap(); //Informei a origem, que é minha entidade e também o destino que é meu DTO
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
