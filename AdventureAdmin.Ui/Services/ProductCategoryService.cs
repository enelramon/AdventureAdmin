using AdventureAdmin.Data.Context;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;


public class ProductCategoryService(
    AdventureWorksContext context
    ) : IService<Data.Models.ProductCategory, int>
{
    public async Task<bool> Guardar(Data.Models.ProductCategory nuevaCategoria)
    {
        await context.ProductCategories.AddAsync(nuevaCategoria);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public Task<Data.Models.ProductCategory?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.ProductCategory>> GetList(Expression<Func<Data.Models.ProductCategory, bool>> criterio)
    {
        return await context.ProductCategories
            .Where(criterio)
            .ToListAsync();
    }
}
