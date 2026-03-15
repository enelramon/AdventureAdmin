namespace AdventureAdmin.Ui.ShipMethod
{
    partial class ShipMethodList
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
            nuevoButton = new Button();
            ShipMethodDataView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ShipMethodDataView).BeginInit();
            SuspendLayout();
            // 
            // nuevoButton
            // 
            nuevoButton.Location = new Point(12, 12);
            nuevoButton.Name = "nuevoButton";
            nuevoButton.Size = new Size(94, 29);
            nuevoButton.TabIndex = 2;
            nuevoButton.Text = "✅ Nuevo";
            nuevoButton.UseVisualStyleBackColor = true;
            nuevoButton.Click += nuevoButton_Click;
            // 
            // ShipMethodDataView
            // 
            ShipMethodDataView.AllowUserToAddRows = false;
            ShipMethodDataView.AllowUserToDeleteRows = false;
            ShipMethodDataView.AllowUserToOrderColumns = true;
            ShipMethodDataView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ShipMethodDataView.Location = new Point(12, 47);
            ShipMethodDataView.Name = "ShipMethodDataView";
            ShipMethodDataView.ReadOnly = true;
            ShipMethodDataView.RowHeadersWidth = 51;
            ShipMethodDataView.Size = new Size(776, 390);
            ShipMethodDataView.TabIndex = 3;
            // 
            // ShipMethodList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ShipMethodDataView);
            Controls.Add(nuevoButton);
            Name = "ShipMethodList";
            Text = "ShipMethodList";
            Load += ShipMethodList_Load;
            ((System.ComponentModel.ISupportInitialize)ShipMethodDataView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button nuevoButton;
        private DataGridView ShipMethodDataView;
    }
}