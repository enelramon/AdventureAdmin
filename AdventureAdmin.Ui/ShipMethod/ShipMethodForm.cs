using AdventureAdmin.Ui.Services;

namespace AdventureAdmin.Ui.ShipMethod
{
    public partial class ShipMethodForm : Form
    {
        private ShipMethodService _service;
        public ShipMethodForm(ShipMethodService service)
        {
            InitializeComponent();
            _service = service;
        }

        public async void Buscar(int? id)
        {
            if (id != null)
            {
                var shipMethod = await _service.Buscar(id.Value);

                if (shipMethod is null) return;

                IdText.Text = shipMethod.ShipMethodId.ToString();
                txtName.Text = shipMethod.Name;
                numShipBase.Value = shipMethod.ShipBase;
                numShipRate.Value = shipMethod.ShipRate;
            }
        }


        private bool validateForm()
        {
            errorProvider.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "El nombre es obligatorio.");
                valid = false;
            }

            if (numShipBase.Value <= 0)
            {
                errorProvider.SetError(numShipBase, "El monto base de envio debe ser mayor a 0.");
                valid = false;
            }

            if (numShipRate.Value <= 0)
            {
                errorProvider.SetError(numShipRate, "La tariga de envio debe ser mayor a 0.");
                valid = false;
            }

            return valid;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!validateForm()) return;

            try
            {
                btnSave.Enabled = false;

                var ShipMethod = new Data.Models.ShipMethod
                {
                    ShipMethodId = int.TryParse(IdText.Text, out int id) ? id : 0,
                    Name = txtName.Text.Trim(),
                    ShipBase = numShipBase.Value,
                    ShipRate = numShipRate.Value,
                    ModifiedDate = DateTime.Now
                };

                bool paso = await _service.Guardar(ShipMethod);

                if (paso)
                {
                    MessageBox.Show("Metoto de envio creado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo crear el metodo de envio.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
