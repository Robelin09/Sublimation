using Library.Models;
using Microsoft.EntityFrameworkCore;
using Sublimation.DAL;
using System.Linq.Expressions;

namespace Sublimation.Service;

public class ReclamoService
{
    private readonly Contexto _contexto;
    public ReclamoService(Contexto contexto)
    {
        _contexto = contexto;
    }
    public async Task<bool> Existe(int ReclamoId)
    {
        return await _contexto.Reclamos.AnyAsync(r => r.ReclamoId == ReclamoId);
    }
    public async Task<bool> Insertar(Reclamos reclamo)
    {
        _contexto.Reclamos.Add(reclamo);
        int filasAfectadas = await _contexto.SaveChangesAsync();
        return filasAfectadas > 0;
    }
    public async Task<bool> Modificar(Reclamos reclamo)
    {
        var r = await _contexto.Reclamos.FindAsync(reclamo.ReclamoId);
        _contexto.Entry(r!).State = EntityState.Detached;
        _contexto.Entry(reclamo).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Reclamos reclamo)
    {
        if (!await Existe(reclamo.ReclamoId))
            return await Insertar(reclamo);
        else
            return await Modificar(reclamo);
    }
    public async Task<bool> Eliminar(Reclamos reclamo)
    {
        var r = await _contexto.Reclamos.FindAsync(reclamo.ReclamoId);
        _contexto.Entry(r!).State = EntityState.Detached;
        _contexto.Entry(reclamo).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<Reclamos?> Buscar(int ReclamoId)
    {
        return await _contexto.Reclamos
            .Where(s => s.ReclamoId == ReclamoId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
    public async Task<List<Reclamos>> Listar(Expression<Func<Reclamos, bool>> Criterio)
    {
        return await _contexto.Reclamos
                .Where(Criterio)
                .AsNoTracking()
                .ToListAsync();
    }
}
