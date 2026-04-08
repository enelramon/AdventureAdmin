using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.Product;

public partial class ProductDescriptionList : Form
{
    private readonly AdventureWorksContext _context;

    public ProductDescriptionList(AdventureWorksContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private async void ProductDescriptionList_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var descripciones = await _context.ProductDescriptions.ToListAsync();
            productDescriptionDataGridView.DataSource = descripciones;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar datos: {ex.Message}");
        }
    }

    private async void nuevoButton_Click(object sender, EventArgs e)
    {
        var productDescriptionForm = Program.ServiceProvider.GetRequiredService<ProductDescriptionForm>();
        productDescriptionForm.ShowDialog();

        // Recargar datos después de cerrar el formulario de nuevo
        await LoadDataAsync();
    }

    private async void refrescarButton_Click(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }
}