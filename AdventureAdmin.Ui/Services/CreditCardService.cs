using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class CreditCardService(
    AdventureWorksContext context
    ) : IService<Data.Models.CreditCard, int>
{
public async Task<bool> Guardar(Data.Models.CreditCard tarjeta)
    {
        if (tarjeta.CreditCardId == 0)
        {
            await context.CreditCards.AddAsync(tarjeta);
        }
        else
        {
            var exists = await context.CreditCards.FindAsync(tarjeta.CreditCardId);
            if (exists == null)
            {
                await context.CreditCards.AddAsync(tarjeta);
            }
            else
            {
                context.CreditCards.Update(tarjeta);
            }
        }
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<bool> Modificar(Data.Models.CreditCard tarjeta)
    {
        var existing = await context.CreditCards.FindAsync(tarjeta.CreditCardId);
        if (existing == null) return false;

        existing.CardType = tarjeta.CardType;
        existing.CardNumber = tarjeta.CardNumber;
        existing.ExpMonth = tarjeta.ExpMonth;
        existing.ExpYear = tarjeta.ExpYear;
        existing.ModifiedDate = DateTime.Now;

        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<bool> Eliminar(int id)
    {
        var tarjeta = await context.CreditCards.FindAsync(id);
        if (tarjeta == null) return false;

        context.CreditCards.Remove(tarjeta);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<Data.Models.CreditCard?> Buscar(int id)
    {
        return await context.CreditCards.FindAsync(id);
    }

    public async Task<List<Data.Models.CreditCard>> GetList(Expression<Func<Data.Models.CreditCard, bool>> criterio)
    {
        return await context.CreditCards
            .Where(criterio)
            .ToListAsync();
    }
}

