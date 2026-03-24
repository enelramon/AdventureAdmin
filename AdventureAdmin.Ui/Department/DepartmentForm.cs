using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdmin.Ui
{
    public partial class DepartmentForm : Form
    {
        private readonly AdventureWorksContext _context;

        public DepartmentForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtGroupName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                btnGuardar.Enabled = false;

                var department = new AdventureAdmin.Data.Models.Department
                {
                    Name = txtName.Text.Trim(),
                    GroupName = txtGroupName.Text.Trim(),
                    ModifiedDate = DateTime.Now
                };

                _context.Departments.Add(department);
                await _context.SaveChangesAsync();

                MessageBox.Show("Departamento creado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
            }

        }
        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "El nombre del departamento es obligatorio.");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtGroupName.Text))
            {
                errorProvider1.SetError(txtGroupName, "El nombre del grupo es obligatorio.");
                valid = false;
            }

            return valid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // alerta de que se canceló la operación
            this.Close();
        }
    }
}
