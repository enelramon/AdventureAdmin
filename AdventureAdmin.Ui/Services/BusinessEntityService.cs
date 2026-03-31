using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class BusinessEntityService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<BusinessEntity, int>
{
    public async Task<BusinessEntity?> Buscar(int id)
    {
        return await context.BusinessEntities.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var entidad = await context.BusinessEntities.FindAsync(id);
        if (entidad == null) return false;
        
        context.BusinessEntities.Remove(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<BusinessEntity>> GetList(Expression<Func<BusinessEntity, bool>> criterio)
    {
        return await context.BusinessEntities
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.BusinessEntity entity)
    {
        await context.BusinessEntities.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
