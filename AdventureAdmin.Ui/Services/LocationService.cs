using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class LocationService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Location, int>
{
    public async Task<Data.Models.Location?> Buscar(int id)
    {
        return await context.Locations
            .FirstOrDefaultAsync(l => l.LocationId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var location = await context.Locations
            .FirstOrDefaultAsync(l => l.LocationId == id);
        
        if (location == null)
            return false;

        context.Locations.Remove(location);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<Data.Models.Location>> GetList(Expression<Func<Data.Models.Location, bool>> criterio)
    {
        return await context.Locations
          
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.Location entidad)
    {
        await context.Locations.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
    public async Task<bool> Modificar(Data.Models.Location entidad)
    {
        context.Entry(entidad).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }
}
