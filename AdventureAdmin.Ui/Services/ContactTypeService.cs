using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ContactTypeService : Aplicada1.Core.IService<AdventureAdmin.Data.Models.ContactType, int>
{
    public async Task<bool> Guardar(Data.Models.ContactType entidad)
    {
        using var context = new AdventureWorksContext();
        context.ContactTypes.Add(entidad);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<Data.Models.ContactType?> Buscar(int id)
    {
        using var context = new AdventureWorksContext();
        return await context.ContactTypes
            .FirstOrDefaultAsync(c => c.ContactTypeId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        using var context = new AdventureWorksContext();
        var existe = await context.ContactTypes
            .FirstOrDefaultAsync(c => c.ContactTypeId == id);
        if (existe == null) return false;
        context.ContactTypes.Remove(existe);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Data.Models.ContactType>> GetList(
        Expression<Func<Data.Models.ContactType, bool>> criterio)
    {
        using var context = new AdventureWorksContext();
        return await context.ContactTypes
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Actualizar(Data.Models.ContactType entidad)
    {
        using var context = new AdventureWorksContext();
        context.Entry(entidad).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }


}