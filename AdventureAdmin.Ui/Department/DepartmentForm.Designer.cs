namespace AdventureAdmin.Ui
{
    partial class DepartmentForm
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            txtGroupName = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            btnCancelar = new Button();
            label3 = new Label();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 63);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre del Departamento";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 130);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 1;
            label2.Text = "Nombre del Grupo";
            label2.Click += label2_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(5, 81);
            txtName.Name = "txtName";
            txtName.Size = new Size(231, 23);
            txtName.TabIndex = 2;
            // 
            // txtGroupName
            // 
            txtGroupName.Location = new Point(5, 148);
            txtGroupName.Name = "txtGroupName";
            txtGroupName.Size = new Size(231, 23);
            txtGroupName.TabIndex = 3;
            txtGroupName.TextChanged += txtGroupName_TextChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.Control;
            btnCancelar.Location = new Point(125, 186);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 37);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "❌ Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(5, 9);
            label3.Name = "label3";
            label3.Size = new Size(172, 25);
            label3.TabIndex = 6;
            label3.Text = "Department Form";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.Control;
            btnGuardar.Location = new Point(5, 186);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(111, 37);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "💾 Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // DepartmentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 255);
            Controls.Add(btnGuardar);
            Controls.Add(label3);
            Controls.Add(btnCancelar);
            Controls.Add(txtGroupName);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DepartmentForm";
            Text = "Formulario de departamento";
            Load += DepartmentForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private TextBox txtGroupName;
        private ErrorProvider errorProvider1;
        private Button btnCancelar;
        private Label label3;
        private Button btnGuardar;
    }
}