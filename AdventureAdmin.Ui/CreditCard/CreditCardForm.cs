using System;
using System.Windows.Forms;
using AdventureAdmin.Data.Context;
using AdventureAdmin.Data.Models;

namespace AdventureAdmin.Ui.CreditCard
{
    public partial class CreditCardForm : Form
    {
        private readonly AdventureWorksContext _context;

        public CreditCardForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;


            numMonth.Minimum = 1;
            numMonth.Maximum = 12;
            numYear.Minimum = 2024;
            numYear.Maximum = 2099;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
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

                _context.CreditCards.Add(nuevaTarjeta);
                _context.SaveChanges();

                MessageBox.Show("Tarjeta guardada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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