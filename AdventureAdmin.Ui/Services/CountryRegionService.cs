using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class CountryRegionService (
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.CountryRegion, int>
{
    public async Task<CountryRegion?> Buscar(int id)
    {
        return await context.CountryRegions
            .FirstOrDefaultAsync(c => c.CountryRegionId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var countryRegion = await context.CountryRegions
            .FirstOrDefaultAsync(c => c.CountryRegionId == id);

        if (countryRegion == null)
            return false;

        context.CountryRegions.Remove(countryRegion);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<CountryRegion>> GetList(Expression<Func<CountryRegion, bool>> criterio)
    {
        return await context.CountryRegions
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(CountryRegion entidad)
    {
        await context.CountryRegions.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
