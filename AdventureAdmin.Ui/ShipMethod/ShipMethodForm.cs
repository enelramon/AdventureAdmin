using AdventureAdmin.Data.Context;

namespace AdventureAdmin.Ui.ShipMethod
{
    public partial class ShipMethodForm : Form
    {
        private readonly AdventureWorksContext _context;
        public ShipMethodForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void ShipMethodForm_Load(object sender, EventArgs e)
        {

        }

        private bool validteForm()
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
            if (!validteForm()) return;

            try
            {
                btnSave.Enabled = false;

                var ShipMethod = new Data.Models.ShipMethod
                {
                    Name = txtName.Text.Trim(),
                    ShipBase = numShipBase.Value,
                    ShipRate = numShipRate.Value,
                    ModifiedDate = DateTime.Now
                };

                _context.ShipMethods.Add(ShipMethod);
                await _context.SaveChangesAsync();

                MessageBox.Show("Metoto de envio creado correctamente.", "Éxito",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

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
