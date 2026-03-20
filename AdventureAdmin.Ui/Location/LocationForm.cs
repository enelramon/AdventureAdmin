using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;

namespace AdventureAdmin.Ui.Location
{
    public partial class LocationForm : Form
    {
        private readonly AdventureWorksContext _context;
        private readonly ErrorProvider _errorProvider;

        public LocationForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
            _errorProvider = new ErrorProvider();
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
                var location = new AdventureAdmin.Data.Models.Location
                {
                    Name = txtName.Text.Trim(),
                    CostRate = nudCostRate.Value,
                    Availability = nudAvailability.Value,
                    ModifiedDate = DateTime.Now
                };

                _context.Locations.Add(location);
                await _context.SaveChangesAsync();
                
                MessageBox.Show("Localización guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
