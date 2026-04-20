namespace AdventureAdmin.Ui.CreditCard
{
    partial class CreditCardList
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
            dgvCards = new DataGridView();
            refrescarButton = new Button();
            nuevoButton = new Button();
            modificarButton = new Button();
            eliminarButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCards).BeginInit();
            SuspendLayout();
            // 
            // dgvCards
            // 
            dgvCards.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCards.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCards.Location = new Point(13, 48);
            dgvCards.Margin = new Padding(3, 4, 3, 4);
            dgvCards.Name = "dgvCards";
            dgvCards.RowHeadersWidth = 62;
            dgvCards.Size = new Size(608, 365);
            dgvCards.TabIndex = 0;
            // 
            // refrescarButton
            // 
            refrescarButton.Location = new Point(307, 12);
            refrescarButton.Name = "refrescarButton";
            refrescarButton.Size = new Size(94, 29);
            refrescarButton.TabIndex = 4;
            refrescarButton.Text = "🔄 Refrescar";
            refrescarButton.UseVisualStyleBackColor = true;
            refrescarButton.Click += refrescarButton_Click;
            // 
            // nuevoButton
            // 
            nuevoButton.Location = new Point(13, 12);
            nuevoButton.Name = "nuevoButton";
            nuevoButton.Size = new Size(94, 29);
            nuevoButton.TabIndex = 3;
            nuevoButton.Text = "✅ Nuevo";
            nuevoButton.UseVisualStyleBackColor = true;
            nuevoButton.Click += nuevoButton_Click;
            // 
            // modificarButton
            // 
            modificarButton.Location = new Point(113, 12);
            modificarButton.Name = "modificarButton";
            modificarButton.Size = new Size(94, 29);
            modificarButton.TabIndex = 5;
            modificarButton.Text = "✏️ Modificar";
            modificarButton.UseVisualStyleBackColor = true;
            modificarButton.Click += modificarButton_Click;
            // 
            // eliminarButton
            // 
            eliminarButton.Location = new Point(213, 12);
            eliminarButton.Name = "eliminarButton";
            eliminarButton.Size = new Size(94, 29);
            eliminarButton.TabIndex = 6;
            eliminarButton.Text = "🗑️ Eliminar";
            eliminarButton.UseVisualStyleBackColor = true;
            eliminarButton.Click += eliminarButton_Click;
            // 
            // CreditCardList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 426);
            Controls.Add(eliminarButton);
            Controls.Add(modificarButton);
            Controls.Add(refrescarButton);
            Controls.Add(nuevoButton);
            Controls.Add(dgvCards);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CreditCardList";
            Text = "CreditCardList";
            Load += CreditCardList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCards).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCards;
        private Button refrescarButton;
        private Button nuevoButton;
        private Button modificarButton;
        private Button eliminarButton;
    }
}