using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class CurrencyServices(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Currency, int>
{
    public async Task<Currency?> Buscar(int id)
    {
        return await context.Currencies
            .FirstOrDefaultAsync(c => c.CurrencyId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var currency = await context.Currencies
            .FirstOrDefaultAsync(c => c.CurrencyId == id);

        if (currency == null)
            return false;

        context.Currencies.Remove(currency);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<Currency>> GetList(Expression<Func<Currency, bool>> criterio)
    {
        return await context.Currencies
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Currency entidad)
    {
        await context.Currencies.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
