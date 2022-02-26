using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zappts.Domain.Entities;

namespace Zappts.Infra.Data.Mapping
{
    public class LivrosMap : IEntityTypeConfiguration<Livros>
    {
        public void Configure(EntityTypeBuilder<Livros> builder)
        {
            builder.ToTable("Livros");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Autor)
                .IsRequired()
                .HasColumnName("Autor")
                .HasColumnType("varchar(50)");

            builder.Property(prop => prop.Editora)
                .IsRequired()
                .HasColumnName("Editora")
                .HasColumnType("varchar(50)");

            builder.Property(prop => prop.Genero)
                .HasColumnName("Genero")
                .HasColumnType("varchar(50)");


            builder.Property(prop => prop.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.QtdPaginas)
                .IsRequired()
                .HasColumnName("QtdPaginas")
                .HasColumnType("int");

        }
    }
}
