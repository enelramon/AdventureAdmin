using System;
using System.Windows.Forms;
using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;
using AdventureAdmin.Ui.Services;

namespace AdventureAdmin.Ui.CreditCard
{
    public partial class CreditCardForm : Form
    {
        private readonly CreditCardService _creditCardService;
        private Data.Models.CreditCard? _tarjetaExistente;

        public CreditCardForm(CreditCardService creditCardService)
        {
            InitializeComponent();
            _creditCardService = creditCardService;

            numMonth.Minimum = 1;
            numMonth.Maximum = 12;
            numYear.Minimum = 2024;
            numYear.Maximum = 2099;
        }

        public void SetTarjeta(Data.Models.CreditCard tarjeta)
        {
            _tarjetaExistente = tarjeta;
            this.Text = "Editar Tarjeta";
            txtCardType.Text = tarjeta.CardType;
            txtCardNumber.Text = tarjeta.CardNumber;
            numMonth.Value = tarjeta.ExpMonth;
            numYear.Value = tarjeta.ExpYear;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();


            if (string.IsNullOrWhiteSpace(txtCardType.Text))
            {
                errorProvider1.SetError(txtCardType, "El tipo de tarjeta es obligatorio.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCardNumber.Text))
            {
                errorProvider1.SetError(txtCardNumber, "El número de tarjeta es obligatorio.");
                return;
            }

            try
            {
                var tarjeta = _tarjetaExistente ?? new AdventureAdmin.Data.Models.CreditCard();

                tarjeta.CardType = txtCardType.Text;
                tarjeta.CardNumber = txtCardNumber.Text;
                tarjeta.ExpMonth = (byte)numMonth.Value;
                tarjeta.ExpYear = (short)numYear.Value;

                if (_tarjetaExistente == null)
                {
                    tarjeta.ModifiedDate = DateTime.Now;
                }

                var paso = await _creditCardService.Guardar(tarjeta);

                if (!paso)
                {
                    MessageBox.Show("Error al guardar la tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else
                {
                    MessageBox.Show("Tarjeta guardada correctamente", "Éxito", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}