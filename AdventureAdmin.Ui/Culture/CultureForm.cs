using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdventureAdmin.Ui.Culture
{
    public partial class CultureForm : Form
    {
        private readonly AdventureWorksContext _context;

        public CultureForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                button1.Enabled = false;

                var department = new AdventureAdmin.Data.Models.Department
                {
                    Name = textId.Text.Trim(),
                    GroupName = textName.Text.Trim(),
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
                button1.Enabled = true;
            }
        }

        private void CultureForm_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateForm()
        {
            if (textId == null || textName == null)
            {
                MessageBox.Show("Los controles del formulario no están inicializados.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textId.Text))
            {
                MessageBox.Show("El campo 'Id' es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("El campo 'Name' es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textName.Focus();
                return false;
            }

            return true;
        }
    }
}