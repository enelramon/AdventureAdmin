using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.Services;


namespace AdventureAdmin.Ui.Location
{
    public partial class LocationForm : Form
    {
        private readonly ErrorProvider _errorProvider;
        private readonly AdventureAdmin.Data.Models.Location? _location;
        private readonly LocationService _service;

        public LocationForm(LocationService service) : this 
            (service, null)
        {
        }
        public LocationForm(LocationService service, AdventureAdmin.Data.Models.Location? location)
        {
            InitializeComponent();
            _service = service;
            _location = location;
            _errorProvider = new ErrorProvider();

            if (_location != null)
                CargarDatos(_location);
        }
        
        private void CargarDatos(AdventureAdmin.Data.Models.Location location)
        {
            txtName.Text = location.Name;
            nudCostRate.Value = location.CostRate;
            nudAvailability.Value = location.Availability;
        }

        private async Task Insertar()
        {
            var location = new AdventureAdmin.Data.Models.Location
            {
                Name = txtName.Text.Trim(),
                CostRate = nudCostRate.Value,
                Availability = nudAvailability.Value,
                ModifiedDate = DateTime.Now
            };

            var exito = await _service.Guardar(location);

            if (exito)
            {
                MessageBox.Show("Localización guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo guardar la localización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Actualizar()
        {
            if (_location == null) return;

            var entidadBD = await _service.Buscar(_location.LocationId);

            if (entidadBD == null)
            {
                MessageBox.Show("El registro ya no existe en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            entidadBD.Name = txtName.Text.Trim();
            entidadBD.CostRate = nudCostRate.Value;
            entidadBD.Availability = nudAvailability.Value;
            entidadBD.ModifiedDate = DateTime.Now;

            var exito = await _service.Modificar(entidadBD);

            if (exito)
            {
                MessageBox.Show("Localización actualizada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar la localización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                _errorProvider.SetError(txtName, "El nombre no puede estar vacío.");
                return;
            }

            try
            {
                if (_location == null)
                    await Insertar();
                else
                    await Actualizar();

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la localización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
