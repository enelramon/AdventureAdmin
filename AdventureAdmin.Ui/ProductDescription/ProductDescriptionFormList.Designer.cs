namespace AdventureAdmin.Ui.Product;

partial class ProductDescriptionList
{
    private System.ComponentModel.IContainer components = null;

    private DataGridView productDescriptionDataGridView;
    private Button refrescarButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        productDescriptionDataGridView = new DataGridView();
        refrescarButton = new Button();
        nuevoButton = new Button();
        ((System.ComponentModel.ISupportInitialize)productDescriptionDataGridView).BeginInit();
        SuspendLayout();
        // 
        // productDescriptionDataGridView
        // 
        productDescriptionDataGridView.AllowUserToAddRows = false;
        productDescriptionDataGridView.AllowUserToDeleteRows = false;
        productDescriptionDataGridView.AllowUserToOrderColumns = true;
        productDescriptionDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        productDescriptionDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        productDescriptionDataGridView.Location = new Point(12, 38);
        productDescriptionDataGridView.Name = "productDescriptionDataGridView";
        productDescriptionDataGridView.ReadOnly = true;
        productDescriptionDataGridView.RowHeadersWidth = 51;
        productDescriptionDataGridView.Size = new Size(831, 465);
        productDescriptionDataGridView.TabIndex = 0;
        // 
        // refrescarButton
        // 
        refrescarButton.Location = new Point(112, 3);
        refrescarButton.Name = "refrescarButton";
        refrescarButton.Size = new Size(94, 29);
        refrescarButton.TabIndex = 2;
        refrescarButton.Text = "🔄 Refrescar";
        refrescarButton.UseVisualStyleBackColor = true;
        refrescarButton.Click += refrescarButton_Click;
        // 
        // nuevoButton
        // 
        nuevoButton.Location = new Point(12, 3);
        nuevoButton.Name = "nuevoButton";
        nuevoButton.Size = new Size(94, 29);
        nuevoButton.TabIndex = 1;
        nuevoButton.Text = "✅ Nuevo";
        nuevoButton.UseVisualStyleBackColor = true;
        nuevoButton.Click += nuevoButton_Click;
        // 
        // ProductDescriptionList
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(855, 515);
        Controls.Add(refrescarButton);
        Controls.Add(nuevoButton);
        Controls.Add(productDescriptionDataGridView);
        Name = "ProductDescriptionList";
        Text = "Lista de Descripciones de Producto";
        Load += ProductDescriptionList_Load;
        ((System.ComponentModel.ISupportInitialize)productDescriptionDataGridView).EndInit();
        ResumeLayout(false);
    }

    private Button nuevoButton;
}