using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ScrapReasonService (
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.ScrapReason, int>
{
    public Task<Data.Models.ScrapReason?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.ScrapReason>> GetList(Expression<Func<Data.Models.ScrapReason, bool>> criterio)
    {
        return await context.ScrapReasons
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(Data.Models.ScrapReason entidad)
    {
        throw new NotImplementedException();
    }
}
