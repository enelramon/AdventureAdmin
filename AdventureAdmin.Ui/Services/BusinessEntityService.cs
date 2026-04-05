using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace AdventureAdmin.Ui.Services;

internal class BusinessEntityService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.BusinessEntity, int>
{
    public async Task<BusinessEntity?> Buscar(int id)
    {
        return await context.BusinessEntities
            .FirstOrDefaultAsync(b => b.BusinessEntityId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var businessEntity = await context.BusinessEntities
            .FirstOrDefaultAsync(b => b.BusinessEntityId == id);

        if (businessEntity is null)
            return false;

        context.BusinessEntities.Remove(businessEntity);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<BusinessEntity>> GetList(Expression<Func<BusinessEntity, bool>> criterio)
    {
        return await context.BusinessEntities
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(BusinessEntity entidad)
    {
        await context.BusinessEntities.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
