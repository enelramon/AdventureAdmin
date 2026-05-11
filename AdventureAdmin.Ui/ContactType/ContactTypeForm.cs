using AdventureAdmin.Data.Context;
using AdventureAdmin.Ui.Services;
using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AdventureAdmin.Ui.ContactType
{
    public partial class ContactTypeForm : Form
    {
        private readonly Data.Models.ContactType? _contactType;
        private readonly ContactTypeService _service;

        public ContactTypeForm(ContactTypeService service) : this(service, null) { }

        public ContactTypeForm(ContactTypeService service, Data.Models.ContactType? entidad)
        {
            InitializeComponent();
            _service = service;
            _contactType = entidad;

            if (_contactType != null)
                CargarDatos(_contactType);
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                button1.Enabled = false;

                if (_contactType == null)
                    await Insertar();
                else
                    await Actualizar();

                MessageBox.Show("Guardado correctamente");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
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

        private void CargarDatos(Data.Models.ContactType e)
        {
            textBox2.Text = e.Name;
        }

        private async Task Insertar()
        {
            var contactType = new Data.Models.ContactType
            {
                Name = textBox2.Text,
                ModifiedDate = DateTime.Now
            };

            await _service.Guardar(contactType);
        }

        private async Task Actualizar()
        {
            var entidad = await _service.Buscar(_contactType.ContactTypeId);

            if (entidad == null) return;

            entidad.Name = textBox2.Text;
            entidad.ModifiedDate = DateTime.Now;

            await _service.Actualizar(entidad);
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
