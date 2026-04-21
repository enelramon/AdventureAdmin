namespace AdventureAdmin.Ui.Department
{
    partial class DepartmentList
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
            dataGridView1 = new DataGridView();
            button1 = new Button();
            btnModificar = new Button();
            label1 = new Label();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 63);
            dataGridView1.Margin = new Padding(2, 2, 2, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(666, 292);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // button1
            // 
            button1.AutoEllipsis = true;
            button1.BackColor = SystemColors.Control;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(8, 29);
            button1.Margin = new Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new Size(106, 30);
            button1.TabIndex = 1;
            button1.Text = "✚ Nuevo";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.Control;
            btnModificar.Location = new Point(118, 29);
            btnModificar.Margin = new Padding(2, 2, 2, 2);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(106, 30);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "✏️ Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            btnModificar.Click += btnModificar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 25);
            label1.TabIndex = 3;
            label1.Text = "Department List";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.Control;
            btnEliminar.Location = new Point(228, 29);
            btnEliminar.Margin = new Padding(2, 2, 2, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 30);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // DepartmentList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 354);
            Controls.Add(btnEliminar);
            Controls.Add(label1);
            Controls.Add(btnModificar);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "DepartmentList";
            Text = "Departamentos";
            Load += DepartmentList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button btnModificar;
        public Label label1;
        private Button btnEliminar;
    }
}