namespace AdventureAdmin.Ui.Location
{
    partial class LocationList
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
            dataGridViewLocation = new DataGridView();
            btnNuevo = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLocation).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewLocation
            // 
            dataGridViewLocation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLocation.Location = new Point(12, 47);
            dataGridViewLocation.Name = "dataGridViewLocation";
            dataGridViewLocation.RowHeadersWidth = 51;
            dataGridViewLocation.Size = new Size(1009, 586);
            dataGridViewLocation.TabIndex = 0;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(12, 12);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(94, 29);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += nuevoButton_Click;
            // 
            // LocationList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 683);
            Controls.Add(btnNuevo);
            Controls.Add(dataGridViewLocation);
            Name = "LocationList";
            Text = "LocationList";
            Load += LocationList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewLocation).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewLocation;
        private Button btnNuevo;
    }
}