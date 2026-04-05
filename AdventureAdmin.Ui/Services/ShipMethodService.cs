using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class ShipMethodService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.ShipMethod, int>
{
    public async Task<ShipMethod?> Buscar(int id)
    {
        return await context.ShipMethods
            .FirstOrDefaultAsync(sm => sm.ShipMethodId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var shipMethod = await context.ShipMethods
            .FirstOrDefaultAsync(sm => sm.ShipMethodId == id);

        if (shipMethod == null)
            return false;

        context.ShipMethods.Remove(shipMethod);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<ShipMethod>> GetList(Expression<Func<ShipMethod, bool>> criterio)
    {
        return await context.ShipMethods
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(ShipMethod entidad)
    {
        await context.ShipMethods.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
