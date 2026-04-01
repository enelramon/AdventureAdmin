using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class CustomerService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Customer, int>
{
    public Task<Data.Models.Customer?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.Customer>> GetList(Expression<Func<Data.Models.Customer, bool>> criterio)
    {
        return await context.Customers
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(Data.Models.Customer entidad)
    {
        throw new NotImplementedException();
    }
}
