namespace AdventureAdmin.Ui.Person
{
    partial class PersonList
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Button btnNuevoRegistro;
        private System.Windows.Forms.DataGridView dataGridView2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitulo = new Label();
            lblSeparator = new Label();
            btnNuevoRegistro = new Button();
            dataGridView2 = new DataGridView();
            ModificarRegistro = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(15, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(274, 38);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Listado de Personas";
            // 
            // lblSeparator
            // 
            lblSeparator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblSeparator.BorderStyle = BorderStyle.Fixed3D;
            lblSeparator.Location = new Point(15, 50);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new Size(1226, 2);
            lblSeparator.TabIndex = 1;
            // 
            // btnNuevoRegistro
            // 
            btnNuevoRegistro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoRegistro.Location = new Point(15, 62);
            btnNuevoRegistro.Name = "btnNuevoRegistro";
            btnNuevoRegistro.Size = new Size(190, 50);
            btnNuevoRegistro.TabIndex = 2;
            btnNuevoRegistro.Text = "Nuevo Registro";
            btnNuevoRegistro.UseVisualStyleBackColor = true;
            btnNuevoRegistro.Click += btnNuevoRegistro_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Font = new Font("Segoe UI", 10F);
            dataGridView2.Location = new Point(15, 128);
            dataGridView2.Margin = new Padding(4);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 28;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(1226, 418);
            dataGridView2.TabIndex = 1;
            // 
            // ModificarRegistro
            // 
            ModificarRegistro.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ModificarRegistro.Location = new Point(211, 62);
            ModificarRegistro.Name = "ModificarRegistro";
            ModificarRegistro.Size = new Size(231, 50);
            ModificarRegistro.TabIndex = 3;
            ModificarRegistro.Text = "Modificar Registro";
            ModificarRegistro.UseVisualStyleBackColor = true;
            ModificarRegistro.Click += ModificarRegistro_Click;
            // 
            // PersonList
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 562);
            Controls.Add(ModificarRegistro);
            Controls.Add(lblTitulo);
            Controls.Add(lblSeparator);
            Controls.Add(btnNuevoRegistro);
            Controls.Add(dataGridView2);
            Font = new Font("Segoe UI", 10F);
            Margin = new Padding(4);
            MinimumSize = new Size(900, 600);
            Name = "PersonList";
            Text = "Personas";
            Load += PersonList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Button ModificarRegistro;
    }
}