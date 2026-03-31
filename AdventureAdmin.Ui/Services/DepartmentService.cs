using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class DepartmentService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<Data.Models.Department, short>
{
    public async Task<Data.Models.Department?> Buscar(short id)
    {
        return await context.Departments.FindAsync(id);
    }

    public async Task<bool> Eliminar(short id)
    {
        var departamento = await context.Departments.FindAsync(id);
        if (departamento == null) return false;
        
        context.Departments.Remove(departamento);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Data.Models.Department>> GetList(Expression<Func<Data.Models.Department, bool>> criterio)
    {
        return await context.Departments
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.Department entity)
    {
        await context.Departments.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
