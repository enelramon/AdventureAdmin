using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace AdventureAdmin.Ui.Person;
public partial class PersonList : Form
{
    private readonly AdventureWorksContext _context;
    public PersonList(AdventureWorksContext context)
    {
        InitializeComponent();
        _context = context;
    }
    private void PersonList_Load(object sender, EventArgs e)
    {
        _ = CargarPersonasAsync();
    }
    private async Task CargarPersonasAsync()
    {
        try
        {
            var personas = await _context.People
                .OrderBy(p => p.BusinessEntity)
                .ThenBy(p => p.FirstName)
                .ToListAsync();
            dataGridView2.DataSource = personas;
            OcultarColumnasNavegacion();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar datos: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    private void OcultarColumnasNavegacion()
    {
        string[] ocultar =
        {
            "BusinessEntity", "BusinessEntityContacts", "Customers",
            "EmailAddresses", "Employee", "Password",
            "PersonCreditCards", "PersonPhones", "NameStyle", "AdditionalContactInfo", "Demographics", "Rowguid"
        };
        foreach (var nombre in ocultar)
            if (dataGridView2.Columns.Contains(nombre))
                dataGridView2.Columns[nombre].Visible = false;
    }
    private void btnNuevoRegistro_Click(object sender, EventArgs e)
    {
        var form = Program.ServiceProvider.GetRequiredService<PersonForm>();
        if (form.ShowDialog(this) == DialogResult.OK)
            _ = CargarPersonasAsync();
    }
}