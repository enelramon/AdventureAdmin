using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class CreditCardService(
    AdventureWorksContext context
    ) : IService<Data.Models.CreditCard, int>
{
    public async Task<Data.Models.CreditCard?> Buscar(int id)
    {
        return await context.CreditCards.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var tarjeta = await context.CreditCards.FindAsync(id);
        if (tarjeta == null) return false;
        
        context.CreditCards.Remove(tarjeta);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<bool> Guardar(Data.Models.CreditCard tarjeta)
    {
        await context.CreditCards.AddAsync(tarjeta);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<bool> Actualizar(Data.Models.CreditCard tarjeta)
    {
        var existe = await context.CreditCards.FindAsync(tarjeta.CreditCardId);
        if (existe == null) return false;

        context.Entry(existe).CurrentValues.SetValues(tarjeta);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Data.Models.CreditCard>> GetList(Expression<Func<Data.Models.CreditCard, bool>> criterio)
    {
        return await context.CreditCards
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
