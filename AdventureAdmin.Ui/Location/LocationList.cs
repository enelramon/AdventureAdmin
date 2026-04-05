using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;




namespace AdventureAdmin.Ui.Location
{
    public partial class LocationList : Form
    {
        private readonly AdventureWorksContext _context;
        public LocationList(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }
        private void LocationList_Load(object sender, EventArgs e)
        {
            LoadDataAsync();
        }
        private async Task LoadDataAsync()
        {
            try
            {
                var locations = await _context.Locations.ToListAsync();
                dataGridViewLocation.DataSource = locations;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void nuevoButton_Click(object sender, EventArgs e)
        {
            var locationForm = Program.ServiceProvider.GetRequiredService<LocationForm>();
            locationForm.ShowDialog();
            LoadDataAsync();
        }

        private void modificarButton_Click(object sender, EventArgs e)
        {
           
        }
    }
}
