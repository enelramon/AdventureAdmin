using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class AddressTypeServices(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.AddressType, int>
{
    public async Task<AddressType?> Buscar(int id)
    {
        return await context.AddressTypes
            .FirstOrDefaultAsync(a => a.AddressTypeId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
       var addressType = await context.AddressTypes
            .FirstOrDefaultAsync(a => a.AddressTypeId == id);


        if (addressType is null)
            return false;


        context.AddressTypes.Remove(addressType);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<AddressType>> GetList(Expression<Func<AddressType, bool>> criterio)
    {
        return await context.AddressTypes
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(AddressType entidad)
    {
        await context.AddressTypes.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
