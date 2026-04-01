using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class PhoneNumberTypeService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.PhoneNumberType, int>
{
    public Task<PhoneNumberType?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PhoneNumberType>> GetList(Expression<Func<PhoneNumberType, bool>> criterio)
    {
        return await context.PhoneNumberTypes
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(PhoneNumberType entidad)
    {
        throw new NotImplementedException();
    }
}
