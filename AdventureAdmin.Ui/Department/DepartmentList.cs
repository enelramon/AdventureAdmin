using AdventureAdmin.Ui.Services;
using Microsoft.Extensions.DependencyInjection;
using DepartmentModel = AdventureAdmin.Data.Models.Department;

namespace AdventureAdmin.Ui.Department
{
    public partial class DepartmentList : Form
    {
        private readonly DepartmentService _service;

        public DepartmentList(DepartmentService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<DepartmentForm>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }
        }

        private void DepartmentList_Load(object sender, EventArgs e)
        {
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var departamentos = await _service.GetList(d => true);
                dataGridView1.DataSource = departamentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para modificar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entidad = (DepartmentModel)dataGridView1.CurrentRow.DataBoundItem;

            var form = ActivatorUtilities.CreateInstance<DepartmentForm>(
                Program.ServiceProvider, entidad);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entidad = (DepartmentModel)dataGridView1.CurrentRow.DataBoundItem;

            var result = MessageBox.Show(
                $"¿Desea eliminar el departamento '{entidad.Name}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _ = EliminarAsync(entidad.DepartmentId);
            }

        }

        private async Task EliminarAsync(int id)
        {
            try
            {
                var success = await _service.Eliminar(id);

                if (success)
                {
                    MessageBox.Show("Departamento eliminado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el departamento.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
