using System;
using System.Linq;
using System.Windows.Forms;
using AdventureAdmin.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.CreditCard
{
    public partial class CreditCardList : Form
    {
        private readonly AdventureWorksContext _context;

        public CreditCardList(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void CreditCardList_Load(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private void RefrescarDatos()
        {
            try
            {
                var tarjetas = _context.CreditCards.ToList();
                dgvCards.DataSource = tarjetas;

                if (dgvCards.Columns["SalesOrderHeaders"] != null) dgvCards.Columns["SalesOrderHeaders"].Visible = false;
                if (dgvCards.Columns["PersonCreditCards"] != null) dgvCards.Columns["PersonCreditCards"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<CreditCardForm>();

            if (form.ShowDialog() == DialogResult.OK)
            {
                RefrescarDatos();
            }
        }

        private void dgvCards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CreditCardList_Load_1(object sender, EventArgs e)
        {
            RefrescarDatos();
        }
    }
}