using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AdventureAdmin.Ui.Culture
{
    public partial class CultureForm : Form
    {
        private readonly AdventureWorksContext _context;
        private AdventureAdmin.Data.Models.Culture? _editingEntity;

        public CultureForm(AdventureWorksContext context)
        {
            InitializeComponent();
            _context = context;
        }

        // Constructor para editar una entidad existente
        public CultureForm(AdventureWorksContext context, AdventureAdmin.Data.Models.Culture entidad)
            : this(context)
        {
            SetEntity(entidad);
        }

        private void CultureForm_Load(object sender, EventArgs e)
        {
            button1.Text = "Guardar";

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                button1.Enabled = false;

                if (_editingEntity != null)
                {
                    // Flujo de actualización
                    _editingEntity.Name = textName.Text.Trim();
                    _context.Cultures.Update(_editingEntity);
                    await _context.SaveChangesAsync();

                    MessageBox.Show("Cultura actualizada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Flujo de creación
                    string idIngresado = textId.Text.Trim();

                    bool idExiste = await _context.Cultures.AnyAsync(c => c.CultureId == idIngresado);

                    if (idExiste)
                    {
                        MessageBox.Show($"El ID '{idIngresado}' ya existe en el sistema.", "Validación",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var culture = new AdventureAdmin.Data.Models.Culture
                    {
                        CultureId = idIngresado,
                        Name = textName.Text.Trim(),
                    };

                    _context.Cultures.Add(culture);
                    await _context.SaveChangesAsync();

                    MessageBox.Show("Cultura creada correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.InnerException?.Message ?? ex.Message}", "Error",
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public void SetEntity(AdventureAdmin.Data.Models.Culture entidad)
        {
            _editingEntity = entidad;
            textId.Text = entidad.CultureId;
            textId.Enabled = false;
            textName.Text = entidad.Name;
            button1.Text = "Actualizar";
        }
    }
}