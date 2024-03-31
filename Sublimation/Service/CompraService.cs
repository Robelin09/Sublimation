using Library.Models;
using Microsoft.EntityFrameworkCore;
using Sublimation.DAL;
using System.Linq.Expressions;

namespace Sublimation.Service;

public class CompraService
{
    private readonly Contexto _contexto;
    public CompraService(Contexto contexto)
    {
        _contexto = contexto;
    }
    public async Task<bool> Existe(int CompraId)
    {
        return await _contexto.Compras.AnyAsync(c => c.ComprasId == CompraId);
    }
    public async Task<Compras?> GetCompras(int id)
    {
        return await _contexto.Compras.Include(c => c.ComprasDetalle).FirstOrDefaultAsync(c => c.ComprasId == id);
    }
    public async Task<bool> Insertar(Compras Compras)
    {
        _contexto.Compras.Add(Compras);
        int filasAfectadas = await _contexto.SaveChangesAsync();
        return filasAfectadas > 0;
    }
    public async Task<bool> Modificar(Compras Compras)
    {
        var c = await _contexto.Compras.FindAsync(Compras.ComprasId);
        _contexto.Entry(c!).State = EntityState.Detached;
        _contexto.Entry(Compras).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Guardar(Compras Compras)
    {
        if (!await Existe(Compras.ComprasId))
            return await Insertar(Compras);
        else
            return await Modificar(Compras);
    }
    public async Task<bool> Eliminar(Compras Compras)
    {
        var c = await _contexto.Compras.FindAsync(Compras.ComprasId);
        _contexto.Entry(c!).State = EntityState.Detached;
        _contexto.Entry(Compras).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<Compras?> Buscar(int CompraId)
    {
        return await _contexto.Compras
            .Where(c => c.ComprasId == CompraId)
            .AsNoTracking()
            .SingleOrDefaultAsync();
    }
    public async Task<List<Compras>> Listar(Expression<Func<Compras, bool>> Criterio)
    {
        return await _contexto.Compras
                .Where(Criterio)
                .AsNoTracking()
                .ToListAsync();
    }
}
