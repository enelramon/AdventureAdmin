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

        
        private bool esModificacion = false;
        private BusinessEntity entidadAEditar;

        public BusinessEntityForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

       
        public void CargarDatos(BusinessEntity entidad)
        {
            esModificacion = true;
            entidadAEditar = entidad;

           
            txtGuid.Text = entidad.Rowguid.ToString();

           
            this.Text = "Modificar Business Entity";
            btnGuardar.Text = "Actualizar";
        }

        private void BusinessEntityForm_Load(object sender, EventArgs e)
        {
            
            if (!esModificacion && string.IsNullOrWhiteSpace(txtGuid.Text))
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

                if (esModificacion)
                {
                    // --- MODO MODIFICAR ---
                    entidadAEditar.Rowguid = Guid.Parse(txtGuid.Text.Trim());
                    entidadAEditar.ModifiedDate = DateTime.Now;

                    _context.BusinessEntities.Update(entidadAEditar);
                }
                else
                {
                   
                    var businessEntity = new BusinessEntity
                    {
                        Rowguid = Guid.Parse(txtGuid.Text.Trim()),
                        ModifiedDate = DateTime.Now
                    };
                    _context.BusinessEntities.Add(businessEntity);
                }

                await _context.SaveChangesAsync();

                MessageBox.Show(esModificacion ? "Actualizado correctamente." : "Creado correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if (string.IsNullOrWhiteSpace(txtGuid.Text))
            {
                errorProvider1.SetError(txtGuid, "El campo RowGuid es obligatorio.");
                valid = false;
            }
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

        private void txtGuid_TextChanged(object sender, EventArgs e) { }
    }
}