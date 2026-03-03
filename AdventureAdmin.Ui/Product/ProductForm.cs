using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdmin.Ui.Product;

public partial class ProductForm : Form
{
    private readonly AdventureWorksContext _context;

    public ProductForm(AdventureWorksContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private void ProductForm_Load(object sender, EventArgs e)
    {
        _ = LoadComboBoxesAsync();
    }

    private async Task LoadComboBoxesAsync()
    {
        try
        {
            var categories = await _context.ProductCategories.ToListAsync();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "ProductCategoryId";
            cmbCategory.SelectedIndex = -1;

            var models = await _context.ProductModels.ToListAsync();
            cmbModel.DataSource = models;
            cmbModel.DisplayMember = "Name";
            cmbModel.ValueMember = "ProductModelId";
            cmbModel.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar datos: {ex.Message}");
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateForm()) return;

        try
        {
            btnSave.Enabled = false;

            var product = new Data.Models.Product
            {
                Name = txtName.Text.Trim(),
                ProductNumber = txtProductNumber.Text.Trim(),
                Color = string.IsNullOrWhiteSpace(txtColor.Text) ? null : txtColor.Text.Trim(),
                StandardCost = numStandardCost.Value,
                ListPrice = numListPrice.Value,
                Size = string.IsNullOrWhiteSpace(txtSize.Text) ? null : txtSize.Text.Trim(),
                Weight = string.IsNullOrWhiteSpace(txtWeight.Text) ? null : decimal.Parse(txtWeight.Text),
                ProductCategoryId = cmbCategory.SelectedIndex == -1 ? null : (int?)cmbCategory.SelectedValue,
                ProductModelId = cmbModel.SelectedIndex == -1 ? null : (int?)cmbModel.SelectedValue,
                SellStartDate = dtpSellStart.Value,
                SellEndDate = chkSellEnd.Checked ? dtpSellEnd.Value : null,
                DiscontinuedDate = chkDiscontinued.Checked ? dtpDiscontinued.Value : null,
                Rowguid = Guid.NewGuid(),
                ModifiedDate = DateTime.Now
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            MessageBox.Show("Producto creado correctamente.", "Éxito",
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

        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            errorProvider.SetError(txtName, "El nombre es obligatorio.");
            valid = false;
        }

        if (string.IsNullOrWhiteSpace(txtProductNumber.Text))
        {
            errorProvider.SetError(txtProductNumber, "El número de producto es obligatorio.");
            valid = false;
        }

        if (numStandardCost.Value <= 0)
        {
            errorProvider.SetError(numStandardCost, "El costo estándar debe ser mayor a 0.");
            valid = false;
        }

        if (numListPrice.Value <= 0)
        {
            errorProvider.SetError(numListPrice, "El precio de lista debe ser mayor a 0.");
            valid = false;
        }

        if (!string.IsNullOrWhiteSpace(txtWeight.Text) &&
            !decimal.TryParse(txtWeight.Text, out _))
        {
            errorProvider.SetError(txtWeight, "El peso debe ser un número válido.");
            valid = false;
        }

        return valid;
    }

    private void btnCancel_Click(object sender, EventArgs e) => this.Close();

    private void chkSellEnd_CheckedChanged(object sender, EventArgs e)
        => dtpSellEnd.Enabled = chkSellEnd.Checked;

    private void chkDiscontinued_CheckedChanged(object sender, EventArgs e)
        => dtpDiscontinued.Enabled = chkDiscontinued.Checked;
}