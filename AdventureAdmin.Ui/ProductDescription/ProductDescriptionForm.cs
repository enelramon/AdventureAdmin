using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdmin.Ui.Product;

public partial class ProductDescriptionForm : Form
{
    private readonly AdventureWorksContext _context;

    public ProductDescriptionForm(AdventureWorksContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private void ProductDescriptionForm_Load(object sender, EventArgs e)
    {

    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateForm()) return;

        try
        {
            btnSave.Enabled = false;

            var productDescription = new ProductDescription
            {
                Description = txtDescription.Text.Trim(),
                Rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };

            _context.ProductDescriptions.Add(productDescription);
            await _context.SaveChangesAsync();

            MessageBox.Show("Descripción de producto creada correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSave.Enabled = true;
        }
    }

    private bool ValidateForm()
    {
        errorProvider.Clear();
        bool valid = true;

        if (string.IsNullOrWhiteSpace(txtDescription.Text))
        {
            errorProvider.SetError(txtDescription, "La descripción es obligatoria.");
            valid = false;
        }

        if (txtDescription.Text.Length > 400)
        {
            errorProvider.SetError(txtDescription, "La descripción no puede exceder los 400 caracteres.");
            valid = false;
        }

        return valid;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}