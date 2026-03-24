using AdventureAdmin.Data.Context;
using AdventureAdmin.Ui.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.CreditCard
{
    public partial class CreditCardList : Form
    {
        private readonly CreditCardService _creditCardService;

        public CreditCardList(CreditCardService creditCardService)
        {
            InitializeComponent();
            _creditCardService = creditCardService;
        }

        private void CreditCardList_Load(object sender, EventArgs e)
        {
            RefrescarDatos();
        }

        private async Task RefrescarDatos()
        {
            try
            {
                var tarjetas = await _creditCardService.GetList(c => true);
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
            await RefrescarDatos();

        }
    }
}
