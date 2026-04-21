using AdventureAdmin.Ui.Tests.Infrastructure;
using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;
using LocationEntity = AdventureAdmin.Data.Models.Location;

namespace AdventureAdmin.Ui.Tests.Services;

public class LocationServiceTests
{
    [Fact]
    public async Task Buscar_CuandoExisteLocation_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Locations.Add(CreateLocation(id: 1, name: "Santiago", costRate: 15.5m, availability: 80.0m));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new LocationService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result!.LocationId);
        Assert.Equal("Santiago", result.Name);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteLocation_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new LocationService(context);

        // Act
        var result = await service.Buscar(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorCostRate_RetornaCoincidencias()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Locations.AddRange(
                CreateLocation(id: 1, name: "Almacen Principal", costRate: 14.99m, availability: 100.0m),
                CreateLocation(id: 2, name: "Sucursal Secundaria", costRate: 3.99m, availability: 50.0m),
                CreateLocation(id: 3, name: "Depósito Remoto", costRate: 8.99m, availability: 75.0m));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new LocationService(context);

        // Act
        var result = await service.GetList(l => l.CostRate >= 8.50m);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, l => l.LocationId == 1);
        Assert.Contains(result, l => l.LocationId == 3);
        Assert.DoesNotContain(result, l => l.LocationId == 2);
    }

    [Fact]
    public async Task Guardar_CuandoLocationEsValida_InsertaCorrectamente()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new LocationService(context);
        var newLocation = CreateLocation(id: 10, name: "Nueva Sede Regional", costRate: 10.49m, availability: 95.5m);

        // Act
        var result = await service.Guardar(newLocation);

        // Assert
        Assert.True(result);

        var savedEntity = await context.Locations.FirstOrDefaultAsync(l => l.LocationId == 10);
        Assert.NotNull(savedEntity);
        Assert.Equal("Nueva Sede Regional", savedEntity!.Name);
    }

    [Fact]
    public async Task Modificar_CuandoLocationExiste_ActualizaDatosYFecha()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Locations.Add(CreateLocation(id: 20, name: "Sede Antigua", costRate: 7.99m, availability: 60.0m));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new LocationService(context);
        var updated = CreateLocation(id: 20, name: "Sede Antigua Mejorada", costRate: 9.49m, availability: 85.0m);
        var beforeUpdate = DateTime.Now;

        // Act
        var wasUpdated = await service.Modificar(updated);

        // Assert
        Assert.True(wasUpdated);
        Assert.True(updated.ModifiedDate >= beforeUpdate);

        var saved = await context.Locations.FirstOrDefaultAsync(l => l.LocationId == 20);
        Assert.NotNull(saved);
        Assert.Equal("Sede Antigua Mejorada", saved!.Name);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteLocation_EliminaCorrectamente()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Locations.Add(CreateLocation(id: 3, name: "Moca", costRate: 12.0m, availability: 90.0m));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new LocationService(context);

        // Act
        var result = await service.Eliminar(3);

        // Assert
        Assert.True(result);
        Assert.Empty(context.Locations);
    }

    private static LocationEntity CreateLocation(short id, string name, decimal costRate, decimal availability)
    {
        return new LocationEntity
        {
            LocationId = id,
            Name = name,
            CostRate = costRate,
            Availability = availability,
            ModifiedDate = DateTime.Now
        };
    }
}
