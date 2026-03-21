namespace AdventureAdmin.Ui.Product;

partial class ProductDescriptionForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblDescription;
    private TextBox txtDescription;
    private Button btnSave, btnCancel;
    private ErrorProvider errorProvider;
    private Panel panelButtons;
    private TableLayoutPanel layout;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        errorProvider = new ErrorProvider(components);
        layout = new TableLayoutPanel();
        lblDescription = new Label();
        txtDescription = new TextBox();
        btnSave = new Button();
        btnCancel = new Button();
        panelButtons = new Panel();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        layout.SuspendLayout();
        panelButtons.SuspendLayout();
        SuspendLayout();
         
        errorProvider.ContainerControl = this;
        
        layout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        layout.ColumnCount = 2;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 131F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(txtDescription, 1, 0);
        layout.Controls.Add(lblDescription, 0, 0);
        layout.Location = new Point(10, 38);
        layout.Margin = new Padding(3, 2, 3, 2);
        layout.Name = "layout";
        layout.RowCount = 1;
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
        layout.Size = new Size(575, 164);
        layout.TabIndex = 0;
        
        lblDescription.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblDescription.AutoSize = true;
        lblDescription.Location = new Point(56, 8);
        lblDescription.Margin = new Padding(3, 8, 3, 0);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new Size(72, 15);
        lblDescription.TabIndex = 0;
        lblDescription.Text = "Descripción:";
        lblDescription.TextAlign = ContentAlignment.MiddleRight;
         
        txtDescription.Location = new Point(134, 8);
        txtDescription.Margin = new Padding(3, 8, 3, 2);
        txtDescription.MaxLength = 400;
        txtDescription.Multiline = true;
        txtDescription.Name = "txtDescription";
        txtDescription.ScrollBars = ScrollBars.Vertical;
        txtDescription.Size = new Size(438, 154);
        txtDescription.TabIndex = 1;
        
        btnSave.Location = new Point(2, 2);
        btnSave.Margin = new Padding(3, 2, 3, 2);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(91, 26);
        btnSave.TabIndex = 0;
        btnSave.Text = "💾Guardar";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        
        btnCancel.Location = new Point(99, 2);
        btnCancel.Margin = new Padding(3, 2, 3, 2);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(91, 26);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "❌ Cancelar";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        
        panelButtons.Controls.Add(btnSave);
        panelButtons.Controls.Add(btnCancel);
        panelButtons.Location = new Point(180, 8);
        panelButtons.Margin = new Padding(3, 2, 3, 2);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new Size(213, 28);
        panelButtons.TabIndex = 1;
        
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(596, 239);
        Controls.Add(layout);
        Controls.Add(panelButtons);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Margin = new Padding(3, 2, 3, 2);
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ProductDescriptionForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Agregar Descripción de Producto";
        Load += ProductDescriptionForm_Load;
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        layout.ResumeLayout(false);
        layout.PerformLayout();
        panelButtons.ResumeLayout(false);
        ResumeLayout(false);
    }
}