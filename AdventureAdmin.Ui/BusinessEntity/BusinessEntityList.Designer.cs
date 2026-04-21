namespace AdventureAdmin.Ui.Business_Entity
{
    partial class BusinessEntityList
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
            Guardar = new Button();
            dataGridView1 = new DataGridView();
            btnModificar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Guardar
            // 
            Guardar.Location = new Point(12, 12);
            Guardar.Name = "Guardar";
            Guardar.Size = new Size(112, 34);
            Guardar.TabIndex = 0;
            Guardar.Text = "Nuevo";
            Guardar.UseVisualStyleBackColor = true;
            Guardar.Click += btnNuevo_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Left;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 72);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(776, 408);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(142, 12);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(112, 34);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(280, 12);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 34);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // BusinessEntityList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 492);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(dataGridView1);
            Controls.Add(Guardar);
            Name = "BusinessEntityList";
            Text = "BusinessEntityList";
            Load += BusinessEntityList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEliminar;
        private DataGridView dataGridView1;
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Se deja vacío para que el Designer no dé error
        }

        private Button Guardar;
        private Button Btn;
        private Button btnModificar;
    } 
}