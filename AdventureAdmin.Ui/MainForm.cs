using AdventureAdmin.Ui.Department;
using AdventureAdmin.Ui.CreditCard;
using AdventureAdmin.Ui.Location;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.ContactType;
using AdventureAdmin.Ui.Product;
using AdventureAdmin.Ui.ShipMethod;
using AdventureAdmin.Ui.ProductCategory;
using Microsoft.Extensions.DependencyInjection;
using AdventureAdmin.Ui.Culture;
using AdventureAdmin.Ui.Business_Entity;

namespace AdventureAdmin;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void productosToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var productList = Program.ServiceProvider.GetRequiredService<ProductList>();
        productList.Show();
    }

    private void currencyToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = Program.ServiceProvider.GetRequiredService<DepartmentList>();
        form.Show();
    }

    private void shiftToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void countryRegionToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void shipMethodToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var shipMethodList = Program.ServiceProvider.GetRequiredService<ShipMethodList>();
        shipMethodList.Show();
    }

    private void phoneNumberTypeToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void productDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var productDescriptionList = Program.ServiceProvider.GetRequiredService<ProductDescriptionList>();
        productDescriptionList.Show();
    }

    private void addressTypeToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void businessEntityToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var businessEntityList = Program.ServiceProvider.GetRequiredService<BusinessEntityList>();
        businessEntityList.Show();
    }

    private void locationToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var locationList = Program.ServiceProvider.GetRequiredService<LocationList>();
        locationList.Show();
    }

    private void specialOfferToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void productCategoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = Program.ServiceProvider.GetRequiredService<ProductCategoryList>();
        form.MdiParent = this;
        form.Show();
    }

    private void cultureToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var Culture = Program.ServiceProvider.GetRequiredService<CultureList>();
        Culture.Show();
    }

    private void personToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var personList = Program.ServiceProvider.GetRequiredService<AdventureAdmin.Ui.Person.PersonList>();
        personList.Show();
    }

    private void creditCardToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var form = Program.ServiceProvider.GetRequiredService<CreditCardList>();

        form.MdiParent = this;

        form.Show();
    }

    private void contactTypeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        /*
         * var productList = Program.ServiceProvider.GetRequiredService<ProductList>();
        productList.Show();
         */

        var contactTypeList = Program.ServiceProvider.GetRequiredService<ContactTypeList>();
        contactTypeList.Show();
    }

    private void scrapReasonToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void MainForm_Load(object sender, EventArgs e)
    {

    }

    private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }
}
// cree la rama creditcard
