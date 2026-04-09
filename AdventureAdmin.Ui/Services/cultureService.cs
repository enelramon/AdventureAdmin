using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class CultureService(
   AdventureWorksContext context
    ) : IService<Data.Models.Culture, int>
{
    public Task<Data.Models.Culture?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.Culture>> GetList(Expression<Func<Data.Models.Culture, bool>> criterio)
    {
        return await context.Cultures
             .Where(criterio)
             .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.Culture entidad)
    {
        await context.Cultures.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
