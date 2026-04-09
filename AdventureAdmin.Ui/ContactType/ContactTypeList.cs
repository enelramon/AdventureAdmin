using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.ContactType
{
    public partial class ContactTypeList : Form
    {
        private readonly AdventureWorksContext _context;
        public ContactTypeList(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var contactTypeForm = Program.ServiceProvider.GetRequiredService<ContactTypeForm>();
            contactTypeForm.ShowDialog();
        }

        private void ContactTypeList_Load(object sender, EventArgs e)
        {
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {

                var contactos = await _context.ContactTypes
                    .Select(ct => new
                    {
                        ct.ContactTypeId,
                        ct.Name,
                        ct.ModifiedDate
                    })
                    .ToListAsync();

                dataGridView1?.DataSource = contactos;

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
    }
}
