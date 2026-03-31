using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class ShipMethodService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<ShipMethod, int>
{
    public async Task<ShipMethod?> Buscar(int id)
    {
        return await context.ShipMethods.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var metodo = await context.ShipMethods.FindAsync(id);
        if (metodo == null) return false;
        
        context.ShipMethods.Remove(metodo);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<ShipMethod>> GetList(Expression<Func<ShipMethod, bool>> criterio)
    {
        return await context.ShipMethods
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.ShipMethod entity)
    {
        await context.ShipMethods.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
