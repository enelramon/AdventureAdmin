using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace AdventureAdmin.Ui.Services;

public class ProductService (
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Product, int>
{
    public async Task<Data.Models.Product?> Buscar(int id)
    {
       return await context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var product = await context.Products
            .FirstOrDefaultAsync(p => p.ProductId == id);

        if (product == null)
            return false;

        context.Products.Remove(product);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<Data.Models.Product>> GetList(Expression<Func<Data.Models.Product, bool>> criterio)
    {
        return await context.Products
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.Product entidad)
    {
        await context.Products.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
