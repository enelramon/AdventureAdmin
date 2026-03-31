using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class CountryRegionService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<CountryRegion, string>
{
    public async Task<CountryRegion?> Buscar(string id)
    {
        return await context.CountryRegions.FindAsync(id);
    }

    public async Task<bool> Eliminar(string id)
    {
        var region = await context.CountryRegions.FindAsync(id);
        if (region == null) return false;
        
        context.CountryRegions.Remove(region);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<CountryRegion>> GetList(Expression<Func<CountryRegion, bool>> criterio)
    {
        return await context.CountryRegions
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.CountryRegion entity)
    {
        await context.CountryRegions.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
