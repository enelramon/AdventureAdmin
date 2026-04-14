namespace AdventureAdmin.Ui.PhoneNumberType
{
    partial class PhoneNumberTypeForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label label1;
        private TextBox txtName;
        private Button btnGuardar;
        private Button btnCancelar;
        private ErrorProvider errorProvider;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            label1 = new Label();
            txtName = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            errorProvider = new ErrorProvider(components);

            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 60);
            label1.Name = "label1";
            label1.Size = new Size(250, 34);
            label1.Text = "Nombre del Tipo";

            // 
            // txtName
            // 
            txtName.Location = new Point(300, 60);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 31);
            txtName.TabIndex = 1;

            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.YellowGreen;
            btnGuardar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(30, 150);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 50);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnSave_Click;

            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightCoral;
            btnCancelar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(170, 150);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 50);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancel_Click;

            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;

            // 
            // PhoneNumberTypeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 250);
            Controls.Add(label1);
            Controls.Add(txtName);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Name = "PhoneNumberTypeForm";
            Text = "Crear Tipo de Teléfono";
            Load += PhoneNumberTypeForm_Load;

            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}