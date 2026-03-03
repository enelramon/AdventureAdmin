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
        productsDataGridView.Location = new Point(12, 38);
        productsDataGridView.Name = "productsDataGridView";
        productsDataGridView.ReadOnly = true;
        productsDataGridView.RowHeadersWidth = 51;
        productsDataGridView.Size = new Size(776, 400);
        productsDataGridView.TabIndex = 0;
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
        // ProductList
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(nuevoButton);
        Controls.Add(productsDataGridView);
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