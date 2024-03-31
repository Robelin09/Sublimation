using Library.Models;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Sublimation.DAL;
using Sublimation.Extensor;
using System.Linq.Expressions;


namespace Sublimation.Service
{
    public class ClienteService
    {
        private readonly Contexto _contexto;
        private readonly NotificationService _notificationService;
        public ClienteService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public ClienteService(Contexto contexto, NotificationService notificationService)
        {
            _contexto = contexto;
            _notificationService = notificationService;
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
        public async Task<bool> Guardar(Clientes clientes)
        {
            if (await _contexto.Clientes.AnyAsync(m => m.Cedula == clientes.Cedula))
            {
                _notificationService.ShowNotification(
               titulo: "Error",
               mensaje: "Esta cédula ya ha sido registrada",
               NotificationSeverity.Error);
                return false;
            }
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
