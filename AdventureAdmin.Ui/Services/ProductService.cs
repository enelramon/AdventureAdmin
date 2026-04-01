using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class ProductService (
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Product, int>
{
    public Task<Data.Models.Product?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Data.Models.Product>> GetList(Expression<Func<Data.Models.Product, bool>> criterio)
    {
        return await context.Products
            .Where(criterio)
            .ToListAsync();
    }

    public Task<bool> Guardar(Data.Models.Product entidad)
    {
        throw new NotImplementedException();
    }
}
