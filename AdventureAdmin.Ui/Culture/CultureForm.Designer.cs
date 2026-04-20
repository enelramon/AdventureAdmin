namespace AdventureAdmin.Ui.Culture
{
    partial class CultureForm
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
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            textName = new TextBox();
            textId = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 156);
            button1.Name = "button1";
            button1.Size = new Size(87, 32);
            button1.TabIndex = 0;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 1;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(53, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // textName
            // 
            textName.Location = new Point(12, 97);
            textName.Name = "textName";
            textName.Size = new Size(180, 23);
            textName.TabIndex = 3;
            // 
            // textId
            // 
            textId.Location = new Point(12, 47);
            textId.Name = "textId";
            textId.Size = new Size(180, 23);
            textId.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(105, 156);
            button2.Name = "button2";
            button2.Size = new Size(87, 32);
            button2.TabIndex = 5;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CultureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(207, 232);
            Controls.Add(button2);
            Controls.Add(textId);
            Controls.Add(textName);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "CultureForm";
            Text = "CultureForm";
            Load += CultureForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox textName;
        private TextBox textId;
        private Button button2;
    }
}