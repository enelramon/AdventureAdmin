using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AdventureAdmin.Ui.Services;

public class ShiftService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<Shift, byte>
{
    public async Task<Shift?> Buscar(byte id)
    {
        return await context.Shifts.FindAsync(id);
    }

    public async Task<bool> Eliminar(byte id)
    {
        var turno = await context.Shifts.FindAsync(id);
        if (turno == null) return false;
        
        context.Shifts.Remove(turno);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Shift>> GetList(Expression<Func<Shift, bool>> criterio)
    {
        return await context.Shifts
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Data.Models.Shift entity)
    {
        await context.Shifts.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
