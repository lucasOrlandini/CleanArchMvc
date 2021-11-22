using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.EntitieConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id); //chave primaria da minha tabela
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired(); //A propriedade name tem que ter no máximo 100 characters e tem que ser obrigatório.

            builder.HasData(
                new Category(1, "Material Escolar"),
                new Category(2,"Eletrônicos"),
                new Category(3, "Acessórios")
                );
        }
    }
}
