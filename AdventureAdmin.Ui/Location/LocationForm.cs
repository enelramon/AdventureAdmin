using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdmin.Ui.Location
{
    public partial class LocationForm : Form
    {
        private readonly LocationService _service;
        private readonly ErrorProvider _errorProvider;
        private readonly Data.Models.Location? _entidad;

         public LocationForm(LocationService service) : this (service, null) { }
         
         public LocationForm(LocationService service, Data.Models.Location? entidad)
        {
            InitializeComponent();
            _service = service;
            _entidad = entidad;
            _errorProvider = new ErrorProvider();

            if (_entidad != null)
                CargarDatos(_entidad);
        }
        
        private void CargarDatos(Data.Models.Location e)
        {
            txtName.Text = e.Name;
            nudCostRate.Value = e.CostRate;
            nudAvailability.Value = e.Availability;
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
                if (_entidad == null)
                    await Insertar();
                else
                    await Actualizar();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la localización: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Insertar()
        {
            var location = new Data.Models.Location
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
            if (_entidad == null) return;

            var entidadBD = await _service.Buscar(_entidad.LocationId);

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
