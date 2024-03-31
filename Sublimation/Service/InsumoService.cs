using Library.Models;
using Microsoft.EntityFrameworkCore;
using Sublimation.DAL;
using System.Linq.Expressions;

namespace Sublimation.Service;

public class InsumoService
{
    private readonly Contexto _contexto;
    public InsumoService(Contexto contexto)
    {
        _contexto = contexto;
    }
    public async Task<bool> Existe(int InsumosId)
    {
        return await _contexto.Insumos.AnyAsync(i => i.InsumosId == InsumosId);
    }
    public async Task<bool> Insertar(Insumos insumo)
    {
        _contexto.Insumos.Add(insumo);
        int filasAfectadas = await _contexto.SaveChangesAsync();
        return filasAfectadas > 0;
    }
    public async Task<bool> Modificar(Insumos insumo)
    {
        var i = await _contexto.Insumos.FindAsync(insumo.InsumosId);
        _contexto.Entry(i!).State = EntityState.Detached;
        _contexto.Entry(insumo).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Insumos insumo)
    {
        if (!await Existe(insumo.InsumosId))
            return await Insertar(insumo);
        else
            return await Modificar(insumo);
    }
    public async Task<bool> Eliminar(Insumos insumo)
    {
        var i = await _contexto.Insumos.FindAsync(insumo.InsumosId);
        _contexto.Entry(i!).State = EntityState.Detached;
        _contexto.Entry(insumo).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<Insumos?> Buscar(int InsumosId)
    {
        return await _contexto.Insumos
            .Where(i => i.InsumosId == InsumosId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
    public async Task<List<Insumos>> Listar(Expression<Func<Insumos, bool>> Criterio)
    {
        return await _contexto.Insumos
                .Where(Criterio)
                .AsNoTracking()
                .ToListAsync();
    }
}
