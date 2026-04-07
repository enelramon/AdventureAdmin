using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ContactTypeModel = AdventureAdmin.Data.Models.ContactType;

namespace AdventureAdmin.Ui.Services;

public class ContactTypeService(
    AdventureWorksContext context
) : Aplicada1.Core.IService<ContactTypeModel, int>
{
    public async Task<ContactTypeModel?> Buscar(int id)
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

    public async Task<List<ContactTypeModel>> GetList(Expression<Func<ContactTypeModel, bool>> criterio)
    {
        return await context.ContactTypes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(ContactTypeModel entity)
    {
        var existe = await context.ContactTypes.FindAsync(entity.ContactTypeId);
        
        if (existe != null)
        {
            context.Entry(existe).CurrentValues.SetValues(entity);
        }
        else
        {
            await context.ContactTypes.AddAsync(entity);
        }
        
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
