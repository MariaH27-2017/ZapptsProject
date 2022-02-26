using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zappts.Domain.Entities;
using Zappts.Infra.Data.Mapping;

namespace Zappts.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public ApplicationDbContext()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("server=localhost;user id=zappts;password=Back@2022;database=zapptsProject;");
                base.OnConfiguring(optionsBuilder);         
            }
        }


        public DbSet<Livros> Livros { get; set; }
        public DbSet<Changelog> Changelog { get; set; }

    }
}
