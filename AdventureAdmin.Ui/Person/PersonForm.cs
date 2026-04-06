using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.Person;

public partial class PersonForm : Form
{
    private readonly PersonService _service;
    private readonly AdventureAdmin.Data.Models.Person? _person;

    private static readonly string[] PersonTypeCodes =
        { "SC", "IN", "SP", "EM", "VC", "GC" };

    public PersonForm(PersonService service) : this(service, null) { }

    public PersonForm(PersonService service,
                      AdventureAdmin.Data.Models.Person? person)
    {
        InitializeComponent();
        _service = service;
        _person = person;

        cmbPersonType.SelectedIndex = 0;
        cmbEmailPromotion.SelectedIndex = 0;

        if (_person != null)
            CargarDatos(_person);
    }

    private void CargarDatos(AdventureAdmin.Data.Models.Person p)
    {
        int idx = Array.FindIndex(
            PersonTypeCodes,
            code => string.Equals(code, p.PersonType?.Trim(), StringComparison.OrdinalIgnoreCase));

        cmbPersonType.SelectedIndex = idx >= 0 ? idx : 0;

        txtTitle.Text = p.Title ?? string.Empty;
        txtFirstName.Text = p.FirstName ?? string.Empty;
        txtMiddleName.Text = p.MiddleName ?? string.Empty;
        txtLastName.Text = p.LastName ?? string.Empty;
        txtSuffix.Text = p.Suffix ?? string.Empty;

        chkNameStyle.Checked = p.NameStyle;

        int epIdx = p.EmailPromotion is >= 0 and <= 2 ? p.EmailPromotion : 0;
        cmbEmailPromotion.SelectedIndex = epIdx;

        this.Text = $"Editar Persona – {p.FirstName} {p.LastName}";
    }

    private bool ValidarFormulario()
    {
        errorProvider1.Clear();
        bool ok = true;

        if (cmbPersonType.SelectedIndex < 0)
        {
            errorProvider1.SetError(cmbPersonType, "Seleccione un tipo de persona.");
            ok = false;
        }
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            errorProvider1.SetError(txtFirstName, "El nombre es obligatorio.");
            ok = false;
        }
        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            errorProvider1.SetError(txtLastName, "El apellido es obligatorio.");
            ok = false;
        }
        if (cmbEmailPromotion.SelectedIndex < 0)
        {
            errorProvider1.SetError(cmbEmailPromotion, "Seleccione una opción.");
            ok = false;
        }

        return ok;
    }

    private async void btnGuardar_Click(object sender, EventArgs e)
    {
        if (!ValidarFormulario()) return;

        try
        {
            btnGuardar.Enabled = false;

            if (_person == null)
                await Insertar();
            else
                await Actualizar();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Error al guardar:\n{ex.InnerException?.Message ?? ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnGuardar.Enabled = true;
        }
    }

    private async Task Insertar()
    {
        var businessEntityId = await _service.CrearBusinessEntity();

        var p = new Data.Models.Person
        {
            BusinessEntityId = businessEntityId,
            Rowguid = Guid.NewGuid(),
            ModifiedDate = DateTime.Now
        };

        AplicarCampos(p);
        await _service.Guardar(p);
    }

    private async Task Actualizar()
    {
        var p = await _service.Buscar(_person!.BusinessEntityId);

        if (p == null) return;

        AplicarCampos(p);
        p.ModifiedDate = DateTime.Now;

        await _service.Actualizar(p);
    }

    private void AplicarCampos(AdventureAdmin.Data.Models.Person p)
    {
        if (cmbPersonType.SelectedIndex < 0 || cmbPersonType.SelectedIndex >= PersonTypeCodes.Length)
            throw new InvalidOperationException("Tipo de persona inválido.");

        p.PersonType = PersonTypeCodes[cmbPersonType.SelectedIndex];
        p.Title = NullIfEmpty(txtTitle.Text);
        p.FirstName = txtFirstName.Text.Trim();
        p.MiddleName = NullIfEmpty(txtMiddleName.Text);
        p.LastName = txtLastName.Text.Trim();
        p.Suffix = NullIfEmpty(txtSuffix.Text);
        p.NameStyle = chkNameStyle.Checked;
        p.EmailPromotion = cmbEmailPromotion.SelectedIndex;
    }

    private static string? NullIfEmpty(string value) =>
        string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}

