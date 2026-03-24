using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AdventureAdmin.Ui.Department
{
    public partial class DepartmentList : Form
    {
        private readonly AdventureWorksContext _context;

        public DepartmentList(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void button1_Click(object sender, EventArgs e)
        {
                   
            // Llamamos a su formulario de creación
            var form = Program.ServiceProvider.GetRequiredService<DepartmentForm>();

            // Si el usuario guardó con éxito, recargamos la tabla
            if (form.ShowDialog() == DialogResult.OK)
            {
                _ = LoadDataAsync();
            }
        }

        private void DepartmentList_Load(object sender, EventArgs e)
        {
            _ = LoadDataAsync();
        }
        // Método asíncrono para traer la lista de la base de datos
        private async Task LoadDataAsync()
        {
            try
            {
                var departamentos = await _context.Departments.ToListAsync();

                dataGridView1.DataSource = departamentos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
