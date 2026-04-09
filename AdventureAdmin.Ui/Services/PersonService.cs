using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class PersonService(
    AdventureWorksContext context)
  : IService<Data.Models.Person, int>
{
    public async Task<Data.Models.Person?> Buscar(int id)
    {
        return await context.People
            
            .FirstOrDefaultAsync(p => p.BusinessEntityId == id);

    }

    public async Task<bool> Eliminar(int id)
    {
        var person = await context.People
            .FirstOrDefaultAsync(p => p.BusinessEntityId == id);

        if (person == null)
            return false;

        context.People.Remove(person);
        var cantidad = await context.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<List<Data.Models.Person>> GetList(Expression<Func<Data.Models.Person, bool>> criterio)
    {
        return await context.People
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

    public async Task<bool> Actualizar(Data.Models.Person entidad)
    {
        context.Entry(entidad).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Data.Models.Person entidad)
    {

        await context.People.AddAsync(entidad);
        var cantidad = await context.SaveChangesAsync();
        return cantidad > 0;

    }


public async Task<int> CrearBusinessEntity()
    {
        var entity = new BusinessEntity
        {
            Rowguid = Guid.NewGuid(),
            ModifiedDate = DateTime.Now
        };

        context.BusinessEntities.Add(entity);
        await context.SaveChangesAsync();

        return entity.BusinessEntityId;
    }
}

