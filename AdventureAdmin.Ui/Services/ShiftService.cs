using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

internal class ShiftService(
    AdventureWorksContext context
    ) : Aplicada1.Core.IService<Data.Models.Shift, int>
{
    public async Task<Shift?> Buscar(int id)
    {
        return await context.Shifts
            .FirstOrDefaultAsync(s => s.ShiftId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var shift = await context.Shifts
            .FirstOrDefaultAsync(s => s.ShiftId == id);

        if (shift == null)
            return false;

        context.Shifts.Remove(shift);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<Shift>> GetList(Expression<Func<Shift, bool>> criterio)
    {
        return await context.Shifts
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(Shift entidad)
    {
        await context.Shifts.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
