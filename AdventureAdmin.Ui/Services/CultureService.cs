using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class CultureService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<Culture, string>
{
    public async Task<Culture?> Buscar(string id)
    {
        return await context.Cultures.FindAsync(id);
    }

    public async Task<bool> Eliminar(string id)
    {
        var cultura = await context.Cultures.FindAsync(id);
        if (cultura == null) return false;
        
        context.Cultures.Remove(cultura);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Culture>> GetList(Expression<Func<Culture, bool>> criterio)
    {
        return await context.Cultures
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.Culture entity)
    {
        await context.Cultures.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
