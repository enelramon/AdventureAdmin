using AdventureAdmin.Data.Context;
using AdventureAdmin.Ui.Person;
using AdventureAdmin.Ui.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace AdventureAdmin;

static class Program
{
    public static ServiceProvider ServiceProvider { get; private set; }
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var services = new ServiceCollection();
        ConfigureServices(services);

        ServiceProvider = services.BuildServiceProvider();
        Application.Run(ServiceProvider.GetRequiredService<MainForm>());
    }

    private static void ConfigureServices(ServiceCollection services)
    {
        var connectionString = ConfigurationManager
            .ConnectionStrings["AdventureWorks"].ConnectionString;

        services.AddDbContext<AdventureWorksContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddTransient<MainForm>();
        services.AddTransient<ProductList>();
        services.AddTransient<ProductForm>();
        services.AddTransient<PersonList>();
        services.AddTransient<PersonForm>();
    }
}
