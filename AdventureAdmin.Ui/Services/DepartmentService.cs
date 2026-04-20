using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class DepartmentService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Department, int>
{
    public async Task<Data.Models.Department?> Buscar(int id)
    {
        return await context.Departments
           .FirstOrDefaultAsync(d => d.DepartmentId == ((short)id));
    }

    public async Task<bool> Eliminar(int id)
    {
        var department = await context.Departments.FindAsync((short)id);

        if (department == null)
            return false;

        context.Departments.Remove(department);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<bool> Guardar(Data.Models.Department entidad)
    {
        if (entidad.DepartmentId == 0)
            return await Insertar(entidad);
        else
            return await Actualizar(entidad);
    }

        public async Task<List<Data.Models.Department>> GetList(Expression<Func<Data.Models.Department, bool>> criterio)
    {
        return await context.Departments
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Actualizar(Data.Models.Department entidad)
    {
        entidad.ModifiedDate = DateTime.Now;
        var local = context.Departments.Local.FirstOrDefault(entry => entry.DepartmentId == entidad.DepartmentId);

        if (local != null)
        {
            context.Entry(local).State = EntityState.Detached;
        }
        context.Entry(entidad).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Existe(int id)
    {
        return await context.Departments.AnyAsync(a => a.DepartmentId == ((short)id));
    }

    public async Task<bool> Insertar(Data.Models.Department entidad)
    {
        entidad.ModifiedDate = DateTime.Now;
       await context.Departments.AddAsync(entidad);
        return await context.SaveChangesAsync() > 0;
    }
}
