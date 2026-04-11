

using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ShipMethodService (AdventureWorksContext context) : IService<Data.Models.ShipMethod, int>
{
    public Task<Data.Models.ShipMethod?> Buscar(int id)
    {
        return context.ShipMethods
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.ShipMethodId == id);
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.ShipMethod>> GetList(Expression<Func<Data.Models.ShipMethod, bool>> criterio)
    {
        return await context.ShipMethods
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Insertar(Data.Models.ShipMethod shipMethod)
    {
        shipMethod.Rowguid = Guid.NewGuid();
        shipMethod.ModifiedDate = DateTime.Now;
        context.ShipMethods.Add(shipMethod);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Data.Models.ShipMethod shipMethod)
    {
        if (!await Existe(shipMethod.ShipMethodId))
            return await Insertar(shipMethod);
        else
            return await Modificar(shipMethod);
    }
 

    public async Task<bool> Existe(int id)
    {
        return await context.ShipMethods.AnyAsync(a => a.ShipMethodId == id);
    }

    public async Task<bool> Modificar(Data.Models.ShipMethod shipMethod)
    {
        shipMethod.ModifiedDate = DateTime.Now;
        context.ShipMethods.Update(shipMethod);
        return await context.SaveChangesAsync() > 0;
    }
}
