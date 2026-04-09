namespace AdventureAdmin.Ui.Product;

partial class ProductList
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        productsDataGridView = new DataGridView();
        nuevoButton = new Button();
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).BeginInit();
        SuspendLayout();
        // 
        // productsDataGridView
        // 
        productsDataGridView.AllowUserToAddRows = false;
        productsDataGridView.AllowUserToDeleteRows = false;
        productsDataGridView.AllowUserToOrderColumns = true;
        productsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        productsDataGridView.Location = new Point(10, 28);
        productsDataGridView.Margin = new Padding(3, 2, 3, 2);
        productsDataGridView.Name = "productsDataGridView";
        productsDataGridView.ReadOnly = true;
        productsDataGridView.RowHeadersWidth = 51;
        productsDataGridView.Size = new Size(679, 300);
        productsDataGridView.TabIndex = 0;
        productsDataGridView.CellContentClick += productsDataGridView_CellContentClick;
        // 
        // nuevoButton
        // 
        nuevoButton.Location = new Point(10, 2);
        nuevoButton.Margin = new Padding(3, 2, 3, 2);
        nuevoButton.Name = "nuevoButton";
        nuevoButton.Size = new Size(82, 22);
        nuevoButton.TabIndex = 1;
        nuevoButton.Text = "✅ Nuevo";
        nuevoButton.UseVisualStyleBackColor = true;
        nuevoButton.Click += nuevoButton_Click;
        // 
        // ProductList
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(700, 338);
        Controls.Add(nuevoButton);
        Controls.Add(productsDataGridView);
        Margin = new Padding(3, 2, 3, 2);
        Name = "ProductList";
        Text = "ProductList";
        Load += ProductList_Load;
        ((System.ComponentModel.ISupportInitialize)productsDataGridView).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView productsDataGridView;
    private Button nuevoButton;
}