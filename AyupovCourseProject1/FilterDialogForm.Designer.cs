namespace AyupovCourseProject1
{
    partial class FilterDialogForm
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
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            ButtonConfirm = new Button();
            ButtonClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(171, 21);
            label1.TabIndex = 1;
            label1.Text = "Введите нужные даты:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 62);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(209, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(12, 117);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(209, 23);
            dateTimePicker2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(15, 93);
            label2.Name = "label2";
            label2.Size = new Size(33, 21);
            label2.TabIndex = 1;
            label2.Text = "До:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(12, 38);
            label3.Name = "label3";
            label3.Size = new Size(36, 21);
            label3.TabIndex = 1;
            label3.Text = " От:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ButtonConfirm
            // 
            ButtonConfirm.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonConfirm.Location = new Point(12, 238);
            ButtonConfirm.Name = "ButtonConfirm";
            ButtonConfirm.Size = new Size(142, 48);
            ButtonConfirm.TabIndex = 4;
            ButtonConfirm.Text = "Применить";
            ButtonConfirm.UseVisualStyleBackColor = true;
            ButtonConfirm.Click += this.ButtonConfirm_Click;
            // 
            // ButtonClose
            // 
            ButtonClose.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ButtonClose.Location = new Point(161, 238);
            ButtonClose.Name = "ButtonClose";
            ButtonClose.Size = new Size(139, 48);
            ButtonClose.TabIndex = 4;
            ButtonClose.Text = "Отмена";
            ButtonClose.UseVisualStyleBackColor = true;
            ButtonClose.Click += ButtonClose_Click;
            // 
            // FilterDialogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 298);
            Controls.Add(ButtonClose);
            Controls.Add(ButtonConfirm);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FilterDialogForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Выбор типа фильтрации";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label2;
        private Label label3;
        private Button ButtonConfirm;
        private Button ButtonClose;
    }
}