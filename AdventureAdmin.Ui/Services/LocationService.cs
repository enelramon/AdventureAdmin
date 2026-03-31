using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using LocationModel = AdventureAdmin.Data.Models.Location;

namespace AdventureAdmin.Ui.Services;

public class LocationService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<LocationModel, short>
{
    public async Task<LocationModel?> Buscar(short id)
    {
        return await context.Locations.FindAsync(id);
    }

    public async Task<bool> Eliminar(short id)
    {
        var ubicacion = await context.Locations.FindAsync(id);
        if (ubicacion == null) return false;
        
        context.Locations.Remove(ubicacion);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<LocationModel>> GetList(Expression<Func<LocationModel, bool>> criterio)
    {
        return await context.Locations
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(LocationModel entity)
    {
        await context.Locations.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
