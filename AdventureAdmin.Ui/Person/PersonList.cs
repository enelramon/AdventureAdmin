using AdventureAdmin.Ui.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.Person;

public partial class PersonList : Form
{
    private readonly PersonService _personService;

    public PersonList(PersonService personService)
    {
        InitializeComponent();
        _personService = personService;
    }

    private void PersonList_Load(object sender, EventArgs e)
    {
        _ = CargarPersonasAsync();
    }

    private async Task CargarPersonasAsync()
    {
        try
        {
            var personas = await _personService.GetList(p => true);

            var ordenadas = personas
                .OrderBy(p => p.BusinessEntityId)
                .ThenBy(p => p.FirstName)
                .ToList();

            dataGridView2.DataSource = ordenadas;
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
            "PersonCreditCards", "PersonPhones", "NameStyle",
            "AdditionalContactInfo", "Demographics", "Rowguid"
        };

        foreach (var nombre in ocultar)
        {
            if (dataGridView2.Columns.Contains(nombre))
                dataGridView2.Columns[nombre].Visible = false;
        }
    }

    private void btnNuevoRegistro_Click(object sender, EventArgs e)
    {
        var form = Program.ServiceProvider.GetRequiredService<PersonForm>();
        if (form.ShowDialog(this) == DialogResult.OK)
            _ = CargarPersonasAsync();
    }

    private void ModificarRegistro_Click(object sender, EventArgs e)
    {
        if (dataGridView2.CurrentRow?.DataBoundItem is not Data.Models.Person persona)
            return;

        var form = ActivatorUtilities.CreateInstance<PersonForm>(
            Program.ServiceProvider, persona);

        if (form.ShowDialog(this) == DialogResult.OK)
            _ = CargarPersonasAsync();
    }
}