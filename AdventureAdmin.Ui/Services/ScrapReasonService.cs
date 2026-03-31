using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ScrapReasonModel = AdventureAdmin.Data.Models.ScrapReason;

namespace AdventureAdmin.Ui.Services;

public class ScrapReasonService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<ScrapReasonModel, short>
{
    public async Task<ScrapReasonModel?> Buscar(short id)
    {
        return await context.ScrapReasons.FindAsync(id);
    }

    public async Task<bool> Eliminar(short id)
    {
        var razon = await context.ScrapReasons.FindAsync(id);
        if (razon == null) return false;
        
        context.ScrapReasons.Remove(razon);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<ScrapReasonModel>> GetList(Expression<Func<ScrapReasonModel, bool>> criterio)
    {
        return await context.ScrapReasons
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(ScrapReasonModel entity)
    {
        await context.ScrapReasons.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
