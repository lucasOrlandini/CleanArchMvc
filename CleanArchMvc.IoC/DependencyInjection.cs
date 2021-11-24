using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.IoC
{
   public static class DependencyInjection
    {
        //Método de extensão.
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                IConfiguration configuration)
        {
            services.AddDbContext <ApplicationDbContext>(options =>  //Registrei meu contexto DBcontext
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"  // Defini meu banco de dados e o nome da string de conexão 
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))); //Estou informando que minha migração vai ficar na pasta aonde está definido meu arquivo de contexto


            services.AddScoped<ICategoryRepository, CategoryRepository>(); //Estou registrando o serviço para categoria e repositório
            services.AddScoped<IProductRepository,  ProductRepository>(); //Estou registrando o serviço para Prodito e repositório
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainDTOMappingProfile));


            return services;


        }

    }
}
