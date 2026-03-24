namespace AdventureAdmin.Ui.Product;

partial class ProductForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblName, lblProductNumber, lblColor, lblStandardCost;
    private Label lblListPrice, lblSize, lblWeight, lblCategory, lblModel, lblSellStart;
    private Label lblSellEnd, lblDiscontinued;
    private TextBox txtName, txtProductNumber, txtColor, txtSize, txtWeight;
    private NumericUpDown numStandardCost, numListPrice;
    private ComboBox cmbCategory, cmbModel;
    private DateTimePicker dtpSellStart, dtpSellEnd, dtpDiscontinued;
    private CheckBox chkSellEnd, chkDiscontinued;
    private Button btnSave, btnCancel;
    private ErrorProvider errorProvider;
    private Panel panelButtons;

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
        lblColor = new Label();
        txtColor = new TextBox();
        lblStandardCost = new Label();
        numStandardCost = new NumericUpDown();
        lblListPrice = new Label();
        numListPrice = new NumericUpDown();
        lblSize = new Label();
        txtSize = new TextBox();
        lblWeight = new Label();
        txtWeight = new TextBox();
        lblCategory = new Label();
        cmbCategory = new ComboBox();
        lblModel = new Label();
        cmbModel = new ComboBox();
        lblSellStart = new Label();
        lblSellEnd = new Label();
        panelSellEnd = new FlowLayoutPanel();
        chkSellEnd = new CheckBox();
        dtpSellEnd = new DateTimePicker();
        lblDiscontinued = new Label();
        panelDisc = new FlowLayoutPanel();
        chkDiscontinued = new CheckBox();
        dtpDiscontinued = new DateTimePicker();
        dtpSellStart = new DateTimePicker();
        txtProductNumber = new TextBox();
        txtName = new TextBox();
        lblName = new Label();
        lblProductNumber = new Label();
        btnSave = new Button();
        btnCancel = new Button();
        panelButtons = new Panel();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        layout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numStandardCost).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numListPrice).BeginInit();
        panelSellEnd.SuspendLayout();
        panelDisc.SuspendLayout();
        panelButtons.SuspendLayout();
        SuspendLayout();
        // 
        // errorProvider
        // 
        errorProvider.ContainerControl = this;
        // 
        // layout
        // 
        layout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layout.Controls.Add(lblColor, 0, 2);
        layout.Controls.Add(txtColor, 1, 2);
        layout.Controls.Add(lblStandardCost, 0, 3);
        layout.Controls.Add(numStandardCost, 1, 3);
        layout.Controls.Add(lblListPrice, 0, 4);
        layout.Controls.Add(numListPrice, 1, 4);
        layout.Controls.Add(lblSize, 0, 5);
        layout.Controls.Add(txtSize, 1, 5);
        layout.Controls.Add(lblWeight, 0, 6);
        layout.Controls.Add(txtWeight, 1, 6);
        layout.Controls.Add(lblCategory, 0, 7);
        layout.Controls.Add(cmbCategory, 1, 7);
        layout.Controls.Add(lblModel, 0, 8);
        layout.Controls.Add(cmbModel, 1, 8);
        layout.Controls.Add(lblSellStart, 0, 9);
        layout.Controls.Add(lblSellEnd, 0, 10);
        layout.Controls.Add(panelSellEnd, 1, 10);
        layout.Controls.Add(lblDiscontinued, 0, 11);
        layout.Controls.Add(panelDisc, 1, 11);
        layout.Controls.Add(dtpSellStart, 1, 9);
        layout.Controls.Add(txtProductNumber, 1, 0);
        layout.Controls.Add(txtName, 1, 1);
        layout.Controls.Add(lblName, 0, 1);
        layout.Controls.Add(lblProductNumber, 0, 0);
        layout.Location = new Point(12, 55);
        layout.Name = "layout";
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
        layout.Size = new Size(619, 424);
        layout.TabIndex = 0;
        // 
        // lblColor
        // 
        lblColor.Location = new Point(3, 70);
        lblColor.Name = "lblColor";
        lblColor.Size = new Size(100, 23);
        lblColor.TabIndex = 4;
        lblColor.Text = "Color";
        // 
        // txtColor
        // 
        txtColor.Location = new Point(153, 73);
        txtColor.Name = "txtColor";
        txtColor.Size = new Size(190, 27);
        txtColor.TabIndex = 5;
        // 
        // lblStandardCost
        // 
        lblStandardCost.Location = new Point(3, 105);
        lblStandardCost.Name = "lblStandardCost";
        lblStandardCost.Size = new Size(100, 23);
        lblStandardCost.TabIndex = 6;
        lblStandardCost.Text = "Costo";
        // 
        // numStandardCost
        // 
        numStandardCost.Location = new Point(153, 108);
        numStandardCost.Name = "numStandardCost";
        numStandardCost.Size = new Size(120, 27);
        numStandardCost.TabIndex = 7;
        // 
        // lblListPrice
        // 
        lblListPrice.Location = new Point(3, 140);
        lblListPrice.Name = "lblListPrice";
        lblListPrice.Size = new Size(100, 23);
        lblListPrice.TabIndex = 8;
        lblListPrice.Text = "Precio";
        // 
        // numListPrice
        // 
        numListPrice.Location = new Point(153, 143);
        numListPrice.Name = "numListPrice";
        numListPrice.Size = new Size(120, 27);
        numListPrice.TabIndex = 9;
        // 
        // lblSize
        // 
        lblSize.Location = new Point(3, 175);
        lblSize.Name = "lblSize";
        lblSize.Size = new Size(100, 23);
        lblSize.TabIndex = 10;
        lblSize.Text = "Size";
        // 
        // txtSize
        // 
        txtSize.Location = new Point(153, 178);
        txtSize.Name = "txtSize";
        txtSize.Size = new Size(100, 27);
        txtSize.TabIndex = 11;
        // 
        // lblWeight
        // 
        lblWeight.Location = new Point(3, 210);
        lblWeight.Name = "lblWeight";
        lblWeight.Size = new Size(100, 23);
        lblWeight.TabIndex = 12;
        lblWeight.Text = "Peso";
        // 
        // txtWeight
        // 
        txtWeight.Location = new Point(153, 213);
        txtWeight.Name = "txtWeight";
        txtWeight.Size = new Size(100, 27);
        txtWeight.TabIndex = 13;
        // 
        // lblCategory
        // 
        lblCategory.Location = new Point(3, 245);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new Size(100, 23);
        lblCategory.TabIndex = 14;
        lblCategory.Text = "Categoria";
        // 
        // cmbCategory
        // 
        cmbCategory.Location = new Point(153, 248);
        cmbCategory.Name = "cmbCategory";
        cmbCategory.Size = new Size(444, 28);
        cmbCategory.TabIndex = 15;
        // 
        // lblModel
        // 
        lblModel.Location = new Point(3, 280);
        lblModel.Name = "lblModel";
        lblModel.Size = new Size(100, 23);
        lblModel.TabIndex = 16;
        lblModel.Text = "Modelo";
        // 
        // cmbModel
        // 
        cmbModel.Location = new Point(153, 283);
        cmbModel.Name = "cmbModel";
        cmbModel.Size = new Size(444, 28);
        cmbModel.TabIndex = 17;
        // 
        // lblSellStart
        // 
        lblSellStart.Location = new Point(3, 315);
        lblSellStart.Name = "lblSellStart";
        lblSellStart.Size = new Size(100, 23);
        lblSellStart.TabIndex = 18;
        lblSellStart.Text = "Inicio Venta";
        // 
        // lblSellEnd
        // 
        lblSellEnd.Location = new Point(3, 350);
        lblSellEnd.Name = "lblSellEnd";
        lblSellEnd.Size = new Size(100, 23);
        lblSellEnd.TabIndex = 20;
        lblSellEnd.Text = "Fin Venta";
        // 
        // panelSellEnd
        // 
        panelSellEnd.Controls.Add(chkSellEnd);
        panelSellEnd.Controls.Add(dtpSellEnd);
        panelSellEnd.Location = new Point(153, 353);
        panelSellEnd.Name = "panelSellEnd";
        panelSellEnd.Size = new Size(444, 29);
        panelSellEnd.TabIndex = 21;
        // 
        // chkSellEnd
        // 
        chkSellEnd.Location = new Point(3, 3);
        chkSellEnd.Name = "chkSellEnd";
        chkSellEnd.Size = new Size(32, 24);
        chkSellEnd.TabIndex = 0;
        chkSellEnd.CheckedChanged += chkSellEnd_CheckedChanged;
        // 
        // dtpSellEnd
        // 
        dtpSellEnd.Location = new Point(41, 3);
        dtpSellEnd.Name = "dtpSellEnd";
        dtpSellEnd.Size = new Size(200, 27);
        dtpSellEnd.TabIndex = 1;
        // 
        // lblDiscontinued
        // 
        lblDiscontinued.Location = new Point(3, 385);
        lblDiscontinued.Name = "lblDiscontinued";
        lblDiscontinued.Size = new Size(116, 23);
        lblDiscontinued.TabIndex = 22;
        lblDiscontinued.Text = "Descontinuado";
        // 
        // panelDisc
        // 
        panelDisc.Controls.Add(chkDiscontinued);
        panelDisc.Controls.Add(dtpDiscontinued);
        panelDisc.Location = new Point(153, 388);
        panelDisc.Name = "panelDisc";
        panelDisc.Size = new Size(444, 33);
        panelDisc.TabIndex = 23;
        // 
        // chkDiscontinued
        // 
        chkDiscontinued.Location = new Point(3, 3);
        chkDiscontinued.Name = "chkDiscontinued";
        chkDiscontinued.Size = new Size(32, 24);
        chkDiscontinued.TabIndex = 0;
        chkDiscontinued.CheckedChanged += chkDiscontinued_CheckedChanged;
        // 
        // dtpDiscontinued
        // 
        dtpDiscontinued.Location = new Point(41, 3);
        dtpDiscontinued.Name = "dtpDiscontinued";
        dtpDiscontinued.Size = new Size(200, 27);
        dtpDiscontinued.TabIndex = 1;
        // 
        // dtpSellStart
        // 
        dtpSellStart.Location = new Point(153, 318);
        dtpSellStart.Name = "dtpSellStart";
        dtpSellStart.Size = new Size(200, 27);
        dtpSellStart.TabIndex = 19;
        // 
        // txtProductNumber
        // 
        txtProductNumber.Location = new Point(153, 3);
        txtProductNumber.Name = "txtProductNumber";
        txtProductNumber.Size = new Size(200, 27);
        txtProductNumber.TabIndex = 3;
        // 
        // txtName
        // 
        txtName.Location = new Point(153, 38);
        txtName.Name = "txtName";
        txtName.Size = new Size(444, 27);
        txtName.TabIndex = 1;
        // 
        // lblName
        // 
        lblName.Location = new Point(3, 35);
        lblName.Name = "lblName";
        lblName.Size = new Size(100, 23);
        lblName.TabIndex = 0;
        lblName.Text = "Nombre";
        // 
        // lblProductNumber
        // 
        lblProductNumber.Location = new Point(3, 0);
        lblProductNumber.Name = "lblProductNumber";
        lblProductNumber.Size = new Size(100, 23);
        lblProductNumber.TabIndex = 2;
        lblProductNumber.Text = "Número";
        // 
        // btnSave
        // 
        btnSave.Location = new Point(2, 3);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(104, 34);
        btnSave.TabIndex = 0;
        btnSave.Text = "💾Guardar";
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(110, 3);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(104, 34);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "❌ Cancelar";
        btnCancel.Click += btnCancel_Click;
        // 
        // panelButtons
        // 
        panelButtons.Controls.Add(btnSave);
        panelButtons.Controls.Add(btnCancel);
        panelButtons.Location = new Point(165, 12);
        panelButtons.Name = "panelButtons";
        panelButtons.Size = new Size(243, 37);
        panelButtons.TabIndex = 1;
        // 
        // ProductForm
        // 
        ClientSize = new Size(643, 503);
        Controls.Add(layout);
        Controls.Add(panelButtons);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ProductForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Crear Producto";
        Load += ProductForm_Load;
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        layout.ResumeLayout(false);
        layout.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numStandardCost).EndInit();
        ((System.ComponentModel.ISupportInitialize)numListPrice).EndInit();
        panelSellEnd.ResumeLayout(false);
        panelDisc.ResumeLayout(false);
        panelButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private TableLayoutPanel layout;
    private FlowLayoutPanel panelSellEnd;
    private FlowLayoutPanel panelDisc;
}