using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace AdventureAdmin.Ui.Services;

public class CustomerService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Customer, int>
{
    public async Task<Data.Models.Customer?> Buscar(int id)
    {
       return await context.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var customer = context.Customers
            .FirstOrDefaultAsync(c => c.CustomerId == id);

        if (customer is null)
            return false;


        context.Customers.Remove(customer.Result);
        var cantidad = context.SaveChangesAsync();
        return cantidad.Result > 0;


    }

    public async Task<List<Data.Models.Customer>> GetList(Expression<Func<Data.Models.Customer, bool>> criterio)
    {
        return await context.Customers
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.Customer entidad)
    {
        await context.Customers.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
