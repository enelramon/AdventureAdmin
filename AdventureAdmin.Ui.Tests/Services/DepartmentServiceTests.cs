using AdventureAdmin.Ui.Services;
using AdventureAdmin.Ui.Tests.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AdventureAdmin.Ui.Tests.Services;

public class DepartmentServiceTests
{
    [Fact]
    public async Task Buscar_CuandoExisteDepartamento_RetornaEntidad()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Departments.Add(CreateDepartment(id: 1, name: "Mensajeria Express 24h"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new DepartmentService(context);

        // Act
        var result = await service.Buscar(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result!.DepartmentId);
        Assert.Equal("Mensajeria Express 24h", result.Name);
        Assert.Empty(context.ChangeTracker.Entries());
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteDepartamento_RetornaNull()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new DepartmentService(context);

        // Act
        var result = await service.Buscar(999);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorID_RetornaCoincidencias()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Departments.AddRange(
                CreateDepartment(id: 1, name: "Entrega Urgente"),
                CreateDepartment(id: 2, name: "Envio Economico"),
                CreateDepartment(id: 3, name: "Envio Estandar"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new DepartmentService(context);

        // Act - Ajustado para que el Assert de 2 sea correcto
        var result = await service.GetList(s => s.DepartmentId != 2);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(result, s => s.DepartmentId == 1);
        Assert.Contains(result, s => s.DepartmentId == 3);
        Assert.DoesNotContain(result, s => s.DepartmentId == 2);
    }

    [Fact]
    public async Task Insertar_CuandoDepartamentoEsValido_GeneraDatosYAAlmacena()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new DepartmentService(context);
        var department = CreateDepartment(id: 10, name: "Servicio Regional Prioritario");
        var beforeInsert = DateTime.Now;

        // Act
        var wasInserted = await service.Insertar(department);

        // Assert
        Assert.True(wasInserted);
        Assert.True(department.ModifiedDate >= beforeInsert);

        var savedEntity = await context.Departments.FirstOrDefaultAsync(s => s.DepartmentId == 10);
        Assert.NotNull(savedEntity);
        Assert.Equal("Servicio Regional Prioritario", savedEntity!.Name);
    }

    [Fact]
    public async Task Existe_CuandoExisteDepartamento_RetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Departments.Add(CreateDepartment(id: 5, name: "Mensajeria Metropolitana"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new DepartmentService(context);

        // Act
        var exists = await service.Existe(5);

        // Assert
        Assert.True(exists);
    }

    [Fact]
    public async Task Existe_CuandoNoExisteDepartamento_RetornaFalse()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new DepartmentService(context);

        // Act
        var exists = await service.Existe(77);

        // Assert
        Assert.False(exists);
    }

    [Fact]
    public async Task Modificar_CuandoDepartamentoExiste_ActualizaDatosYFecha()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Departments.Add(CreateDepartment(id: 20, name: "Envio Estandar"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new DepartmentService(context);
        var updated = CreateDepartment(id: 20, name: "Envio Estandar Mejorado");
        var beforeUpdate = DateTime.Now;

        // Act
        var wasUpdated = await service.Actualizar(updated);

        // Assert
        Assert.True(wasUpdated);
        Assert.True(updated.ModifiedDate >= beforeUpdate);

        var saved = await context.Departments.FirstOrDefaultAsync(s => s.DepartmentId == 20);
        Assert.NotNull(saved);
        Assert.Equal("Envio Estandar Mejorado", saved!.Name);
    }

    [Fact]
    public async Task Guardar_CuandoDepartamentoNoExiste_InsertaYRetornaTrue()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new DepartmentService(context);
        var newDepartment = CreateDepartment(id: 30, name: "Entrega Programada 48h");

        // Act
        var result = await service.Guardar(newDepartment);

        // Assert
        Assert.True(result);

        var saved = await context.Departments.FirstOrDefaultAsync(s => s.DepartmentId == 30);
        Assert.NotNull(saved);
        Assert.Equal("Entrega Programada 48h", saved!.Name);
    }

    [Fact]
    public async Task Guardar_CuandoDepartamentoExiste_ModificaYRetornaTrue()
    {
        // Arrange
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.Departments.Add(CreateDepartment(id: 40, name: "Envio Internacional"));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new DepartmentService(context);
        var updated = CreateDepartment(id: 40, name: "Envio Internacional Express");

        // Act
        var result = await service.Guardar(updated);

        // Assert
        Assert.True(result);

        // Verificación correcta en la tabla de Departamentos
        var saved = await context.Departments.FirstOrDefaultAsync(s => s.DepartmentId == 40);
        Assert.NotNull(saved);
        Assert.Equal("Envio Internacional Express", saved!.Name);
    }

    [Fact]
    public async Task Eliminar_CuandoNoEstaImplementado_LanzaNotImplementedException()
    {
        // Arrange
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new DepartmentService(context);

        // Act + Assert
        await Assert.ThrowsAsync<NotImplementedException>(() => service.Eliminar(1));
    }

    private static Data.Models.Department CreateDepartment(
        short id,
        string name,
        string groupName = "10m",
        DateTime? modifiedDate = null)
    {
        return new Data.Models.Department
        {
            DepartmentId = id,
            Name = name,
            GroupName = groupName,
            ModifiedDate = modifiedDate ?? DateTime.Now
        };
    }
}