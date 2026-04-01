using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class CountryRegionService (
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.CountryRegion, int>
{
    public Task<CountryRegion?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CountryRegion>> GetList(Expression<Func<CountryRegion, bool>> criterio)
    {
        return await context.CountryRegions
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(CountryRegion entidad)
    {
        throw new NotImplementedException();
    }
}
