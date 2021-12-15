using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

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
            
            //incluir os serviços do IDENTITY
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<ICategoryRepository, CategoryRepository>(); //Estou registrando o serviço para categoria e repositório
            services.AddScoped<IProductRepository,  ProductRepository>(); //Estou registrando o serviço para Prodito e repositório
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainDTOMappingProfile));

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();



            //obter assendle
            var myhandle = AppDomain.CurrentDomain.Load("CleanArchMvc.Application"); //Meus Handles são definidos aqui
            services.AddMediatR(myhandle);


            return services;


        }

    }
}
