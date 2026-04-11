namespace AdventureAdmin.Ui.ShipMethod
{
    partial class ShipMethodForm
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
            txtName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panelButtons = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            errorProvider = new ErrorProvider(components);
            numShipBase = new NumericUpDown();
            numShipRate = new NumericUpDown();
            label4 = new Label();
            IdText = new TextBox();
            panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numShipBase).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numShipRate).BeginInit();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.Location = new Point(264, 101);
            txtName.Name = "txtName";
            txtName.Size = new Size(222, 27);
            txtName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(150, 104);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(61, 156);
            label2.Name = "label2";
            label2.Size = new Size(156, 20);
            label2.TabIndex = 3;
            label2.Text = "Monto Base de Envio";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(105, 216);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 4;
            label3.Text = "Tarifa de Envio";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnSave);
            panelButtons.Controls.Add(btnCancel);
            panelButtons.Location = new Point(154, 12);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(243, 37);
            panelButtons.TabIndex = 6;
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
            btnCancel.Location = new Point(110, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 34);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "❌ Cancelar";
            btnCancel.Click += btnCancel_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // numShipBase
            // 
            numShipBase.Location = new Point(264, 156);
            numShipBase.Name = "numShipBase";
            numShipBase.Size = new Size(222, 27);
            numShipBase.TabIndex = 7;
            // 
            // numShipRate
            // 
            numShipRate.Location = new Point(264, 216);
            numShipRate.Name = "numShipRate";
            numShipRate.Size = new Size(222, 27);
            numShipRate.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(154, 66);
            label4.Name = "label4";
            label4.Size = new Size(23, 20);
            label4.TabIndex = 9;
            label4.Text = "Id";
            // 
            // IdText
            // 
            IdText.Enabled = false;
            IdText.HideSelection = false;
            IdText.Location = new Point(264, 59);
            IdText.Name = "IdText";
            IdText.Size = new Size(222, 27);
            IdText.TabIndex = 10;
            // 
            // ShipMethodForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(535, 298);
            Controls.Add(IdText);
            Controls.Add(label4);
            Controls.Add(numShipRate);
            Controls.Add(numShipBase);
            Controls.Add(panelButtons);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtName);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShipMethodForm";
            Text = "ShipMethodForm";
            panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)numShipBase).EndInit();
            ((System.ComponentModel.ISupportInitialize)numShipRate).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panelButtons;
        private Button btnSave;
        private Button btnCancel;
        private ErrorProvider errorProvider;
        private NumericUpDown numShipRate;
        private NumericUpDown numShipBase;
        private TextBox IdText;
        private Label label4;
    }
}