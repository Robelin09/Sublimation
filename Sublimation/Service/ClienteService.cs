using Library.Models;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Sublimation.DAL;
using System.Linq.Expressions;


namespace Sublimation.Service
{
    public class ClienteService
    {
        private readonly Contexto _contexto;
        public ClienteService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int ClienteId)
        {
            return await _contexto.Clientes.AnyAsync(c => c.ClienteId == ClienteId);
        }
        public async Task<bool> Insertar(Clientes clientes)
        {
            _contexto.Clientes.Add(clientes);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Clientes clientes)
        {
            var c = await _contexto.Clientes.FindAsync(clientes.ClienteId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(clientes).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExisteCedula(string cedula)
        {
            return await _contexto.Clientes.AnyAsync(c => c.Cedula == cedula);          
        }
        public async Task<bool> Guardar(Clientes clientes)
        {
            if (!await Existe(clientes.ClienteId))
                return await Insertar(clientes);
            else
                return await Modificar(clientes);
        }
        public async Task<bool> Eliminar(Clientes clientes)
        {
            var c = await _contexto.Clientes.FindAsync(clientes.ClienteId);
            _contexto.Entry(c!).State = EntityState.Detached;
            _contexto.Entry(clientes).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Clientes?> Buscar(int ClienteId)
        {
            return await _contexto.Clientes
                .Where(c => c.ClienteId == ClienteId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> Criterio)
        {
            return await _contexto.Clientes
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
