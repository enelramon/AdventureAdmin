namespace AdventureAdmin.Ui.Person
{
    partial class PersonForm
    {
        private System.ComponentModel.IContainer components = null;

        // Labels
        private System.Windows.Forms.Label lblPersonType;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblSuffix;
        private System.Windows.Forms.Label lblNameStyle;
        private System.Windows.Forms.Label lblEmailPromotion;
        private System.Windows.Forms.Label lblSeparator;

        // Inputs
        private System.Windows.Forms.ComboBox cmbPersonType;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtSuffix;
        private System.Windows.Forms.CheckBox chkNameStyle;
        private System.Windows.Forms.ComboBox cmbEmailPromotion;

        // Buttons
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;

        // Validation
        private System.Windows.Forms.ErrorProvider errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblPersonType = new Label();
            cmbPersonType = new ComboBox();
            lblTitle = new Label();
            txtTitle = new TextBox();
            lblSuffix = new Label();
            txtSuffix = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblMiddleName = new Label();
            txtMiddleName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblNameStyle = new Label();
            chkNameStyle = new CheckBox();
            lblEmailPromotion = new Label();
            cmbEmailPromotion = new ComboBox();
            lblSeparator = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblPersonType
            // 
            lblPersonType.AutoSize = true;
            lblPersonType.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPersonType.Location = new Point(40, 28);
            lblPersonType.Name = "lblPersonType";
            lblPersonType.Size = new Size(178, 28);
            lblPersonType.TabIndex = 0;
            lblPersonType.Text = "Tipo de Persona *";
            // 
            // cmbPersonType
            // 
            cmbPersonType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPersonType.Font = new Font("Segoe UI", 10F);
            cmbPersonType.Items.AddRange(new object[] { "SC – Store Contact", "IN – Individual Customer", "SP – Sales Person", "EM – Employee", "VC – Vendor Contact", "GC – General Contact" });
            cmbPersonType.Location = new Point(40, 52);
            cmbPersonType.Name = "cmbPersonType";
            cmbPersonType.Size = new Size(210, 36);
            cmbPersonType.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(275, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(68, 28);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Título";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 10F);
            txtTitle.Location = new Point(275, 52);
            txtTitle.MaxLength = 8;
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderText = "Mr. / Ms. / Dr.";
            txtTitle.Size = new Size(140, 34);
            txtTitle.TabIndex = 3;
            // 
            // lblSuffix
            // 
            lblSuffix.AutoSize = true;
            lblSuffix.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSuffix.Location = new Point(440, 28);
            lblSuffix.Name = "lblSuffix";
            lblSuffix.Size = new Size(67, 28);
            lblSuffix.TabIndex = 4;
            lblSuffix.Text = "Sufijo";
            // 
            // txtSuffix
            // 
            txtSuffix.Font = new Font("Segoe UI", 10F);
            txtSuffix.Location = new Point(440, 52);
            txtSuffix.MaxLength = 10;
            txtSuffix.Name = "txtSuffix";
            txtSuffix.PlaceholderText = "Jr. / Sr.";
            txtSuffix.Size = new Size(140, 34);
            txtSuffix.TabIndex = 5;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFirstName.Location = new Point(40, 106);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(104, 28);
            lblFirstName.TabIndex = 6;
            lblFirstName.Text = "Nombre *";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Segoe UI", 10F);
            txtFirstName.Location = new Point(40, 130);
            txtFirstName.MaxLength = 50;
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(265, 34);
            txtFirstName.TabIndex = 7;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMiddleName.Location = new Point(330, 106);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(177, 28);
            lblMiddleName.TabIndex = 8;
            lblMiddleName.Text = "Segundo Nombre";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Segoe UI", 10F);
            txtMiddleName.Location = new Point(330, 130);
            txtMiddleName.MaxLength = 50;
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(250, 34);
            txtMiddleName.TabIndex = 9;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLastName.Location = new Point(40, 184);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(106, 28);
            lblLastName.TabIndex = 10;
            lblLastName.Text = "Apellido *";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 10F);
            txtLastName.Location = new Point(40, 208);
            txtLastName.MaxLength = 50;
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(540, 34);
            txtLastName.TabIndex = 11;
            // 
            // lblNameStyle
            // 
            lblNameStyle.AutoSize = true;
            lblNameStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNameStyle.Location = new Point(40, 260);
            lblNameStyle.Name = "lblNameStyle";
            lblNameStyle.Size = new Size(172, 28);
            lblNameStyle.TabIndex = 12;
            lblNameStyle.Text = "Estilo de nombre";
            // 
            // chkNameStyle
            // 
            chkNameStyle.Font = new Font("Segoe UI", 10F);
            chkNameStyle.Location = new Point(284, 264);
            chkNameStyle.Name = "chkNameStyle";
            chkNameStyle.Size = new Size(310, 24);
            chkNameStyle.TabIndex = 13;
            chkNameStyle.Text = "Orden oriental  (Apellido, Nombre)";
            // 
            // lblEmailPromotion
            // 
            lblEmailPromotion.AutoSize = true;
            lblEmailPromotion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEmailPromotion.Location = new Point(40, 316);
            lblEmailPromotion.Name = "lblEmailPromotion";
            lblEmailPromotion.Size = new Size(396, 28);
            lblEmailPromotion.TabIndex = 14;
            lblEmailPromotion.Text = "Preferencia de promociones por e-mail *";
            // 
            // cmbEmailPromotion
            // 
            cmbEmailPromotion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmailPromotion.Font = new Font("Segoe UI", 10F);
            cmbEmailPromotion.Items.AddRange(new object[] { "0 – No desea recibir promociones", "1 – Desea recibir promociones de AdventureWorks", "2 – Desea recibir promociones de AW y socios seleccionados" });
            cmbEmailPromotion.Location = new Point(40, 356);
            cmbEmailPromotion.Name = "cmbEmailPromotion";
            cmbEmailPromotion.Size = new Size(540, 36);
            cmbEmailPromotion.TabIndex = 15;
            // 
            // lblSeparator
            // 
            lblSeparator.BorderStyle = BorderStyle.Fixed3D;
            lblSeparator.Location = new Point(40, 408);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new Size(540, 2);
            lblSeparator.TabIndex = 16;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardar.Location = new Point(40, 428);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(190, 40);
            btnGuardar.TabIndex = 17;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelar.Location = new Point(390, 428);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(190, 40);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // PersonForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 507);
            Controls.Add(lblPersonType);
            Controls.Add(cmbPersonType);
            Controls.Add(lblTitle);
            Controls.Add(txtTitle);
            Controls.Add(lblSuffix);
            Controls.Add(txtSuffix);
            Controls.Add(lblFirstName);
            Controls.Add(txtFirstName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtMiddleName);
            Controls.Add(lblLastName);
            Controls.Add(txtLastName);
            Controls.Add(lblNameStyle);
            Controls.Add(chkNameStyle);
            Controls.Add(lblEmailPromotion);
            Controls.Add(cmbEmailPromotion);
            Controls.Add(lblSeparator);
            Controls.Add(btnGuardar);
            Controls.Add(btnCancelar);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "PersonForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registro de Persona";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}