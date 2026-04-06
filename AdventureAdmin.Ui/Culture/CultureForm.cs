using AdventureAdmin.Data.Context;

namespace AdventureAdmin.Ui.Culture
{
    public partial class CultureForm : Form
    {
        private readonly AdventureWorksContext _context;

        public CultureForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void CultureForm_Load(object sender, EventArgs e)
        {
            button1.Text = "Guardar";
            button1.Click += button1_Click;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                button1.Enabled = false;

                var culture = new AdventureAdmin.Data.Models.Culture
                {
                    CultureId = textId.Text.Trim(),
                    Name = textName.Text.Trim(),
                    ModifiedDate = DateTime.Now
                };

                _context.Cultures.Add(culture);
                await _context.SaveChangesAsync();

                MessageBox.Show("Cultura creada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
            }
        }

        private bool ValidateForm()
        {
            if (textId == null || textName == null)
            {
                MessageBox.Show("Los controles del formulario no están inicializados.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textId.Text))
            {
                MessageBox.Show("El campo 'Id' es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textId.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("El campo 'Name' es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textName.Focus();
                return false;
            }

            return true;
        }
    }
}