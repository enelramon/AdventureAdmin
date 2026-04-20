using AdventureAdmin.Ui.Services;
using AdventureAdmin.Ui.Tests.Infrastructure;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using PersonEntity = AdventureAdmin.Data.Models.Person;

namespace AdventureAdmin.Ui.Tests.Services;

public class PersonServiceTests
{
    
    // Buscar
    

    [Fact]
    public async Task Buscar_CuandoExistePersona_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.People.Add(CreatePerson(id: 1, firstName: "Juan", lastName: "Perez"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new PersonService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result!.BusinessEntityId);
        Assert.Equal("Juan", result.FirstName);
        Assert.Equal("Perez", result.LastName);
    }

    [Fact]
    public async Task Buscar_CuandoNoExistePersona_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new PersonService(context);

        // Act
        var result = await service.Buscar(999);

        // Assert
        Assert.Null(result);
    }

    
    // GetList
    

    [Fact]
    public async Task GetList_CuandoSeFiltraPorTipo_RetornaCoincidencias()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.People.AddRange(
                CreatePerson(id: 1, firstName: "Ana", lastName: "Lopez", personType: "EM"),
                CreatePerson(id: 2, firstName: "Carlos", lastName: "Mendez", personType: "SP"),
                CreatePerson(id: 3, firstName: "Maria", lastName: "Ramirez", personType: "EM"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new PersonService(context);

        // Act
        var result = await service.GetList(p => p.PersonType == "EM");

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, p => p.BusinessEntityId == 1);
        Assert.Contains(result, p => p.BusinessEntityId == 3);
        Assert.DoesNotContain(result, p => p.BusinessEntityId == 2);
    }

    
    // Guardar
    

    [Fact]
    public async Task Guardar_CuandoPersonaEsValida_AlmacenaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new PersonService(context);
        var person = CreatePerson(id: 10, firstName: "Luis", lastName: "Fernandez");

        // Act
        var result = await service.Guardar(person);

        // Assert
        Assert.True(result);

        var saved = await context.People.FirstOrDefaultAsync(p => p.BusinessEntityId == 10);
        Assert.NotNull(saved);
        Assert.Equal("Luis", saved!.FirstName);
        Assert.Equal("Fernandez", saved.LastName);
    }

    
    // Actualizar
    

    [Fact]
    public async Task Actualizar_CuandoPersonaExiste_ActualizaDatosYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.People.Add(CreatePerson(id: 20, firstName: "Pedro", lastName: "Gomez"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new PersonService(context);
        var updated = CreatePerson(id: 20, firstName: "Pedro", lastName: "Gomez Torres");

        // Act
        var wasUpdated = await service.Actualizar(updated);

        // Assert
        Assert.True(wasUpdated);

        var saved = await context.People.FirstOrDefaultAsync(p => p.BusinessEntityId == 20);
        Assert.NotNull(saved);
        Assert.Equal("Gomez Torres", saved!.LastName);
    }

    
    // Eliminar
    

    [Fact]
    public async Task Eliminar_CuandoPersonaExiste_EliminaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.People.Add(CreatePerson(id: 30, firstName: "Sofia", lastName: "Vargas"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new PersonService(context);

        // Act
        var result = await service.Eliminar(30);

        // Assert
        Assert.True(result);

        var deleted = await context.People.FirstOrDefaultAsync(p => p.BusinessEntityId == 30);
        Assert.Null(deleted);
    }

    [Fact]
    public async Task Eliminar_CuandoPersonaNoExiste_RetornaFalse()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new PersonService(context);

        // Act
        var result = await service.Eliminar(999);

        // Assert
        Assert.False(result);
    }

    
    // CrearBusinessEntity
    

    [Fact]
    public async Task CrearBusinessEntity_CuandoSeInvoca_GeneraIdYAlmacenaEntidad()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new PersonService(context);

        // Act
        var newId = await service.CrearBusinessEntity();

        // Assert
        Assert.True(newId > 0);

        var saved = await context.BusinessEntities.FirstOrDefaultAsync(b => b.BusinessEntityId == newId);
        Assert.NotNull(saved);
        Assert.NotEqual(Guid.Empty, saved!.Rowguid);
        Assert.True(saved.ModifiedDate <= DateTime.Now);
    }

    [Fact]
    public async Task CrearBusinessEntity_CuandoSeInvocaVarias_GeneraIdsUnicos()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new PersonService(context);

        // Act
        var id1 = await service.CrearBusinessEntity();
        var id2 = await service.CrearBusinessEntity();
        var id3 = await service.CrearBusinessEntity();

        // Assert
        Assert.NotEqual(id1, id2);
        Assert.NotEqual(id2, id3);
        Assert.NotEqual(id1, id3);
    }

    
    // Helper
    

    private static PersonEntity CreatePerson(
        int id,
        string firstName,
        string lastName,
        string personType = "EM",
        string? middleName = null,
        DateTime? modifiedDate = null)
    {
        return new PersonEntity
        {
            BusinessEntityId = id,
            PersonType = personType,
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            NameStyle = false,
            EmailPromotion = 0,
            Rowguid = Guid.NewGuid(),
            ModifiedDate = modifiedDate ?? DateTime.Now
        };
    }
}