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
        // aqui borro de la base de datos
        throw new NotImplementedException();
    }

    public async Task<bool> Guardar(Data.Models.Department modelo)
    {
        // Cambio en rama issue/sin_conflicto
        await context.Departments.AddAsync(modelo);
        var cantidad = await context.SaveChangesAsync();
        return cantidad >= 1;  // Cambié > 1 a >= 1
    }

    public async Task<List<Data.Models.Department>> GetList(Expression<Func<Data.Models.Department, bool>> criterio)
    {
        return await context.Departments.Where(criterio).ToListAsync();
    }
}
