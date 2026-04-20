using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureAdmin.Ui.Business_Entity
{
    public partial class BusinessEntityList : Form
    {
        private readonly AdventureWorksContext _context;

        public BusinessEntityList(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void BusinessEntityList_Load(object sender, EventArgs e)
        {
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                _context.ChangeTracker.Clear();
                var lista = await _context.BusinessEntities.AsNoTracking().ToListAsync();
                dataGridView1.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                var form = Program.ServiceProvider.GetRequiredService<BusinessEntityForm>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadDataAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar nuevo registro: {ex.Message}");
            }
        }

        // --- NUEVO: BOTÓN MODIFICAR ---
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para modificar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Obtenemos la entidad de la fila seleccionada
            var entidad = (BusinessEntity)dataGridView1.CurrentRow.DataBoundItem;

            var form = Program.ServiceProvider.GetRequiredService<BusinessEntityForm>();

            // Le pasamos los datos al formulario para que sepa que va a editar
            form.CargarDatos(entidad);

            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }
        }

        // --- NUEVO: BOTÓN ELIMINAR ---
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var entidad = (BusinessEntity)dataGridView1.CurrentRow.DataBoundItem;

            var result = MessageBox.Show(
                $"¿Desea eliminar la entidad con GUID '{entidad.Rowguid}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _ = EliminarAsync(entidad);
            }
        }

        private async Task EliminarAsync(BusinessEntity entidad)
        {
            try
            {
                _context.BusinessEntities.Remove(entidad);
                await _context.SaveChangesAsync();

                MessageBox.Show("Entidad eliminada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

        }
    }
}