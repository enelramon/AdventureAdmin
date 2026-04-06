using AdventureAdmin.Data.Context;
using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.ProductCategory
{
    public partial class ProductCategoryList : Form
    {
        private readonly ProductCategoryService _productCategoryService;

        public ProductCategoryList(ProductCategoryService productCategoryService)
        {
            InitializeComponent();
            _productCategoryService = productCategoryService;
        }

        private void ProductCategoryList_Load(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private async Task RefrescarDatos()
        {
            try
            {
                var categorias = await _productCategoryService.GetList(c => true);
                dgvCategorias.DataSource = categorias;

                if (dgvCategorias.Columns["ProductSubcategories"] != null) dgvCategorias.Columns["ProductSubcategories"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private async void nuevoButton_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<ProductCategoryForm>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                await RefrescarDatos();
            }
        }

        private async void refrescarButton_Click(object sender, EventArgs e)
        {
            await RefrescarDatos();
        }
    }
}
