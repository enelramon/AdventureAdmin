using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class DepartmetService(
     AdventureWorksContext context
    ): Aplicada1.Core.IService<Data.Models.Department, int>
{
    public async Task<Data.Models.Department?> Buscar(int id)
    {
        return await context.Departments
            .FirstOrDefaultAsync(x => x.DepartmentId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var department = await context.Departments
            .FirstOrDefaultAsync(x => x.DepartmentId == id);

        if (department == null)
            return false;

        context.Departments.Remove(department);
        var cantidad = await context.SaveChangesAsync();
        
        return cantidad > 0;
    }

    public async Task<List<Data.Models.Department>> GetList(Expression<Func<Data.Models.Department, bool>> criterio)
    {
        return await context.Departments
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.Department entidad)
    {
        await context.Departments.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
