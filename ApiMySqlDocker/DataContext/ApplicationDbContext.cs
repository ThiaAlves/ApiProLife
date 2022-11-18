using ApiMySqlDocker.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiMySqlDocker.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Clinica> Clinicas {get; set; }
        public DbSet<Medico> Medicos {get; set; }
    }
}
