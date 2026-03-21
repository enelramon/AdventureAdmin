using AdventureAdmin.Data.Context;
using AdventureAdmin.Ui.CreditCard;
using AdventureAdmin.Ui.Location;
using AdventureAdmin.Ui.Product;
using AdventureAdmin.Ui.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using AdventureAdmin.Ui;

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
            options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure();
            }));

        services.AddTransient<MainForm>();
        services.AddTransient<ProductList>();
        services.AddTransient<ProductForm>();
        services.AddTransient<CreditCardList>();
        services.AddTransient<CreditCardForm>();
        services.AddTransient<LocationList>();
        services.AddTransient<LocationForm>();
        services.AddTransient<DepartmentList>();
        services.AddTransient<DepartmentForm>();
        services.AddTransient<ProductDescriptionList>();
        services.AddTransient<ProductDescriptionForm>();
    }
}

