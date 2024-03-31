using Library.Models;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Sublimation.DAL;
using System.Linq.Expressions;

namespace Sublimation.Service
{
    public class UsuarioService
    {
        private readonly Contexto _contexto;
        public UsuarioService(Contexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> Existe(int UsuarioId)
        {
            return await _contexto.Usuarios.AnyAsync(u => u.UsuarioId == UsuarioId);
        }
        public async Task<bool> Insertar(Usuarios usuario)
        {
            _contexto.Usuarios.Add(usuario);
            int filasAfectadas = await _contexto.SaveChangesAsync();
            return filasAfectadas > 0;
        }
        public async Task<bool> Modificar(Usuarios usuario)
        {
            var u = await _contexto.Usuarios.FindAsync(usuario.UsuarioId);
            _contexto.Entry(u!).State = EntityState.Detached;
            _contexto.Entry(usuario).State = EntityState.Modified;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<bool> ExisteCedula(string cedula)
        {
            return await _contexto.Usuarios.AnyAsync(c => c.Cedula == cedula);
        }
        public async Task<bool> Guardar(Usuarios usuario)
        {
            if (!await Existe(usuario.UsuarioId))
                return await Insertar(usuario);
            else
                return await Modificar(usuario);
        }
        public async Task<bool> Eliminar(Usuarios usuario)
        {
            var u = await _contexto.Usuarios.FindAsync(usuario.UsuarioId);
            _contexto.Entry(u!).State = EntityState.Detached;
            _contexto.Entry(usuario).State = EntityState.Deleted;
            return await _contexto.SaveChangesAsync() > 0;
        }
        public async Task<Usuarios?> Buscar(int UsuarioId)
        {
            return await _contexto.Usuarios
                .Where(u => u.UsuarioId == UsuarioId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
        public async Task<List<Usuarios>> Listar(Expression<Func<Usuarios, bool>> Criterio)
        {
            return await _contexto.Usuarios
                    .Where(Criterio)
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
