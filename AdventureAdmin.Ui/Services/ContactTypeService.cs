using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class ContactTypeService (
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.ContactType, int>
{
    public Task<ContactType?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ContactType>> GetList(Expression<Func<ContactType, bool>> criterio)
    {
        return await context.ContactTypes
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(ContactType entidad)
    {
        throw new NotImplementedException();
    }
}
