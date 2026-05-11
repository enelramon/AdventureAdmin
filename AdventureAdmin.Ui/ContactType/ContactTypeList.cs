using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.ContactType
{
    public partial class ContactTypeList : Form
    {

        private readonly ContactTypeService _service;

        public ContactTypeList(ContactTypeService service)
        {
            InitializeComponent();
            _service = service;

            this.Load += ContactTypeList_LoadAsync;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var contactTypeForm = Program.ServiceProvider
            .GetRequiredService<ContactTypeForm>();

            if (contactTypeForm.ShowDialog(this) == DialogResult.OK)
                await LoadDataAsync();
        }

        private async void ContactTypeList_LoadAsync(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var contactos = await _service.GetList(x => true);

                dataGridView1.DataSource = contactos;

                dataGridView1?.Columns?["ContactTypeId"]?.HeaderText = "ID";
                dataGridView1?.Columns?["Name"]?.HeaderText = "Nombre";
                dataGridView1?.Columns?["ModifiedDate"]?.HeaderText = "Fecha Modificación";

                dataGridView1?.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private async void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1?.CurrentRow?.DataBoundItem is Data.Models.ContactType entidad)
            {
                var form = ActivatorUtilities.CreateInstance<ContactTypeForm>(
                    Program.ServiceProvider, entidad);

                if (form.ShowDialog(this) == DialogResult.OK)
                    await LoadDataAsync();
            }
        }
    }
}
