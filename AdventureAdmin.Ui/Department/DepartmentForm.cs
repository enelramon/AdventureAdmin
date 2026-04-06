using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureAdmin.Ui
{
    public partial class DepartmentForm : Form
    {
        private readonly DepartmentService _service;
        private readonly Data.Models.Department? _entidad;

        // Constructor para crear nuevo
        public DepartmentForm(DepartmentService service) : this(service, null)
        {
        }

        // Constructor para editar
        public DepartmentForm(DepartmentService service, Data.Models.Department? entidad)
        {
            InitializeComponent();
            _service = service;
            _entidad = entidad;

            if (_entidad != null)
                CargarDatos(_entidad);
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            btnGuardar.Text = _entidad == null ? "Crear" : "Actualizar";
        }

        private void CargarDatos(Data.Models.Department entidad)
        {
            txtName.Text = entidad.Name;
            txtGroupName.Text = entidad.GroupName;
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

                if (_entidad == null)
                    await Insertar();
                else
                    await Actualizar();

                MessageBox.Show(
                    _entidad == null ? "Departamento creado correctamente." : "Departamento actualizado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private async Task Insertar()
        {
            var department = new Data.Models.Department
            {
                Name = txtName.Text.Trim(),
                GroupName = txtGroupName.Text.Trim(),
                ModifiedDate = DateTime.Now
            };

            await _service.Guardar(department);
        }

        private async Task Actualizar()
        {
            var department = await _service.Buscar(_entidad!.DepartmentId);

            if (department == null)
            {
                MessageBox.Show("El registro no existe.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            department.Name = txtName.Text.Trim();
            department.GroupName = txtGroupName.Text.Trim();
            department.ModifiedDate = DateTime.Now;

            await _service.Actualizar(department);
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
