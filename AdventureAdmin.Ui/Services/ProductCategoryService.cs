using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ProductCategoryService(
    AdventureWorksContext context
) : Aplicada1.Core.IService<Data.Models.ProductCategory, int>
{
    public async Task<Data.Models.ProductCategory?> Buscar(int id)
    {
        return await context.ProductCategories.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var categoria = await context.ProductCategories.FindAsync(id);
        if (categoria == null) return false;
        
        context.ProductCategories.Remove(categoria);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<bool> Guardar(Data.Models.ProductCategory entity)
    {
        await context.ProductCategories.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Data.Models.ProductCategory>> GetList(Expression<Func<Data.Models.ProductCategory, bool>> criterio)
    {
        return await context.ProductCategories
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}
