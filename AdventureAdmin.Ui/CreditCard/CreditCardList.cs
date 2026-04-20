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

        private async void modificarButton_Click(object sender, EventArgs e)
        {
            if (dgvCards.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una tarjeta para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tarjeta = (Data.Models.CreditCard)dgvCards.SelectedRows[0].DataBoundItem;
            var form = Program.ServiceProvider.GetRequiredService<CreditCardForm>();

            form.SetTarjeta(tarjeta);

            if (form.ShowDialog() == DialogResult.OK)
            {
                await RefrescarDatos();
            }
        }

        private async void eliminarButton_Click(object sender, EventArgs e)
        {
            if (dgvCards.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar una tarjeta para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar esta tarjeta?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                var tarjeta = (Data.Models.CreditCard)dgvCards.SelectedRows[0].DataBoundItem;
                var resultado = await _creditCardService.Eliminar(tarjeta.CreditCardId);

                if (resultado)
                {
                    MessageBox.Show("Tarjeta eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await RefrescarDatos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la tarjeta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
