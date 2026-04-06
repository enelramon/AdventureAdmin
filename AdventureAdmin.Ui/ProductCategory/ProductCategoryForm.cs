using System;
using System.Windows.Forms;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.Services;

namespace AdventureAdmin.Ui.ProductCategory
{
    public partial class ProductCategoryForm : Form
    {
        private readonly ProductCategoryService _productCategoryService;

        public ProductCategoryForm(ProductCategoryService productCategoryService)
        {
            InitializeComponent();
            _productCategoryService = productCategoryService;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "El nombre es obligatorio.");
                return;
            }

            try
            {
                var nuevaCategoria = new Data.Models.ProductCategory
                {
                    Name = txtName.Text,
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };

                var paso = await _productCategoryService.Guardar(nuevaCategoria);

                if (!paso)
                {
                    MessageBox.Show("Error al guardar la categoría", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Categoría guardada correctamente", "Éxito", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpModifiedDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
