﻿using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet <Category> Categories { get; set; } // Mapeamento ORM
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) //Configurar o modelo a referente API
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly); // aplicar as configuração que vamos fazer nas entidades.
        }
    }
}
