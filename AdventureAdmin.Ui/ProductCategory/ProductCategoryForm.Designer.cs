namespace AdventureAdmin.Ui.ProductCategory
{
    partial class ProductCategoryForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            btnGuardar = new Button();
            errorProvider1 = new ErrorProvider(components);
            dtpModifiedDate = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 38);
            label1.Name = "label1";
            label1.Size = new Size(83, 22);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(14, 90);
            label2.Name = "label2";
            label2.Size = new Size(219, 22);
            label2.TabIndex = 1;
            label2.Text = "Fecha de Modificacion";
            // 
            // txtName
            // 
            txtName.Location = new Point(220, 42);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(241, 27);
            txtName.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.YellowGreen;
            btnGuardar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(14, 150);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(99, 46);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // dtpModifiedDate
            // 
            dtpModifiedDate.Format = DateTimePickerFormat.Short;
            dtpModifiedDate.Location = new Point(220, 90);
            dtpModifiedDate.Name = "dtpModifiedDate";
            dtpModifiedDate.Size = new Size(241, 27);
            dtpModifiedDate.TabIndex = 3;
            dtpModifiedDate.ValueChanged += dtpModifiedDate_ValueChanged;
            // 
            // ProductCategoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 250);
            Controls.Add(dtpModifiedDate);
            Controls.Add(btnGuardar);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ProductCategoryForm";
            Text = "Crear Categoría de Producto";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private Button btnGuardar;
        private ErrorProvider errorProvider1;
        private DateTimePicker dtpModifiedDate;
    }
}
