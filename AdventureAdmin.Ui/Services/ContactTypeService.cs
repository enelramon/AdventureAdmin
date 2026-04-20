using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class ContactTypeService (AdventureWorksContext context) : Aplicada1.Core.IService<AdventureAdmin.Data.Models.ContactType, int>
{
    public async Task<bool> Guardar(Data.Models.ContactType entidad)
    {
        if (entidad.ContactTypeId == 0)
            context.ContactTypes.Add(entidad);
        else
                context.ContactTypes.Update(entidad);
     
        return await context.SaveChangesAsync() > 0;
    }
    public async Task<Data.Models.ContactType?> Buscar(int id)
    {
        return await context.ContactTypes
            .FirstOrDefaultAsync(c => c.ContactTypeId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var existe = await context.ContactTypes
           .FirstOrDefaultAsync(c => c.ContactTypeId == id);

        if (existe == null)
            return false;

        context.ContactTypes.Remove(existe);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Data.Models.ContactType>> GetList(Expression<Func<Data.Models.ContactType, bool>> criterio)
    {
        return await context.ContactTypes
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Actualizar(Data.Models.ContactType entidad)
    {
        context.Entry(entidad).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }
}
