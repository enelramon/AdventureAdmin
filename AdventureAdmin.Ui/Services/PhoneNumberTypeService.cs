using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class PhoneNumberTypeService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.PhoneNumberType, int>
{
    public async Task<PhoneNumberType?> Buscar(int id)
    {
        return await context.PhoneNumberTypes
            .FirstOrDefaultAsync(p => p.PhoneNumberTypeId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var phoneNumberType = await context.PhoneNumberTypes
            .FirstOrDefaultAsync(p => p.PhoneNumberTypeId == id);

        if (phoneNumberType == null)
            return false;

        context.PhoneNumberTypes.Remove(phoneNumberType);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<PhoneNumberType>> GetList(Expression<Func<PhoneNumberType, bool>> criterio)
    {
        return await context.PhoneNumberTypes
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(PhoneNumberType entidad)
    {
       await context.PhoneNumberTypes.AddAsync(entidad);
         var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
