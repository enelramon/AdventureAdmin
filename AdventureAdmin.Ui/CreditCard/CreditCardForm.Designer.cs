namespace AdventureAdmin.Ui.CreditCard
{
    partial class CreditCardForm
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
            label3 = new Label();
            label4 = new Label();
            txtCardType = new TextBox();
            txtCardNumber = new TextBox();
            btnGuardar = new Button();
            errorProvider1 = new ErrorProvider(components);
            numMonth = new NumericUpDown();
            numYear = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMonth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numYear).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(17, 48);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(213, 34);
            label1.TabIndex = 0;
            label1.Text = "Tipo de tarjeta";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 112);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(226, 34);
            label2.TabIndex = 1;
            label2.Text = "Numero Tarjeta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 185);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(228, 34);
            label3.TabIndex = 2;
            label3.Text = "Mes Expiracion";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(17, 243);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(226, 34);
            label4.TabIndex = 3;
            label4.Text = "Año Expiracion";
            // 
            // txtCardType
            // 
            txtCardType.Location = new Point(250, 53);
            txtCardType.Margin = new Padding(4, 5, 4, 5);
            txtCardType.Name = "txtCardType";
            txtCardType.Size = new Size(185, 31);
            txtCardType.TabIndex = 4;
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(250, 110);
            txtCardNumber.Margin = new Padding(4, 5, 4, 5);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(185, 31);
            txtCardNumber.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.YellowGreen;
            btnGuardar.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(17, 320);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(124, 57);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // numMonth
            // 
            numMonth.Location = new Point(256, 185);
            numMonth.Name = "numMonth";
            numMonth.Size = new Size(180, 31);
            numMonth.TabIndex = 9;
            // 
            // numYear
            // 
            numYear.Location = new Point(256, 248);
            numYear.Name = "numYear";
            numYear.Size = new Size(180, 31);
            numYear.TabIndex = 10;
            // 
            // CreditCardForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 455);
            Controls.Add(numYear);
            Controls.Add(numMonth);
            Controls.Add(btnGuardar);
            Controls.Add(txtCardNumber);
            Controls.Add(txtCardType);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "CreditCardForm";
            Text = "Crear Tarjeta de Credito";
            Load += CreditCardForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMonth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numYear).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtCardType;
        private TextBox txtCardNumber;
        private Button btnGuardar;
        private ErrorProvider errorProvider1;
        private NumericUpDown numYear;
        private NumericUpDown numMonth;
    }
}