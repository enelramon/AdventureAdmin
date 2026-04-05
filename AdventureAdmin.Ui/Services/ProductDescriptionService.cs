using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class ProductDescriptionService (
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.ProductDescription, int>
{
    public async Task<ProductDescription?> Buscar(int id)
    {
       return await context.ProductDescriptions
            .FirstOrDefaultAsync(pd => pd.ProductDescriptionId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var productDescription = await context.ProductDescriptions
            .FirstOrDefaultAsync(pd => pd.ProductDescriptionId == id);

        if (productDescription == null)
            return false;

        context.ProductDescriptions.Remove(productDescription);
        var cantidad = await context.SaveChangesAsync();
        
        return cantidad > 0;
    }

    public async Task<List<ProductDescription>> GetList(Expression<Func<ProductDescription, bool>> criterio)
    {
        return await context.ProductDescriptions
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(ProductDescription entidad)
    {
       await context.ProductDescriptions.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
