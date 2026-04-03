using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.ScrapReason;

public partial class ScrapReasonList : Form
{
    private readonly AdventureWorksContext _context;

    public ScrapReasonList(AdventureWorksContext context)
    {
        InitializeComponent();
        _context = context;
    }

    private void ScrapReasonList_Load(object sender, EventArgs e)
    {
        _ = LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var scrapReasons = await _context.ScrapReasons.ToListAsync();
            scrapReasonsDataGridView.DataSource = scrapReasons;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar datos: {ex.Message}");
        }
    }

    private void nuevoButton_Click(object sender, EventArgs e)
    {
        var scrapReasonForm = Program.ServiceProvider.GetRequiredService<ScrapReasonForm>();
        scrapReasonForm.ShowDialog();
        _ = LoadDataAsync();
    }
}
