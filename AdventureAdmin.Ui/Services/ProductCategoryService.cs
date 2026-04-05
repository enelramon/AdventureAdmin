using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class ProductCategoryService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.ProductCategory, int>
{
    public async Task<ProductCategory?> Buscar(int id)
    {
        return await context.ProductCategories
            .FirstOrDefaultAsync(pc => pc.ProductCategoryId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var productCategory = await context.ProductCategories
            .FirstOrDefaultAsync(pc => pc.ProductCategoryId == id);

        if (productCategory == null)
            return false;

        context.ProductCategories.Remove(productCategory);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<ProductCategory>> GetList(Expression<Func<ProductCategory, bool>> criterio)
    {
        return await context.ProductCategories
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(ProductCategory entidad)
    {
        await context.ProductCategories.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
