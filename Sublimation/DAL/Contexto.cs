using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Sublimation.DAL;

public class Contexto : DbContext
{
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Ventas> Ventas { get; set; }
    public DbSet<Servicios> Servicios { get; set; }
    public DbSet<Reclamos> Reclamos { get; set; }
    public DbSet<Compras> Compras { get; set; }
    public DbSet<Insumos> Insumos { get; set; }
    public DbSet<Suplidores> Suplidores { get; set; }

    public Contexto(DbContextOptions<Contexto> options) : base(options) { }
}
