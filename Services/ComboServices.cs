using AlmaRosa_Ap1_P2.DAL;
using AlmaRosa_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static Azure.Core.HttpHeader;

namespace AlmaRosa_Ap1_P2.Services;

public class ComboServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Insertar(Combos combos)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        try
        {
            _contexto.Combos.Add(combos);
            return await _contexto.SaveChangesAsync() > 0;
        }
        catch (DbUpdateException ex)
        {

            Console.WriteLine($"Error al insertar: {ex.InnerException?.Message}");
            return false;
        }
    }


    public async Task<bool> Existe(int combosId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Combos.AnyAsync(c => c.ComboId == combosId);

    }

    public async Task<bool> Modificar(Combos combos)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        _contexto.Update(combos);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Combos combos)
    {
        if (combos.ComboId == 0)
        {
            return await Insertar(combos);
        }
        else
        {
            return await Modificar(combos);
        }
    }


    public async Task<bool> Eliminar(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var combo = await _contexto.Combos
            .Where(c => c.ComboId == id)
            .ExecuteDeleteAsync();
        return combo > 0;

    }

    public async Task<List<Combos>> Listar(Expression<Func<Combos, bool>> criterio)
    {
        using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Combos
            .AsNoTracking()
            //.Include(c => c.CombosDetalle)
            .Where(criterio)
            .ToListAsync();
    }


    public async Task<Combos?> Buscar(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Combos
       .AsNoTracking()
       //.Include(c => c.CombosDetalle)
       .FirstOrDefaultAsync(c => c.ComboId == id);
    }

    //public async Task<CombosDetalle?> ObtenerComboDetalle()
    //{}
        


}
