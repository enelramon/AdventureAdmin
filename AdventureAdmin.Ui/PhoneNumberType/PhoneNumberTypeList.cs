using AdventureAdmin.Data.Context;
using AdventureAdmin.Ui.Product;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AdventureAdmin.Ui.PhoneNumberType
{
    public partial class PhoneNumberTypeList : Form
    {
        private readonly AdventureWorksContext _context;

        public PhoneNumberTypeList(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void PhoneNumberTypeList_Load(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            try
            {
                var tipos = _context.PhoneNumberTypes.ToList();
                dgvPhoneNumberTypes.DataSource = tipos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<PhoneNumberTypeForm>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                RefrescarDatos();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var PhoneNumberType = Program.ServiceProvider.GetRequiredService<PhoneNumberTypeForm>();
            PhoneNumberType.ShowDialog();
        }
    }
}
