using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using PersonModel = AdventureAdmin.Data.Models.Person;

namespace AdventureAdmin.Ui.Services;

public class PersonService (
    AdventureWorksContext context
) : Aplicada1.Core.IService<PersonModel, int>
{
    public async Task<PersonModel?> Buscar(int id)
    {
        return await context.People.FindAsync(id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var persona = await context.People.FindAsync(id);
        if (persona == null) return false;
        
        context.People.Remove(persona);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<List<PersonModel>> GetList(Expression<Func<PersonModel, bool>> criterio)
    {
        return await context.People
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Guardar(PersonModel entity)
    {
        await context.People.AddAsync(entity);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;
    }
}
