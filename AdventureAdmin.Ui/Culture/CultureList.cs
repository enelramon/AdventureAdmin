using AdventureAdmin.Ui.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CultureModel = AdventureAdmin.Data.Models.Culture;

namespace AdventureAdmin.Ui.Culture
{
    public partial class CultureList : Form
    {
        private readonly CultureService _service;

        public CultureList(CultureService service)
        {
            InitializeComponent();
            _service = service;
            // Cargar datos al inicializar el formulario para que la lista esté disponible al entrar
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                // Obtenemos la lista desde el servicio
                var culturas = await _service.GetList(c => true);

                // Actualizamos el DataSource en el hilo de la UI
                dataGridView1.DataSource = null; // Limpiar para refrescar
                dataGridView1.DataSource = culturas;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Botón Nuevo
        {
            var form = Program.ServiceProvider.GetRequiredService<CultureForm>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }
        }

        private void button2_Click(object sender, EventArgs e) // Botón Modificar
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para modificar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entidad = (CultureModel)dataGridView1.CurrentRow.DataBoundItem;

            // Creamos la instancia pasando la entidad seleccionada al constructor
            var form = ActivatorUtilities.CreateInstance<CultureForm>(
                Program.ServiceProvider, entidad);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }
        }

        private void button3_Click(object sender, EventArgs e) // Botón Eliminar
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entidad = (CultureModel)dataGridView1.CurrentRow.DataBoundItem;

            var result = MessageBox.Show(
                $"¿Desea eliminar la cultura '{entidad.Name}' (ID: {entidad.CultureId})?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _ = EliminarAsync(entidad.CultureId);
            }
        }

        private async Task EliminarAsync(string id)
        {
            try
            {
                var success = await _service.Eliminar(id);

                if (success)
                {
                    MessageBox.Show("Cultura eliminada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar la cultura.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CultureList_Load_1(object sender, EventArgs e)
        {
            // Cargar datos al abrir el formulario
            _ = LoadDataAsync();
        }
    }
}