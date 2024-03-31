using Library.Models;
using Microsoft.EntityFrameworkCore;
using Sublimation.DAL;
using System.Linq.Expressions;

namespace Sublimation.Service;

public class SuplidorService
{
    private readonly Contexto _contexto;
    public SuplidorService(Contexto contexto)
    {
        _contexto = contexto;
    }
    public async Task<bool> Existe(int SuplidorId)
    {
        return await _contexto.Suplidores.AnyAsync(s => s.SuplidorId == SuplidorId);
    }
    public async Task<bool> Insertar(Suplidores Suplidor)
    {
        _contexto.Suplidores.Add(Suplidor);
        int filasAfectadas = await _contexto.SaveChangesAsync();
        return filasAfectadas > 0;
    }
    public async Task<bool> Modificar(Suplidores Suplidor)
    {
        var c = await _contexto.Suplidores.FindAsync(Suplidor.SuplidorId);
        _contexto.Entry(c!).State = EntityState.Detached;
        _contexto.Entry(Suplidor).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Suplidores Suplidor)
    {
        if (!await Existe(Suplidor.SuplidorId))
            return await Insertar(Suplidor);
        else
            return await Modificar(Suplidor);
    }
    public async Task<bool> Eliminar(Suplidores Suplidor)
    {
        var s = await _contexto.Suplidores.FindAsync(Suplidor.SuplidorId);
        _contexto.Entry(s!).State = EntityState.Detached;
        _contexto.Entry(Suplidor).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<Suplidores?> Buscar(int SuplidorId)
    {
        return await _contexto.Suplidores
            .Where(s => s.SuplidorId == SuplidorId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
    public async Task<List<Suplidores>> Listar(Expression<Func<Suplidores, bool>> Criterio)
    {
        return await _contexto.Suplidores
                .Where(Criterio)
                .AsNoTracking()
                .ToListAsync();
    }
}
