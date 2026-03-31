using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class PhoneNumberTypeService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<PhoneNumberType, int>
{
    public async Task<PhoneNumberType?> Buscar(int id)
    {
        return await context.PhoneNumberTypes.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var tipo = await context.PhoneNumberTypes.FindAsync(id);
        if (tipo == null) return false;
        
        context.PhoneNumberTypes.Remove(tipo);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<PhoneNumberType>> GetList(Expression<Func<PhoneNumberType, bool>> criterio)
    {
        return await context.PhoneNumberTypes
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.PhoneNumberType entity)
    {
        await context.PhoneNumberTypes.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
