using AdventureAdmin.Ui.Tests.Infrastructure;
using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;
using ShipMethodEntity = AdventureAdmin.Data.Models.ShipMethod;

namespace AdventureAdmin.Ui.Tests.Services;

public class ShipMethodServiceTests
{
    [Fact]
    public async Task Buscar_CuandoExisteMetodoDeEnvio_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ShipMethods.Add(CreateShipMethod(id: 1, name: "Mensajeria Express 24h", shipBase: 12.50m, shipRate: 1.80m));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ShipMethodService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result!.ShipMethodId);
        Assert.Equal("Mensajeria Express 24h", result.Name);
        Assert.Empty(context.ChangeTracker.Entries());
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteMetodoDeEnvio_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ShipMethodService(context);

        // Act
        var result = await service.Buscar(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorCostoBase_RetornaCoincidencias()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ShipMethods.AddRange(
                CreateShipMethod(id: 1, name: "Entrega Urgente", shipBase: 14.99m, shipRate: 2.40m),
                CreateShipMethod(id: 2, name: "Envio Economico", shipBase: 3.99m, shipRate: 0.70m),
                CreateShipMethod(id: 3, name: "Envio Estandar", shipBase: 8.99m, shipRate: 1.25m));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ShipMethodService(context);

        // Act
        var result = await service.GetList(s => s.ShipBase >= 8.50m);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, s => s.ShipMethodId == 1);
        Assert.Contains(result, s => s.ShipMethodId == 3);
        Assert.DoesNotContain(result, s => s.ShipMethodId == 2);
    }

    [Fact]
    public async Task Insertar_CuandoMetodoEsValido_GeneraDatosYAAlmacena()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ShipMethodService(context);
        var shipMethod = CreateShipMethod(id: 10, name: "Servicio Regional Prioritario", shipBase: 10.49m, shipRate: 1.65m, rowguid: Guid.Empty, modifiedDate: default);
        var beforeInsert = DateTime.Now;

        // Act
        var wasInserted = await service.Insertar(shipMethod);

        // Assert
        Assert.True(wasInserted);
        Assert.NotEqual(Guid.Empty, shipMethod.Rowguid);
        Assert.True(shipMethod.ModifiedDate >= beforeInsert);

        var savedEntity = await context.ShipMethods.FirstOrDefaultAsync(s => s.ShipMethodId == 10);
        Assert.NotNull(savedEntity);
        Assert.Equal("Servicio Regional Prioritario", savedEntity!.Name);
    }

    [Fact]
    public async Task Existe_CuandoExisteMetodoDeEnvio_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ShipMethods.Add(CreateShipMethod(id: 5, name: "Mensajeria Metropolitana", shipBase: 6.99m, shipRate: 0.95m));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ShipMethodService(context);

        // Act
        var exists = await service.Existe(5);

        // Assert
        Assert.True(exists);
    }

    [Fact]
    public async Task Existe_CuandoNoExisteMetodoDeEnvio_RetornaFalse()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ShipMethodService(context);

        // Act
        var exists = await service.Existe(77);

        // Assert
        Assert.False(exists);
    }

    [Fact]
    public async Task Modificar_CuandoMetodoExiste_ActualizaDatosYFecha()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        var originalRowguid = Guid.NewGuid();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ShipMethods.Add(CreateShipMethod(id: 20, name: "Envio Estandar", shipBase: 7.99m, shipRate: 1.10m, rowguid: originalRowguid));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ShipMethodService(context);
        var updated = CreateShipMethod(id: 20, name: "Envio Estandar Mejorado", shipBase: 9.49m, shipRate: 1.35m, rowguid: originalRowguid, modifiedDate: default);
        var beforeUpdate = DateTime.Now;

        // Act
        var wasUpdated = await service.Modificar(updated);

        // Assert
        Assert.True(wasUpdated);
        Assert.True(updated.ModifiedDate >= beforeUpdate);

        var saved = await context.ShipMethods.FirstOrDefaultAsync(s => s.ShipMethodId == 20);
        Assert.NotNull(saved);
        Assert.Equal("Envio Estandar Mejorado", saved!.Name);
    }

    [Fact]
    public async Task Guardar_CuandoMetodoNoExiste_InsertaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ShipMethodService(context);
        var newShipMethod = CreateShipMethod(id: 30, name: "Entrega Programada 48h", shipBase: 11.25m, shipRate: 1.55m, rowguid: Guid.Empty, modifiedDate: default);

        // Act
        var result = await service.Guardar(newShipMethod);

        // Assert
        Assert.True(result);

        var saved = await context.ShipMethods.FirstOrDefaultAsync(s => s.ShipMethodId == 30);
        Assert.NotNull(saved);
        Assert.Equal("Entrega Programada 48h", saved!.Name);
        Assert.NotEqual(Guid.Empty, saved.Rowguid);
    }

    [Fact]
    public async Task Guardar_CuandoMetodoExiste_ModificaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        var rowguid = Guid.NewGuid();

        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.ShipMethods.Add(CreateShipMethod(id: 40, name: "Envio Internacional", shipBase: 25.99m, shipRate: 4.20m, rowguid: rowguid));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new ShipMethodService(context);
        var updated = CreateShipMethod(id: 40, name: "Envio Internacional Express", shipBase: 32.50m, shipRate: 5.10m, rowguid: rowguid, modifiedDate: default);

        // Act
        var result = await service.Guardar(updated);

        // Assert
        Assert.True(result);

        var saved = await context.ShipMethods.FirstOrDefaultAsync(s => s.ShipMethodId == 40);
        Assert.NotNull(saved);
        Assert.Equal("Envio Internacional Express", saved!.Name);
    }

    [Fact]
    public async Task Eliminar_CuandoNoEstaImplementado_LanzaNotImplementedException()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new ShipMethodService(context);

        // Act + Assert
        await Assert.ThrowsAsync<NotImplementedException>(() => service.Eliminar(1));
    }

    private static ShipMethodEntity CreateShipMethod(
        int id,
        string name,
        decimal shipBase = 10m,
        decimal shipRate = 2m,
        Guid? rowguid = null,
        DateTime? modifiedDate = null)
    {
        return new ShipMethodEntity
        {
            ShipMethodId = id,
            Name = name,
            ShipBase = shipBase,
            ShipRate = shipRate,
            Rowguid = rowguid ?? Guid.NewGuid(),
            ModifiedDate = modifiedDate ?? DateTime.Now
        };
    }
}
