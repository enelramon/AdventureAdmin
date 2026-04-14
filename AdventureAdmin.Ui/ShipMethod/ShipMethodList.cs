using AdventureAdmin.Ui.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.ShipMethod
{
    public partial class ShipMethodList : Form
    {
        private readonly ShipMethodService _service;
        public ShipMethodList(ShipMethodService service)
        {
            InitializeComponent();
            _service = service;
        }

        private async void ShipMethodList_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var shipMethods = await _service.GetList(c => true);
                ShipMethodDataView.DataSource = shipMethods;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private async void nuevoButton_Click(object sender, EventArgs e)
        {
            var shipMethodForm = Program.ServiceProvider.GetRequiredService<ShipMethodForm>();
            shipMethodForm.ShowDialog();
            await LoadDataAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (ShipMethodDataView.SelectedRows.Count > 0)
            {
                int id = ShipMethodDataView.SelectedRows[0].Cells[0].Value is int value ? value : 0;
                var shipMethodForm = Program.ServiceProvider.GetRequiredService<ShipMethodForm>();
                shipMethodForm.Buscar(id);
                shipMethodForm.ShowDialog();
            }
           
        }
    }
}
