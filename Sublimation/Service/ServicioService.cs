using Library.Models;
using Microsoft.EntityFrameworkCore;
using Sublimation.DAL;
using System.Linq.Expressions;

namespace Sublimation.Service
{
    public class ServicioService
    {
        private readonly Contexto _contexto;
        public ServicioService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int ServicioId)
        {
            return await _contexto.Servicios.AnyAsync(s => s.ServicioId == ServicioId);
        }
        public async Task<Servicios?> GetServicios(int id)
        {
            return await _contexto.Servicios.Include(s => s.ServiciosDetalle).FirstOrDefaultAsync(s => s.ServicioId == id);
        }
        public async Task<bool> Insertar(Servicios servicio)
        {
            _contexto.Servicios.Add(servicio);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Servicios servicio)
        {
            var s = await _contexto.Servicios.FindAsync(servicio.ServicioId);
            _contexto.Entry(s!).State = EntityState.Detached;
            _contexto.Entry(servicio).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Servicios servicio)
        {
            if (!await Existe(servicio.ServicioId))
                return await Insertar(servicio);
            else
                return await Modificar(servicio);
        }
        public async Task<bool> Eliminar(Servicios servicio)
        {
            var s = await _contexto.Servicios.FindAsync(servicio.ServicioId);
            _contexto.Entry(s!).State = EntityState.Detached;
            _contexto.Entry(servicio).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Servicios?> Buscar(int ServicioId)
        {
            return await _contexto.Servicios
                .Where(s => s.ServicioId == ServicioId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Servicios>> Listar(Expression<Func<Servicios, bool>> Criterio)
        {
            return await _contexto.Servicios
                    .Include(s => s.ServiciosDetalle)
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
