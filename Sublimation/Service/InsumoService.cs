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
    public Dictionary<int, string> insumosImagenes = new Dictionary<int, string>()
    {
        { 7, "https://trofeoscadenas.com/5306-large_default/taza-blanca-personalizable.jpg" }, // Taza
        { 8, "https://i.pinimg.com/736x/01/29/66/012966f0b8950ee8e67fa87f315d8eff.jpg" }, // T-Shirt
        { 9, "https://serveiestacio.com/media/catalog/product/cache/992afda33e77af72344ff0e9e895cef0/l/o/lona-de-pancarta-de-pvc.jpg" }, // Lona
        { 10, "https://materialesgraficosarmando.com/wp-content/uploads/sites/183/2022/11/cartonite.jpg" }, //Carton
        { 11, "https://www.novotexcorp.com/wp-content/uploads/2021/08/Elvajet-swift.jpg" }, //Tinta
    };
    public string ObtenerImagenUrlPorInsumoId(int insumoId)
    {
        if (insumosImagenes.TryGetValue(insumoId, out string imagenUrl))
        {
            return imagenUrl;
        }
        else
        {
            return "https://cdn-icons-png.flaticon.com/512/43/43533.png";
        }
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
