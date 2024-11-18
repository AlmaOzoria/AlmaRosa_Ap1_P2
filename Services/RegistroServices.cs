using AlmaRosa_Ap1_P2.DAL;
using AlmaRosa_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AlmaRosa_Ap1_P2.Services;

public class RegistroServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Insertar(Registros registros)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        try
        {
            _contexto.Registros.Add(registros);
            return await _contexto.SaveChangesAsync() > 0;
        }
        catch (DbUpdateException ex)
        {

            Console.WriteLine($"Error al insertar: {ex.InnerException?.Message}");
            return false;
        }
    }


    public async Task<bool> Existe(int registroId)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        return await _contexto.Registros.AnyAsync(c => c.RegistroId == registroId);

    }

    public async Task<bool> Modificar(Registros registros)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        _contexto.Update(registros);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Registros registros)
    {
        if (registros.RegistroId == 0)
        {
            return await Insertar(registros);
        }
        else
        {
            return await Modificar(registros);
        }
    }


    public async Task<bool> Eliminar(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();
        var cotizaciones = await _contexto.Registros
            .Where(c => c.RegistroId == id)
            .ExecuteDeleteAsync();
        return cotizaciones > 0;

    }

    public async Task<List<Registros>> Listar(Expression<Func<Registros, bool>> criterio)
    {
        using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Registros
            .AsNoTracking()
            //.Include(t => t.CotizacionesDetalle)
            .Where(criterio)
            .ToListAsync();
    }


    public async Task<Registros?> Buscar(int id)
    {
        await using var _contexto = await DbFactory.CreateDbContextAsync();

        return await _contexto.Registros
       .AsNoTracking()
       //.Include(c => c.CotizacionesDetalle)
       .FirstOrDefaultAsync(c => c.RegistroId == id);
    }


}
