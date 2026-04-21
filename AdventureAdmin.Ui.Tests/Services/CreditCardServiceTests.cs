using AdventureAdmin.Ui.Tests.Infrastructure;
using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;
using CreditCardEntity = AdventureAdmin.Data.Models.CreditCard;

namespace AdventureAdmin.Ui.Tests.Services;

public class CreditCardServiceTests
{
    [Fact]
    public async Task Buscar_CuandoExisteCreditCard_RetornaEntidad()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.CreditCards.Add(CreateCreditCard(id: 1, cardType: "Visa", cardNumber: "4111111111111111", expMonth: 12, expYear: 2025));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new CreditCardService(context);

        var result = await service.Buscar(1);

        Assert.NotNull(result);
        Assert.Equal(1, result!.CreditCardId);
        Assert.Equal("Visa", result.CardType);
    }

    [Fact]
    public async Task Buscar_CuandoNoExisteCreditCard_RetornaNull()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new CreditCardService(context);

        var result = await service.Buscar(999);

        Assert.Null(result);
    }

    [Fact]
    public async Task GetList_CuandoSeFiltraPorCardType_RetornaCoincidencias()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.CreditCards.AddRange(
                CreateCreditCard(id: 1, cardType: "Visa", cardNumber: "4111111111111111", expMonth: 6, expYear: 2025),
                CreateCreditCard(id: 2, cardType: "MasterCard", cardNumber: "5111111111111111", expMonth: 8, expYear: 2026),
                CreateCreditCard(id: 3, cardType: "Visa", cardNumber: "4111111111111112", expMonth: 12, expYear: 2027));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new CreditCardService(context);

        var result = await service.GetList(c => c.CardType == "Visa");

        Assert.Equal(2, result.Count);
        Assert.Contains(result, c => c.CreditCardId == 1);
        Assert.Contains(result, c => c.CreditCardId == 3);
        Assert.DoesNotContain(result, c => c.CreditCardId == 2);
    }

    [Fact]
    public async Task Guardar_CuandoCreditCardEsValida_InsertaCorrectamente()
    {
        await using var context = TestDbContextFactory.CreateContext(TestDbContextFactory.NewDatabaseName());
        var service = new CreditCardService(context);
        var newCreditCard = CreateCreditCard(id: 10, cardType: "American Express", cardNumber: "371111111111111", expMonth: 3, expYear: 2028);

        var result = await service.Guardar(newCreditCard);

        Assert.True(result);

        var savedEntity = await context.CreditCards.FirstOrDefaultAsync(c => c.CreditCardId == 10);
        Assert.NotNull(savedEntity);
        Assert.Equal("American Express", savedEntity!.CardType);
    }

    [Fact]
    public async Task Modificar_CuandoCreditCardExiste_ActualizaDatosYFecha()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.CreditCards.Add(CreateCreditCard(id: 20, cardType: "Visa", cardNumber: "4111111111111111", expMonth: 1, expYear: 2024));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new CreditCardService(context);
        var updated = CreateCreditCard(id: 20, cardType: "MasterCard", cardNumber: "5111111111111111", expMonth: 6, expYear: 2026);
        var beforeUpdate = DateTime.Now;

        var wasUpdated = await service.Modificar(updated);

        Assert.True(wasUpdated);
        Assert.True(updated.ModifiedDate >= beforeUpdate);

        var saved = await context.CreditCards.FirstOrDefaultAsync(c => c.CreditCardId == 20);
        Assert.NotNull(saved);
        Assert.Equal("MasterCard", saved!.CardType);
    }

    [Fact]
    public async Task Eliminar_CuandoExisteCreditCard_EliminaCorrectamente()
    {
        var dbName = TestDbContextFactory.NewDatabaseName();
        await using (var seedContext = TestDbContextFactory.CreateContext(dbName))
        {
            seedContext.CreditCards.Add(CreateCreditCard(id: 3, cardType: "Visa", cardNumber: "4111111111111111", expMonth: 12, expYear: 2025));
            await seedContext.SaveChangesAsync();
        }

        await using var context = TestDbContextFactory.CreateContext(dbName);
        var service = new CreditCardService(context);

        var result = await service.Eliminar(3);

        Assert.True(result);
        Assert.Empty(context.CreditCards);
    }

    private static CreditCardEntity CreateCreditCard(int id, string cardType, string cardNumber, byte expMonth, short expYear)
    {
        return new CreditCardEntity
        {
            CreditCardId = id,
            CardType = cardType,
            CardNumber = cardNumber,
            ExpMonth = expMonth,
            ExpYear = expYear,
            ModifiedDate = DateTime.Now
        };
    }
}