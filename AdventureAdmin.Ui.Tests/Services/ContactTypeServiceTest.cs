using AdventureAdmin.Ui.Tests.Infrastructure;
using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;
using ContactTypeEntity = AdventureAdmin.Data.Models.ContactType;

namespace AdventureAdmin.Ui.Tests.Services;

public class ContactTypeServiceTest
{
    [Fact]
    public async Task Buscar_CuandoExisteContactType_RetornaEntidad()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ContactTypes.Add(CreateContactType(id: 1, name: "Support"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ContactTypeService(context);

        var result = await service.Buscar(1);

        Assert.NotNull(result);
        Assert.Equal(1, result!.ContactTypeId);
        Assert.Equal("Support", result.Name);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteContactType_RetornaNull()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ContactTypeService(context);

        var result = await service.Buscar(999);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorName_RetornaCoincidencias()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ContactTypes.AddRange(
                CreateContactType(id: 1, name: "Support"),
                CreateContactType(id: 2, name: "Sales"),
                CreateContactType(id: 3, name: "Support"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ContactTypeService(context);

        var result = await service.GetList(c => c.Name == "Support");

        Assert.Equal(2, result.Count);
        Assert.Contains(result, c => c.ContactTypeId == 1);
        Assert.Contains(result, c => c.ContactTypeId == 3);
        Assert.DoesNotContain(result, c => c.ContactTypeId == 2);
    }

    [Fact]
    public async Task Guardar_CuandoContactTypeEsValida_InsertaCorrectamente()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ContactTypeService(context);
        var newEntity = CreateContactType(id: 10, name: "Billing");

        var result = await service.Guardar(newEntity);

        Assert.True(result);

        var savedEntity = await context.ContactTypes.FirstOrDefaultAsync(c => c.ContactTypeId == 10);
        Assert.NotNull(savedEntity);
        Assert.Equal("Billing", savedEntity!.Name);
    }

    [Fact]
    public async Task Modificar_CuandoContactTypeExiste_ActualizaDatosYFecha()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ContactTypes.Add(CreateContactType(id: 20, name: "Support"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ContactTypeService(context);
        var updated = CreateContactType(id: 20, name: "Customer Service");
        var beforeUpdate = DateTime.Now;

        var wasUpdated = await service.Actualizar(updated);

        var saved = await context.ContactTypes.FirstOrDefaultAsync(c => c.ContactTypeId == 20);

        Assert.True(wasUpdated);
        Assert.NotNull(saved);
        Assert.True(saved.ModifiedDate >= beforeUpdate);
        Assert.NotNull(saved);
        Assert.Equal("Customer Service", saved!.Name);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteContactType_EliminaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ContactTypes.Add(CreateContactType(id: 3, name: "Support"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ContactTypeService(context);

        var result = await service.Eliminar(3);

        Assert.True(result);
        Assert.Empty(context.ContactTypes);
    }

    private static ContactTypeEntity CreateContactType(int id, string name)
    {
        return new ContactTypeEntity
        {
            ContactTypeId = id,
            Name = name,
            ModifiedDate = DateTime.Now
        };
    }
}
