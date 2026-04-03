 using AdventureAdmin.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdventureAdmin.Ui.Business_Entity;

public partial class Business_Entity_list : Form
{
    private readonly AdventureWorksContext _context; 
    private readonly DataGridView _businessEntitiesGrid;

    public Business_Entity_list(AdventureWorksContext context)
    {
        InitializeComponent();
        _context = context;

        _businessEntitiesGrid = CreateGrid();
        Controls.Add(_businessEntitiesGrid);

        button1.Text = "Nuevo";
        button1.Click += button1_Click;
        Load += Business_Entity_list_Load;
    }

    private async void Business_Entity_list_Load(object? sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async void button1_Click(object? sender, EventArgs e)
    {
        var form = Program.ServiceProvider.GetRequiredService<Business_Entity_Form>();
        if (form.ShowDialog(this) == DialogResult.OK)
        {
            await LoadDataAsync();
        }
    }

    private async Task LoadDataAsync()
    {
        try
        {
            var data = await _context.BusinessEntities
                .AsNoTracking()
                .OrderByDescending(be => be.BusinessEntityId)
                .Select(be => new BusinessEntityListItem
                {
                    BusinessEntityId = be.BusinessEntityId,
                    Nombre = _context.People
                        .Where(p => p.BusinessEntityId == be.BusinessEntityId)
                        .Select(p => (p.FirstName + " " + p.LastName).Trim())
                        .FirstOrDefault() ?? string.Empty,
                    Email = _context.EmailAddresses
                        .Where(e => e.BusinessEntityId == be.BusinessEntityId)
                        .OrderBy(e => e.EmailAddressId)
                        .Select(e => e.EmailAddress1)
                        .FirstOrDefault(),
                    Phone = _context.PersonPhones
                        .Where(p => p.BusinessEntityId == be.BusinessEntityId)
                        .OrderBy(p => p.PhoneNumberTypeId)
                        .ThenBy(p => p.PhoneNumber)
                        .Select(p => p.PhoneNumber)
                        .FirstOrDefault(),
                    Address = _context.BusinessEntityAddresses
                        .Where(a => a.BusinessEntityId == be.BusinessEntityId)
                        .OrderBy(a => a.AddressId)
                        .Select(a => a.Address.AddressLine1)
                        .FirstOrDefault(),
                    ModifiedDate = be.ModifiedDate
                })
                .ToListAsync();

            _businessEntitiesGrid.DataSource = data;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Error al cargar BusinessEntity: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private DataGridView CreateGrid()
    {
        return new DataGridView
        {
            Name = "businessEntitiesDataGridView",
            Location = new Point(22, 54),
            Size = new Size(758, 380),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            ReadOnly = true,
            AutoGenerateColumns = true,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToOrderColumns = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false
        };
    }

    private sealed class BusinessEntityListItem
    {
        public int BusinessEntityId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
