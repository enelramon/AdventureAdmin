using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdmin.Ui.Tests.Infrastructure;

public static class TestDbContextFactory
{
    public static string NewDatabaseName() => $"AdventureAdminTests_{Guid.NewGuid()}";

    public static AdventureWorksContext CreateContext(string databaseName)
    {
        var options = new DbContextOptionsBuilder<AdventureWorksContext>()
            .UseInMemoryDatabase(databaseName)
            .Options;

        return new InMemoryAdventureWorksContext(options);
    }

    private sealed class InMemoryAdventureWorksContext(DbContextOptions<AdventureWorksContext> options)
        : AdventureWorksContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Intentionally empty: tests provide InMemory provider through options.
        }
    }
}
