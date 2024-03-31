using Library.Models;
using Microsoft.EntityFrameworkCore;
using Sublimation.DAL;
using System.Linq.Expressions;

namespace Sublimation.Service
{
    public class VentaService
    {
        private readonly Contexto _contexto;
        public VentaService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int VentaId)
        {
            return await _contexto.Ventas.AnyAsync(v => v.VentaId == VentaId);
        }
        public async Task<Ventas?> GetVentas(int id)
        {
            return await _contexto.Ventas.Include(v => v.VentasDetalle).FirstOrDefaultAsync(v => v.VentaId == id);
        }
        public async Task<bool> Insertar(Ventas venta)
        {
            _contexto.Ventas.Add(venta);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Ventas venta)
        {
            var v = await _contexto.Ventas.FindAsync(venta.VentaId);
            _contexto.Entry(v!).State = EntityState.Detached;
            _contexto.Entry(venta).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Ventas venta)
        {
            if (!await Existe(venta.VentaId))
                return await Insertar(venta);
            else
                return await Modificar(venta);
        }
        public async Task<bool> Eliminar(Ventas venta)
        {
            var v = await _contexto.Ventas.FindAsync(venta.VentaId);
            _contexto.Entry(v!).State = EntityState.Detached;
            _contexto.Entry(venta).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Ventas?> Buscar(int VentaId)
        {
            return await _contexto.Ventas
                .Where(v => v.VentaId == VentaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Ventas>> Listar(Expression<Func<Ventas, bool>> Criterio)
        {
            return await _contexto.Ventas
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
