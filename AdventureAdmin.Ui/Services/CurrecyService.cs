using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class CurrecyService (
     AdventureWorksContext context
    ) : Aplicada1.Core.IService<Currency, int>


{
    public Task<Currency?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Currency>> GetList(Expression<Func<Currency, bool>> criterio)
    {
        return await context.Currencies
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(Currency entidad)
    {
        throw new NotImplementedException();
    }
}
