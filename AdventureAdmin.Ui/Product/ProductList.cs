using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.Product;

public partial class ProductList : Form
{
    private readonly AdventureWorksContext _context;
    public ProductList(AdventureWorksContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private void ProductList_Load(object sender, EventArgs e)
    {
        LoadDataAsync();
    }
    private async Task LoadDataAsync()
    {
        try
        {
            var productos = await _context.Products.ToListAsync();
            productsDataGridView.DataSource = productos;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar datos: {ex.Message}");
        }
    }

    private void nuevoButton_Click(object sender, EventArgs e)
    {
        var productForm = Program.ServiceProvider.GetRequiredService<ProductForm>();
        productForm.ShowDialog();
    }

    private void productsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }
}
