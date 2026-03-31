using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class AddressTypeService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<AddressType, int>
{
    public async Task<AddressType?> Buscar(int id)
    {
        return await context.AddressTypes.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var tipo = await context.AddressTypes.FindAsync(id);
        if (tipo == null) return false;
        
        context.AddressTypes.Remove(tipo);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<AddressType>> GetList(Expression<Func<AddressType, bool>> criterio)
    {
        return await context.AddressTypes
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.AddressType entity)
    {
        await context.AddressTypes.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
