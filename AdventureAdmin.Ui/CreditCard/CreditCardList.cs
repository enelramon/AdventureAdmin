using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
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

        private  void CreditCardList_Load(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private async Task RefrescarDatos()
        {
            try
            {
                var tarjetas = await _context.CreditCards.ToListAsync();
                dgvCards.DataSource = tarjetas;

                if (dgvCards.Columns["SalesOrderHeaders"] != null) dgvCards.Columns["SalesOrderHeaders"].Visible = false;
                if (dgvCards.Columns["PersonCreditCards"] != null) dgvCards.Columns["PersonCreditCards"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private async void nuevoButton_Click(object sender, EventArgs e)
        {
            var form = Program.ServiceProvider.GetRequiredService<CreditCardForm>();

            if (form.ShowDialog() == DialogResult.OK)
            {
               await RefrescarDatos();
            }
        }

        private async void refrescarButton_Click(object sender, EventArgs e)
        {
            await  RefrescarDatos();
        }
    }
}
