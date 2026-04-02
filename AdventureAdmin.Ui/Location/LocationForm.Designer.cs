namespace AdventureAdmin.Ui.Location
{
    partial class LocationForm
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
            panelButtons = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            lblName = new Label();
            txtName = new TextBox();
            lblCostRate = new Label();
            lblAvailability = new Label();
            nudAvailability = new NumericUpDown();
            nudCostRate = new NumericUpDown();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAvailability).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCostRate).BeginInit();
            SuspendLayout();
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Location = new Point(100, 170);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(243, 37);
            panelButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(2, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(104, 34);
            btnSave.TabIndex = 0;
            btnSave.Text = "💾Guardar";
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(112, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 34);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "❌ Cancelar";
            btnCancel.Click += btnCancel_Click;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(30, 30);
            lblName.Name = "lblName";
            lblName.Size = new Size(67, 20);
            lblName.TabIndex = 3;
            lblName.Text = "Nombre:";
            // 
            // txtName
            // 
            txtName.Location = new Point(150, 27);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);
            txtName.TabIndex = 4;
            // 
            // lblCostRate
            // 
            lblCostRate.AutoSize = true;
            lblCostRate.Location = new Point(30, 70);
            lblCostRate.Name = "lblCostRate";
            lblCostRate.Size = new Size(89, 20);
            lblCostRate.TabIndex = 5;
            lblCostRate.Text = "Costo/Hora:";
            // 
            // lblAvailability
            // 
            lblAvailability.AutoSize = true;
            lblAvailability.Location = new Point(30, 110);
            lblAvailability.Name = "lblAvailability";
            lblAvailability.Size = new Size(110, 20);
            lblAvailability.TabIndex = 7;
            lblAvailability.Text = "Disponibilidad:";
            // 
            // nudAvailability
            // 
            nudAvailability.DecimalPlaces = 2;
            nudAvailability.Location = new Point(150, 108);
            nudAvailability.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nudAvailability.Name = "nudAvailability";
            nudAvailability.Size = new Size(150, 27);
            nudAvailability.TabIndex = 8;
            // 
            // nudCostRate
            // 
            nudCostRate.DecimalPlaces = 2;
            nudCostRate.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudCostRate.Location = new Point(152, 72);
            nudCostRate.Name = "nudCostRate";
            nudCostRate.Size = new Size(148, 27);
            nudCostRate.TabIndex = 9;
            // 
            // LocationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 250);
            Controls.Add(nudCostRate);
            Controls.Add(nudAvailability);
            Controls.Add(lblAvailability);
            Controls.Add(lblCostRate);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(panelButtons);
            Name = "LocationForm";
            Text = "Localización";
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudAvailability).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudCostRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelButtons;
        private Button btnSave;
        private Button btnCancel;
        private Label lblName;
        private TextBox txtName;
        private Label lblCostRate;
        private Label lblAvailability;
        private NumericUpDown nudAvailability;
        private NumericUpDown nudCostRate;
    }
}
