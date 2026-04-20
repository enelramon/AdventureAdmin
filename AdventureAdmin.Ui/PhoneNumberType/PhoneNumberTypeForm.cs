using System;
using System.Windows.Forms;
using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;

namespace AdventureAdmin.Ui.PhoneNumberType
{
    public partial class PhoneNumberTypeForm : Form
    {
        private readonly AdventureWorksContext _context;

        public PhoneNumberTypeForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();

            // Validación
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, "El nombre es obligatorio.");
                return;
            }

            try
            {
                var nuevoTipo = new AdventureAdmin.Data.Models.PhoneNumberType
                {
                    Name = txtName.Text,
                    ModifiedDate = DateTime.Now
                };

                _context.PhoneNumberTypes.Add(nuevoTipo);
                _context.SaveChanges();

                MessageBox.Show("Tipo de teléfono guardado correctamente",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PhoneNumberTypeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
