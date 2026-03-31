using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class ContactTypeService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<ContactType, int>
{
    public async Task<ContactType?> Buscar(int id)
    {
        return await context.ContactTypes.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var tipo = await context.ContactTypes.FindAsync(id);
        if (tipo == null) return false;
        
        context.ContactTypes.Remove(tipo);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<ContactType>> GetList(Expression<Func<ContactType, bool>> criterio)
    {
        return await context.ContactTypes
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.ContactType entity)
    {
        await context.ContactTypes.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
