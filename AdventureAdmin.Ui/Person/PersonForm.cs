using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdmin.Ui.Person;

public partial class PersonForm : Form
{
    private readonly AdventureWorksContext _context;
    private readonly AdventureAdmin.Data.Models.Person? _person;

    private static readonly string[] PersonTypeCodes =
        { "SC", "IN", "SP", "EM", "VC", "GC" };

    public PersonForm(AdventureWorksContext context) : this(context, null) { }

    public PersonForm(AdventureWorksContext context,
                      AdventureAdmin.Data.Models.Person? person)
    {
        InitializeComponent();
        _context = context;
        _person = person;

        cmbPersonType.SelectedIndex = 0;
        cmbEmailPromotion.SelectedIndex = 0;

        if (_person != null)
            CargarDatos(_person);
    }

    private void CargarDatos(AdventureAdmin.Data.Models.Person p)
    {
        int idx = Array.IndexOf(PersonTypeCodes, p.PersonType?.ToUpper());
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
                Actualizar();

            await _context.SaveChangesAsync();

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
        var entity = new BusinessEntity
        {
            Rowguid = Guid.NewGuid(),
            ModifiedDate = DateTime.Now
        };
        _context.BusinessEntities.Add(entity);
        await _context.SaveChangesAsync();

        var p = new AdventureAdmin.Data.Models.Person
        {
            BusinessEntityId = entity.BusinessEntityId,
            Rowguid = Guid.NewGuid(),
            ModifiedDate = DateTime.Now
        };
        AplicarCampos(p);
        _context.People.Add(p);
    }

    private void Actualizar()
    {
        var p = _context.People.Find(_person!.BusinessEntityId);
        if (p == null) return;

        AplicarCampos(p);
        p.ModifiedDate = DateTime.Now;
    }

    private void AplicarCampos(AdventureAdmin.Data.Models.Person p)
    {
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
