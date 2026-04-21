using AdventureAdmin.Data.Context;
using AdventureAdmin.Ui;
using AdventureAdmin.Ui.CreditCard;
using AdventureAdmin.Ui.Department;
using AdventureAdmin.Ui.Location;
using AdventureAdmin.Ui.ContactType;
using AdventureAdmin.Ui.Person;
using AdventureAdmin.Ui.Product;
using AdventureAdmin.Ui.ShipMethod;
using AdventureAdmin.Ui.ProductCategory;
using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Aplicada1.Core;
using AdventureAdmin.Ui.Culture;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.Business_Entity;


namespace AdventureAdmin;

static class Program
{

// Para probar el commit
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
        services.AddTransient<ShipMethodList>();
        services.AddTransient<ShipMethodForm>();
        services.AddTransient<CreditCardList>();
        services.AddTransient<CreditCardForm>();
        services.AddTransient<LocationList>();
        services.AddTransient<LocationForm>();
        services.AddTransient<ContactTypeList>();
        services.AddTransient<ContactTypeForm>();
        services.AddTransient<DepartmentList>();
        services.AddTransient<DepartmentForm>();
        services.AddTransient<ProductDescriptionList>();
        services.AddTransient<ProductDescriptionForm>();
        services.AddTransient<PersonList>();
        services.AddTransient<PersonForm>();
        services.AddTransient<ProductCategoryList>();
        services.AddTransient<ProductCategoryForm>();
        services.AddTransient<CultureForm>();
        services.AddTransient<CultureList>();
        services.AddTransient<BusinessEntityForm>();
        services.AddTransient<BusinessEntityList>();



        //Services 
        services.AddTransient<CreditCardService>();
        services.AddTransient<ShipMethodService>();
        services.AddTransient<PersonService>();
        services.AddTransient<DepartmentService>();
        services.AddTransient<CultureService>();
        services.AddTransient<LocationService>();
        services.AddTransient<BusinessEntityService>();

    }
}
