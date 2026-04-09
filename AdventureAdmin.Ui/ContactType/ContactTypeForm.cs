using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdventureAdmin.Ui.ContactType
{
    public partial class ContactTypeForm : Form
    {
        private readonly AdventureWorksContext _context;
        public ContactTypeForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                button1.Enabled = false;
                var contactType = new Data.Models.ContactType
                {
                    Name = textBox2.Text,
                    ModifiedDate = DateTime.Now
                };

                _context.ContactTypes.Add(contactType);
                await _context.SaveChangesAsync();

                MessageBox.Show("Tipo de contacto guardado correctamente");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm()
        {
            errorProvider1.Clear();
            bool valido = true;

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "El nombre es obligatorio.");
                valido = false;
            }

            return valido;
        }
    }
}
