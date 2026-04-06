namespace AdventureAdmin.Ui.ProductCategory
{
    partial class ProductCategoryList
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvCategorias = new DataGridView();
            refrescarButton = new Button();
            nuevoButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // dgvCategorias
            // 
            dgvCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Location = new Point(13, 48);
            dgvCategorias.Margin = new Padding(3, 4, 3, 4);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 62;
            dgvCategorias.Size = new Size(608, 365);
            dgvCategorias.TabIndex = 0;
            // 
            // refrescarButton
            // 
            refrescarButton.Location = new Point(113, 12);
            refrescarButton.Name = "refrescarButton";
            refrescarButton.Size = new Size(94, 29);
            refrescarButton.TabIndex = 4;
            refrescarButton.Text = "Refrescar";
            refrescarButton.UseVisualStyleBackColor = true;
            refrescarButton.Click += refrescarButton_Click;
            // 
            // nuevoButton
            // 
            nuevoButton.Location = new Point(13, 12);
            nuevoButton.Name = "nuevoButton";
            nuevoButton.Size = new Size(94, 29);
            nuevoButton.TabIndex = 3;
            nuevoButton.Text = "Nuevo";
            nuevoButton.UseVisualStyleBackColor = true;
            nuevoButton.Click += nuevoButton_Click;
            // 
            // ProductCategoryList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 426);
            Controls.Add(refrescarButton);
            Controls.Add(nuevoButton);
            Controls.Add(dgvCategorias);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductCategoryList";
            Text = "Lista de Categorías de Producto";
            Load += ProductCategoryList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCategorias;
        private Button refrescarButton;
        private Button nuevoButton;
    }
}
