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
        private async void LocationList_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
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

        private async void nuevoButton_Click(object sender, EventArgs e)
        {
            var locationForm = Program.ServiceProvider.GetRequiredService<LocationForm>();
            locationForm.ShowDialog();
            await LoadDataAsync();
        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            var entidad = dataGridViewLocation.CurrentRow?.DataBoundItem as AdventureAdmin.Data.Models.Location;

            if (entidad == null)
            {
                MessageBox.Show("Por favor seleccione un registro para modificar.");
                return;
            }

            var form = ActivatorUtilities.
                CreateInstance<LocationForm>(
                Program.ServiceProvider, entidad);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await LoadDataAsync();
            }

        }
    }
}
