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
            btnNuevo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCards).BeginInit();
            SuspendLayout();
            // 
            // dgvCards
            // 
            dgvCards.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCards.Location = new Point(13, 47);
            dgvCards.Margin = new Padding(4, 5, 4, 5);
            dgvCards.Name = "dgvCards";
            dgvCards.RowHeadersWidth = 62;
            dgvCards.Size = new Size(708, 300);
            dgvCards.TabIndex = 0;
            dgvCards.CellContentClick += dgvCards_CellContentClick;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = SystemColors.ActiveCaption;
            btnNuevo.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.Location = new Point(753, 47);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(133, 52);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // CreditCardList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(btnNuevo);
            Controls.Add(dgvCards);
            Margin = new Padding(4, 5, 4, 5);
            Name = "CreditCardList";
            Text = "CreditCardList";
            Load += CreditCardList_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvCards).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvCards;
        private Button btnNuevo;
    }
}