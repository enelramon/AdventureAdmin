using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdmin.Ui.Business_Entity
{
    public partial class BusinessEntityForm : Form
    {
        private readonly AdventureWorksContext _context;

        public BusinessEntityForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void BusinessEntityForm_Load(object sender, EventArgs e)
        {
            // Opcional: Sugerir un Guid al cargar para facilitar la prueba
            if (string.IsNullOrWhiteSpace(txtGuid.Text))
            {
                txtGuid.Text = Guid.NewGuid().ToString();
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                btnGuardar.Enabled = false;

                // Crear la entidad con el Guid ingresado
                var businessEntity = new AdventureAdmin.Data.Models.BusinessEntity
                {
                    Rowguid = Guid.Parse(txtGuid.Text.Trim()),
                    ModifiedDate = DateTime.Now
                };

                _context.BusinessEntities.Add(businessEntity);
                await _context.SaveChangesAsync();

                MessageBox.Show("Business Entity creada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string mensaje = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Error al guardar: {mensaje}", "Error",
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

            // Validación de campo vacío
            if (string.IsNullOrWhiteSpace(txtGuid.Text))
            {
                errorProvider1.SetError(txtGuid, "El campo RowGuid es obligatorio.");
                valid = false;
            }
            // Validación de formato Guid (muy importante para tu tabla)
            else if (!Guid.TryParse(txtGuid.Text.Trim(), out _))
            {
                errorProvider1.SetError(txtGuid, "El formato del Guid no es válido.");
                valid = false;
            }

            return valid;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Métodos de eventos vacíos (si los tienes en el diseñador)
        private void txtGuid_TextChanged(object sender, EventArgs e) { }
    }
}