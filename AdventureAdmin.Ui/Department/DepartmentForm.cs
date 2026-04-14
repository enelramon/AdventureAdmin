using AdventureAdmin.Ui.Services;

namespace AdventureAdmin.Ui
{
    public partial class DepartmentForm : Form
    {
        private readonly DepartmentService _service;
        private Data.Models.Department? _entidad;

        public DepartmentForm(DepartmentService service) : this(service, null)
        {
        }

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
            if (_entidad == null)
            {
                _entidad = new Data.Models.Department();
            }
            else
            {
                bool huboCambios = _entidad.Name != txtName.Text || _entidad.GroupName != txtGroupName.Text;

                if (!huboCambios)
                {
                    this.Close();
                    return;
                }
            }

            _entidad.Name = txtName.Text;
            _entidad.GroupName = txtGroupName.Text;

            if (!ValidateForm()) return;

            try
            {
                btnGuardar.Enabled = false;

                bool seGuardo = await _service.Guardar(_entidad);

                if (seGuardo)
                {
                    string mensaje = (_entidad.DepartmentId == 0)
                        ? "Departamento creado correctamente."
                        : "Departamento actualizado correctamente.";

                    MessageBox.Show(mensaje, "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.Close();
                }
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}
