using AdventureAdmin.Ui.Services;
using Microsoft.Extensions.DependencyInjection;
using CreditCardModel = AdventureAdmin.Data.Models.CreditCard;

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

        private async void CreditCardList_Load(object sender, EventArgs e)
        {
            await RefrescarDatos();
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

        private void dgvCards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvCards.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una tarjeta para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tarjeta = dgvCards.CurrentRow.DataBoundItem as CreditCardModel;
            
            if (tarjeta == null)
            {
                MessageBox.Show("No se pudo obtener la tarjeta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var form = new CreditCardForm(_creditCardService, tarjeta);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await RefrescarDatos();
            }
        }
    }
}
