namespace AdventureAdmin.Ui.Business_Entity
{
    partial class BusinessEntityForm
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
            btnGuardar = new Button();
            errorProvider1 = new ErrorProvider(components);
            label2 = new Label();
            txtGuid = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(242, 255);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 34);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(55, 190);
            label2.Name = "label2";
            label2.Size = new Size(147, 28);
            label2.TabIndex = 2;
            label2.Text = "Guid RowGuid";
            // 
            // txtGuid
            // 
            txtGuid.Location = new Point(225, 190);
            txtGuid.Name = "txtGuid";
            txtGuid.Size = new Size(150, 31);
            txtGuid.TabIndex = 7;
            txtGuid.TextChanged += txtGuid_TextChanged;
            // 
            // BusinessEntityForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(txtGuid);
            Controls.Add(label2);
            Name = "BusinessEntityForm";
            Text = "BusinessEntityForm  ";
            Load += BusinessEntityForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox3;
        private Button btnGuardar;
        private ErrorProvider errorProvider1;
        private TextBox txtGuid;
        private Label label2;
    }
}