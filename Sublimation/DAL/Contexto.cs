using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Sublimation.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Servicios> Servicios { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
    }
}
