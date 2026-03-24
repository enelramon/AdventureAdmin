using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class CreditCardService(
    AdventureWorksContext context
    ) : IService<Data.Models.CreditCard, int>
{
    public async Task<bool> Guardar(Data.Models.CreditCard nuevaTarjeta)
    {
        await context.CreditCards.AddAsync(nuevaTarjeta);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.CreditCard?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.CreditCard>> GetList(Expression<Func<Data.Models.CreditCard, bool>> criterio)
    {
        return await context.CreditCards
            .Where(criterio)
            .ToListAsync();
    }
}

