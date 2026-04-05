using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class ContactTypeService (
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.ContactType, int>
{
    public async Task<ContactType?> Buscar(int id)
    {
        return await context.ContactTypes
            .FirstOrDefaultAsync(c => c.ContactTypeId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var contactType = await context.ContactTypes
            .FirstOrDefaultAsync(c => c.ContactTypeId == id);


        if (contactType is null)
            return false;

        context.ContactTypes.Remove(contactType);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<ContactType>> GetList(Expression<Func<ContactType, bool>> criterio)
    {
        return await context.ContactTypes
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(ContactType entidad)
    {
        await context.ContactTypes.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
