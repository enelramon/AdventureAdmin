using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class DepartmentService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Department, int>
{
    public Task<Data.Models.Department?> Buscar(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Eliminar(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Guardar(Data.Models.Department entidad)
    {
        await context.Departments.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Data.Models.Department>> GetList(Expression<Func<Data.Models.Department, bool>> criterio)
    {
        return await context.Departments
        .Where(criterio)
        .ToListAsync();
    }
}
