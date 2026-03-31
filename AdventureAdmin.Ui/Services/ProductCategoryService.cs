using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class ProductCategoryService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<ProductCategory, int>
{
    public async Task<ProductCategory?> Buscar(int id)
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

    public async Task<List<ProductCategory>> GetList(Expression<Func<ProductCategory, bool>> criterio)
    {
        return await context.ProductCategories
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.ProductCategory entity)
    {
        await context.ProductCategories.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
