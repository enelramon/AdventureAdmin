using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdventureAdmin.Ui.Services;

public class PersonService(AdventureWorksContext context)
    : IService<Data.Models.Person, int>
{
    public async Task<Data.Models.Person?> Buscar(int id)
    {
        return await context.People
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.BusinessEntityId == id);
    }

    public async Task<bool> Eliminar(int id)
    {
        var person = await context.People
            .FirstOrDefaultAsync(p => p.BusinessEntityId == id);

        if (person == null)
            return false;

        context.People.Remove(person);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<List<Data.Models.Person>> GetList(
        Expression<Func<Data.Models.Person, bool>> criterio)
    {
        return await context.People
            .AsNoTracking()
            .Where(criterio)
            .OrderBy(p => p.BusinessEntityId)
            .ToListAsync();
    }

    public async Task<bool> Existe(int id)
    {
        return await context.People
            .AnyAsync(p => p.BusinessEntityId == id);
    }

    public async Task<bool> Guardar(Data.Models.Person person)
    {
        if (!await Existe(person.BusinessEntityId))
            return await Insertar(person);
        else
            return await Modificar(person);
    }

    public async Task<bool> Insertar(Data.Models.Person person)
    {
        person.Rowguid = Guid.NewGuid();
        person.ModifiedDate = DateTime.Now;

        context.People.Add(person);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Data.Models.Person person)
    {
        person.ModifiedDate = DateTime.Now;

        context.People.Update(person);

        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Actualizar(Data.Models.Person entidad)
    {
        return await Modificar(entidad);
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