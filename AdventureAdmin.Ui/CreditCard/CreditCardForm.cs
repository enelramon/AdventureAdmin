using System;
using System.Windows.Forms;
using CreditCardModel = AdventureAdmin.Data.Models.CreditCard;
using AdventureAdmin.Ui.Services;

namespace AdventureAdmin.Ui.CreditCard
{
    public partial class CreditCardForm : Form
    {
        private readonly CreditCardService _creditCardService;
        private readonly CreditCardModel? _tarjeta;

        public CreditCardForm(CreditCardService creditCardService)
        {
            InitializeComponent();
            _creditCardService = creditCardService;

            numMonth.Minimum = 1;
            numMonth.Maximum = 12;
            numYear.Minimum = 2024;
            numYear.Maximum = 2099;
        }

        public CreditCardForm(CreditCardService creditCardService, CreditCardModel tarjeta) : this(creditCardService)
        {
            _tarjeta = tarjeta;
            Text = "Modificar Tarjeta de Credito";
            CargarDatos();
        }

        private void CargarDatos()
        {
            if (_tarjeta == null) return;

            txtCardType.Text = _tarjeta.CardType;
            txtCardNumber.Text = _tarjeta.CardNumber;
            numMonth.Value = _tarjeta.ExpMonth;
            numYear.Value = _tarjeta.ExpYear;
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
                var tarjeta = _tarjeta ?? new CreditCardModel();
                
                tarjeta.CardType = txtCardType.Text;
                tarjeta.CardNumber = txtCardNumber.Text;
                tarjeta.ExpMonth = (byte)numMonth.Value;
                tarjeta.ExpYear = (short)numYear.Value;
                tarjeta.ModifiedDate = DateTime.Now;

                var paso = await _creditCardService.Guardar(tarjeta);

                if (!paso)
                {
                    MessageBox.Show("Error al guardar la tarjeta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
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

        private void CreditCardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
