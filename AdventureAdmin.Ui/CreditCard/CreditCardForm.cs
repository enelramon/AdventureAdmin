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

        public CreditCardForm(CreditCardService creditCardService)
        {
            InitializeComponent();
            _creditCardService = creditCardService;


            numMonth.Minimum = 1;
            numMonth.Maximum = 12;
            numYear.Minimum = 2024;
            numYear.Maximum = 2099;
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
                var nuevaTarjeta = new AdventureAdmin.Data.Models.CreditCard
                {
                    CardType = txtCardType.Text,
                    CardNumber = txtCardNumber.Text,
                    ExpMonth = (byte)numMonth.Value,
                    ExpYear = (short)numYear.Value,
                    ModifiedDate = DateTime.Now
                };

                var paso = await _creditCardService.Guardar(nuevaTarjeta);

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