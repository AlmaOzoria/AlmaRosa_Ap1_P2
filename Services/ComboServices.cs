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
            .Include(c => c.CombosDetalles)
            .Where(criterio)
            .ToListAsync();
    }


    public async Task<Combos?> Buscar(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Combos
       .AsNoTracking()
       .Include(c => c.CombosDetalles)
       .ThenInclude(td => td.Articulos)
       .FirstOrDefaultAsync(c => c.ComboId == id);
    }

    public async Task<Combos> Crear(Combos combo)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        _contexto.Combos.Add(combo);
        await _contexto.SaveChangesAsync();
        return combo;
    }

    public async Task<List<CombosDetalle>> ObtenerDetallesComboId(int comboId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var detalles = await _contexto.CombosDetalle
            .Where(c => c.Combos.ComboId == comboId)
            .ToListAsync();

        return detalles;
    }

    public async Task<List<Articulos>> ObtenerArticulos()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Articulos.ToListAsync();
    }

    public async Task<List<CombosDetalle>> ObtenerDetalle()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.CombosDetalle.ToListAsync();

    }

    public async Task<List<Combos>> ObtenerCotizaciones()
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Combos.ToListAsync();
    }

  

}
