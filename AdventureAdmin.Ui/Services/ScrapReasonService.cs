using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ScrapReasonService(
    AdventureWorksContext context
) : Aplicada1.Core.IService<Data.Models.ScrapReason, short>
{
    public async Task<Data.Models.ScrapReason?> Buscar(short id)
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

    public async Task<bool> Guardar(Data.Models.ScrapReason entity)
    {
        await context.ScrapReasons.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Data.Models.ScrapReason>> GetList(Expression<Func<Data.Models.ScrapReason, bool>> criterio)
    {
        return await context.ScrapReasons
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
