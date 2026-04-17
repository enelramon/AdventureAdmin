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

        // 1. Al cargar la lista, usamos el descarte "_" para que cargue de inmediato
        private void BusinessEntityList_Load(object sender, EventArgs e)
        {
            _ = LoadDataAsync();
        }

        // 2. Método de carga igual al de tu amigo
        private async Task LoadDataAsync()
        {
            try
            {
                // Limpiamos el rastreo para que traiga lo nuevo que acabas de guardar
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

                // Si el usuario guardó con éxito (OK), recargamos la tabla
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            // Evento vacío
        }
    }
}