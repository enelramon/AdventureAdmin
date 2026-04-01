using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class PersonService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Person, int>
{
    public Task<Data.Models.Person?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.Person>> GetList(Expression<Func<Data.Models.Person, bool>> criterio)
    {
        return await context.People
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(Data.Models.Person entidad)
    {
        throw new NotImplementedException();
    }
}
