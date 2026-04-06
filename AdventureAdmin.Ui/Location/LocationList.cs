using AdventureAdmin.Data.Context;
using System.Threading.Tasks;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




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
        private async  void LocationList_Load(object sender, EventArgs e)
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

        private  async void nuevoButton_Click(object sender, EventArgs e)
        {
            var locationForm = Program.ServiceProvider.GetRequiredService<LocationForm>();
            locationForm.ShowDialog();
            await LoadDataAsync();
        }
        
        }
    }
