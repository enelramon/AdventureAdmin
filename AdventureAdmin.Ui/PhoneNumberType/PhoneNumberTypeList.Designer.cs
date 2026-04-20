namespace AdventureAdmin.Ui.PhoneNumberType
{
    partial class PhoneNumberTypeList
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
            dgvPhoneNumberTypes = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPhoneNumberTypes).BeginInit();
            SuspendLayout();
            // 
            // dgvPhoneNumberTypes
            // 
            dgvPhoneNumberTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhoneNumberTypes.Location = new Point(25, 57);
            dgvPhoneNumberTypes.Name = "dgvPhoneNumberTypes";
            dgvPhoneNumberTypes.Size = new Size(558, 263);
            dgvPhoneNumberTypes.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(25, 17);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Nuevo";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PhoneNumberTypeList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 332);
            Controls.Add(button1);
            Controls.Add(dgvPhoneNumberTypes);
            Name = "PhoneNumberTypeList";
            Text = "PhoneNumberTypeList";
            ((System.ComponentModel.ISupportInitialize)dgvPhoneNumberTypes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPhoneNumberTypes;
        private Button btnNuevo;
        private Button button1;
    }
}