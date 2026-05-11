using AdventureAdmin.Ui.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.Person;

public partial class PersonList : Form
{
    private readonly PersonService _personService;

    private bool _cargando = false;

    public PersonList(PersonService personService)
    {
        InitializeComponent();
        _personService = personService;
    }

    private async void PersonList_Load(object sender, EventArgs e)
    {
        await CargarPersonasAsync();
    }

    private async Task CargarPersonasAsync()
    {
        if (_cargando)
            return;

        try
        {
            _cargando = true;

            btnNuevoRegistro.Enabled = false;
            ModificarRegistro.Enabled = false;

            dataGridView2.DataSource = null;

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
            MessageBox.Show(
                $"Error al cargar datos: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            _cargando = false;

            btnNuevoRegistro.Enabled = true;
            ModificarRegistro.Enabled = true;
        }
    }

    private void OcultarColumnasNavegacion()
    {
        string[] ocultar =
        {
            "BusinessEntity",
            "BusinessEntityContacts",
            "Customers",
            "EmailAddresses",
            "Employee",
            "Password",
            "PersonCreditCards",
            "PersonPhones",
            "NameStyle",
            "AdditionalContactInfo",
            "Demographics",
            "Rowguid"
        };

        foreach (var nombre in ocultar)
        {
            if (dataGridView2.Columns.Contains(nombre))
                dataGridView2.Columns[nombre].Visible = false;
        }
    }

    private async void btnNuevoRegistro_Click(object sender, EventArgs e)
    {
        using var form =
            Program.ServiceProvider.GetRequiredService<PersonForm>();

        if (form.ShowDialog(this) == DialogResult.OK)
            await CargarPersonasAsync();
    }

    private async void ModificarRegistro_Click(object sender, EventArgs e)
    {
        if (dataGridView2.CurrentRow?.DataBoundItem
            is not Data.Models.Person persona)
            return;

        using var form =
            ActivatorUtilities.CreateInstance<PersonForm>(
                Program.ServiceProvider,
                persona);

        if (form.ShowDialog(this) == DialogResult.OK)
            await CargarPersonasAsync();
    }
}