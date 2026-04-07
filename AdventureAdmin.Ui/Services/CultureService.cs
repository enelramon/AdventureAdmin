using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using CultureModel = AdventureAdmin.Data.Models.Culture;

namespace AdventureAdmin.Ui.Services;

public class CultureService(
    AdventureWorksContext context
) : Aplicada1.Core.IService<CultureModel, string>
{
    public async Task<CultureModel?> Buscar(string id)
    {
        return await context.Cultures.FindAsync(id);
    }

    public async Task<bool> Eliminar(string id)
    {
        var cultura = await context.Cultures.FindAsync(id);
        if (cultura == null) return false;
        
        context.Cultures.Remove(cultura);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<CultureModel>> GetList(Expression<Func<CultureModel, bool>> criterio)
    {
        return await context.Cultures
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(CultureModel entity)
    {
        var existe = await context.Cultures.FindAsync(entity.CultureId);
        
        if (existe != null)
        {
            context.Entry(existe).CurrentValues.SetValues(entity);
        }
        else
        {
            await context.Cultures.AddAsync(entity);
        }
        
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
